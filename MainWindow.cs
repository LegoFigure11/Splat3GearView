using Splat3GearView.Properties;
using Splat3GearView.Resources;
using Splat3GearView.Structures;
using SysBot.Base;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Text.Json;
using static System.Buffers.Binary.BinaryPrimitives;

namespace Splat3GearView
{
    public partial class MainWindow : Form
    {
        private readonly static SwitchConnectionConfig Config = new() { Protocol = SwitchProtocol.WiFi, IP = Settings.Default.SwitchIP, Port = 6000 };
        private readonly static SwitchSocketAsync SwitchConnection = new(Config);

        public readonly GearData GearData = new();

        private List<Gear> GearList = new();
        private int index;

        string CachedText = string.Empty;

        bool GrindTT;

        public MainWindow()
        {
            string build = string.Empty;
#if DEBUG
            var date = File.GetLastWriteTime(System.Reflection.Assembly.GetEntryAssembly()!.Location);
            build = $" (dev-{date:yyyyMMdd})";
#endif
            var v = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version!;
            Text = "Splat3GearView v" + v.Major + "." + v.Minor + "." + v.Build + build;

            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            InputSwitchIP.Text = Settings.Default.SwitchIP;
            LabelIndex.Text = string.Empty;
            CachedText = Text;
            GrindMode.SelectedIndex = 0;
        }

        private void InputSwitchIP_Changed(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text != "192.168.0.0")
            {
                Settings.Default.SwitchIP = textBox.Text;
                Config.IP = textBox.Text;
            }
            Settings.Default.Save();
        }

        private async void Connect_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                ConnectionStatusText.Text = "Connecting...";
                SwitchConnection.Connect();

                //var game = SwitchConnection.GetGameInfo("name", CancellationToken.None).Result;
                var vers = SwitchConnection.GetGameInfo("version", CancellationToken.None).Result.Trim();
                //var id = SwitchConnection.GetTitleID(CancellationToken.None).Result;

                var vs = $" - S3 ver {vers}";
                Text = CachedText + vs;

                index = 0;

                ButtonConnect.Enabled = false;
                ButtonDisconnect.Enabled = true;
                ConnectionStatusText.Text = "Reading seed block...";

                var offs = Offsets.GachaBlock;
                var block = await SwitchConnection.ReadBytesAsync(offs, GachaSeed.SIZE, CancellationToken.None);
                var seeds = ReadGachaSeeds(block);
                try
                {
                    Gacha0.Text = $"{seeds[0].s0:X08}";
                    Gacha1.Text = $"{seeds[0].s1:X08}";
                    Gacha2.Text = $"{seeds[0].s2:X08}";
                    Gacha3.Text = $"{seeds[0].s3:X08}";
                }
                catch { };

                try
                {
                    Fest0.Text = $"{seeds[1].s0:X08}";
                    Fest1.Text = $"{seeds[1].s1:X08}";
                    Fest2.Text = $"{seeds[1].s2:X08}";
                    Fest3.Text = $"{seeds[1].s3:X08}";
                }
                catch { };

                try
                {
                    Murch0.Text = $"{seeds[2].s0:X08}";
                    Murch1.Text = $"{seeds[2].s1:X08}";
                    Murch2.Text = $"{seeds[2].s2:X08}";
                    Murch3.Text = $"{seeds[2].s3:X08}";
                }
                catch { };

                try
                {
                    Title0.Text = $"{seeds[3].s0:X08}";
                    Title1.Text = $"{seeds[3].s1:X08}";
                    Title2.Text = $"{seeds[3].s2:X08}";
                    Title3.Text = $"{seeds[3].s3:X08}";
                }
                catch { };

                try
                {
                    Banner0.Text = $"{seeds[4].s0:X08}";
                    Banner1.Text = $"{seeds[4].s1:X08}";
                    Banner2.Text = $"{seeds[4].s2:X08}";
                    Banner3.Text = $"{seeds[4].s3:X08}";
                }
                catch { };

                ConnectionStatusText.Text = "Reading gear...";
                GearList.Clear();
                uint pos = 0x40; // First gear is located at offset + 0x40
                Gear gear;

                int CHUNK_SIZE = 10;

                bool IsValid = true;

                // Load Headgear
                ConnectionStatusText.Text = "Reading headgear...";
                do
                {
                    var Data = await SwitchConnection.ReadBytesAsync(Offsets.GearList_Head + pos, Gear.SIZE * CHUNK_SIZE, CancellationToken.None); // Read gear in chunks
                    for (int i = 0; i < CHUNK_SIZE; i++)
                    {
                        gear = new Gear(Data.AsSpan(i * Gear.SIZE, Gear.SIZE).ToArray())
                        {
                            GearType = (byte)GearTypes.Headgear
                        };
                        if (gear.IsValid)
                        {
                            gear.SetInfoFromJSON();
                            GearList.Add(gear);
                        }
                        else
                        {
                            // Reached junk data/end of list, break out of both loops
                            IsValid = false;
                            break;
                        }
                    }
                    pos += (uint)(Gear.SIZE * CHUNK_SIZE);
                } while (IsValid);


                // Load Clothes
                pos = 0x40;
                IsValid = true;
                ConnectionStatusText.Text = "Reading clothes...";
                do
                {
                    var Data = await SwitchConnection.ReadBytesAsync(Offsets.GearList_Clothes + pos, Gear.SIZE * CHUNK_SIZE, CancellationToken.None);
                    for (int i = 0; i < CHUNK_SIZE; i++)
                    {
                        gear = new Gear(Data.AsSpan(i * Gear.SIZE, Gear.SIZE).ToArray())
                        {
                            GearType = (byte)GearTypes.Clothes
                        };
                        if (gear.IsValid)
                        {
                            gear.SetInfoFromJSON();
                            GearList.Add(gear);
                        }
                        else
                        {
                            IsValid = false;
                            break;
                        }
                    }
                    pos += (uint)(Gear.SIZE * CHUNK_SIZE);
                } while (IsValid);

                // Load Shoes
                pos = 0x40;
                IsValid = true;
                ConnectionStatusText.Text = "Reading shoes...";
                do
                {
                    var Data = await SwitchConnection.ReadBytesAsync(Offsets.GearList_Shoes + pos, Gear.SIZE * CHUNK_SIZE, CancellationToken.None);
                    for (int i = 0; i < CHUNK_SIZE; i++)
                    {
                        gear = new Gear(Data.AsSpan(i * Gear.SIZE, Gear.SIZE).ToArray())
                        {
                            GearType = (byte)GearTypes.Shoes
                        };
                        if (gear.IsValid)
                        {
                            gear.SetInfoFromJSON();
                            GearList.Add(gear);
                        }
                        else
                        {
                            IsValid = false;
                            break;
                        }
                    }
                    pos += (uint)(Gear.SIZE * CHUNK_SIZE);
                } while (IsValid);

                LabelLoadedGear.Text = $"Loaded Gear: {GearList.Count}";
                LabelLoadedHeadgear.Text = $"Headgear: {GearList.Where(g => g.GearType == (byte)GearTypes.Headgear).Count()}";
                LabelLoadedClothes.Text = $"Clothes: {GearList.Where(g => g.GearType == (byte)GearTypes.Clothes).Count()}";
                LabelLoadedShoes.Text = $"Shoes: {GearList.Where(g => g.GearType == (byte)GearTypes.Shoes).Count()}";
                GearList = GearList.OrderBy(g => g.GearType).ThenBy(g => g.ID).ToList();
                if (GearList.Count > 0)
                {
                    DisplayGear(index);
                    ButtonDumpGear.Enabled = true;
                }
                else ButtonDumpGear.Enabled = false;
                ConnectionStatusText.Text = "Done.";
                //Disconnect();
            }
            catch (SocketException err)
            {
                // a bit hacky but it works
                if (err.Message.Contains("failed to respond") || err.Message.Contains("actively refused"))
                {
                    ConnectionStatusText.Text = "Unable to connect.";
                    MessageBox.Show(err.Message);
                }
                else
                {
                    ConnectionStatusText.Text = "Disconnected.";
                }
                ButtonConnect.Enabled = true;
                ButtonDisconnect.Enabled = false;
            }
        }

        private static Dictionary<byte, GachaSeed> ReadGachaSeeds(byte[] data)
        {
            var ret = new Dictionary<byte, GachaSeed>();
            for (uint i = 0; i < GachaSeed.SIZE; i += GachaSeed.STRUCT_SIZE)
            {
                var chunk = data.AsSpan((int)i, (int)GachaSeed.STRUCT_SIZE);
                var key = ReadUInt32LittleEndian(chunk[..8]);

                // Init the seed here so it's easier to find the unknown keys
                var rawseed = chunk[(byte)GachaSeed.SEED_OFFSET..((int)GachaSeed.SEED_OFFSET + GachaSeed.SEED_SIZE)];
                var seed = new GachaSeed(rawseed.ToArray());

                switch (key)
                {
                    case GachaSeed.NORMAL_KEY:
                        ret.Add(0, seed);
                        break;

                    case GachaSeed.FEST_KEY:
                        ret.Add(1, seed);
                        break;

                    case GachaSeed.MURCH_KEY:
                        ret.Add(2, seed);
                        break;

                    case GachaSeed.TITLE_KEY:
                        ret.Add(3, seed);
                        break;

                    case GachaSeed.BANNER_KEY:
                        ret.Add(4, seed);
                        break;

                    default:
                        break;
                }
            }
            return ret;
        }

        private void Disconnect_Click(object sender, EventArgs e)
        {
            Disconnect();
            ConnectionStatusText.Text = "Disconnected.";

            ButtonConnect.Enabled = true;
            ButtonDisconnect.Enabled = false;
        }

        private async void Disconnect()
        {
            if (SwitchConnection.Connected)
            {
                await SwitchConnection.SendAsync(SwitchCommand.DetachController(true), CancellationToken.None).ConfigureAwait(false);
                SwitchConnection.Disconnect();
            }
        }

        private void DisplayGear(int num)
        {
            LabelIndex.Text = $"{(index + 1):D2} / {GearList.Count}";
            Gear gear = GearList[num];
            GearName.Text = gear.Name;
            GearBrand.Text = gear.Brand;
            GearID.Text = $"{gear.ID:D5}";
            GearSeed.Text = $"{gear.Seed:X8}";
            GearRarity.Text = $"{gear.Rarity}";
            GearSlots.Text = $"{gear.Ability_SubCount}";

            string fp = $".\\Resources\\Images\\Gear\\{gear.__RowID}.png";
            GearIcon.Image = File.Exists(fp) ? Image.FromFile(fp) : null;

            string BasePath = $".\\Resources\\Images\\Skill\\Base.png";
            var Base = File.Exists(BasePath) ? Image.FromFile(BasePath) : null;

            string Primary = $".\\Resources\\Images\\Skill\\{gear.Ability_Primary}.png";
            GearPrimaryAbility.Text = Strings.Abilities[gear.Ability_Primary];
            var p = File.Exists(Primary) ? Image.FromFile(Primary) : null;
            PrimaryIcon.Image = (Base is not null && p is not null) ? LayerImage(Base, p, 0, 0) : null;

            string Sub1 = $".\\Resources\\Images\\Skill\\{gear.Ability_Sub1}.png";
            GearSubAbility1.Text = Strings.Abilities[gear.Ability_Sub1];
            var s1 = File.Exists(Sub1) ? Image.FromFile(Sub1) : null;
            Sub1Icon.Image = (Base is not null && s1 is not null) ? LayerImage(Base, s1, 0, 0) : null;

            string Sub2 = $".\\Resources\\Images\\Skill\\{(gear.Rarity >= 1 ? gear.Ability_Sub2 : -1)}.png";
            GearSubAbility2.Text = gear.Rarity >= 1 ? Strings.Abilities[gear.Ability_Sub2] : "(None)";
            var s2 = File.Exists(Sub2) ? Image.FromFile(Sub2) : null;
            Sub2Icon.Image = (Base is not null && s2 is not null) ? LayerImage(Base, s2, 0, 0) : null;

            string Sub3 = $".\\Resources\\Images\\Skill\\{(gear.Rarity >= 2 ? gear.Ability_Sub3 : -1)}.png";
            GearSubAbility3.Text = gear.Rarity >= 2 ? Strings.Abilities[gear.Ability_Sub3] : "(None)";
            var s3 = File.Exists(Sub3) ? Image.FromFile(Sub3) : null;
            Sub3Icon.Image = (Base is not null && s3 is not null) ? LayerImage(Base, s3, 0, 0) : null;
        }

        private void ButtonPrevious_Click(object sender, EventArgs e)
        {
            if (GearList.Count > 0)
            {
                index = (index + GearList.Count - 1) % GearList.Count; // Wrap around
                DisplayGear(index);
            }
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            if (GearList.Count > 0)
            {
                index = (index + GearList.Count + 1) % GearList.Count; // Wrap around
                DisplayGear(index);
            }
        }

        public static Bitmap LayerImage(Image baseLayer, Image overLayer, int x, int y)
        {
            Bitmap img = new(baseLayer);
            using Graphics gr = Graphics.FromImage(img);
            gr.DrawImage(overLayer, x, y, overLayer.Width, overLayer.Height);
            return img;
        }

        private readonly static Dictionary<string, Dictionary<string, WebsiteFormat>> WebsiteJSON = new();
        private void ButtonDumpGear_Click(object sender, EventArgs e)
        {
            WebsiteJSON["HaveGearHeadMap"] = new();
            WebsiteJSON["HaveGearClothesMap"] = new();
            WebsiteJSON["HaveGearShoesMap"] = new();

            foreach (Gear gear in GearList)
            {
                string key = gear.GearType switch
                {
                    (byte)GearTypes.Headgear => "HaveGearHeadMap",
                    (byte)GearTypes.Clothes => "HaveGearClothesMap",
                    _ => "HaveGearShoesMap",
                };
                WebsiteJSON[key][$"{gear.ID}"] = new()
                {
                    MainSkill = // Website format is weird
                        gear.Ability_Primary - 1 >= (byte)Abilities.IntensifyAction
                        ? (gear.Ability_Primary - (byte)Abilities.IntensifyAction) + 99
                        : gear.Ability_Primary - 1,
                    RandomContext = gear.Seed,
                    ExDrinksArray = Array.Empty<int>(),
                    ExSkillArray = new int[] { gear.Ability_Sub1 - 1, gear.Ability_Sub2 - 1, gear.Ability_Sub3 - 1 }
                };
            }

            string JSONString = JsonSerializer.Serialize(WebsiteJSON);
            Clipboard.SetText(JSONString);
            MessageBox.Show("Copied JSON to clipboard!\nUpload it at https://leanny.github.io/splat3seedchecker/#/settings");
        }

        private async void ButtonGrindTableturf_Click(object sender, EventArgs e)
        {
            GrindTT = true;
            if (SwitchConnection.Connected)
            {
                while (GrindTT)
                {
                    switch (GrindMode.SelectedIndex)
                    {
                        case 0:
                            if (SwitchConnection.Connected) await Click(SwitchButton.DUP, 20, CancellationToken.None);
                            if (SwitchConnection.Connected) await Click(SwitchButton.A, 20, CancellationToken.None);
                            if (SwitchConnection.Connected) await Click(SwitchButton.A, 20, CancellationToken.None);
                            if (SwitchConnection.Connected) await Click(SwitchButton.B, 20, CancellationToken.None);
                            await Task.Delay(1_000, CancellationToken.None);
                            break;
                    }
                }
                await SwitchConnection.SendAsync(SwitchCommand.DetachController(true), CancellationToken.None).ConfigureAwait(false);
            }
        }

        private static new async Task Click(SwitchButton button, int delay, CancellationToken token)
        {
            await SwitchConnection.SendAsync(SwitchCommand.Click(button, true), token).ConfigureAwait(false);
            await Task.Delay(delay, token).ConfigureAwait(false);
        }

        private void ButtonStopGrind_Click(object sender, EventArgs e)
        {
            GrindTT = false;
        }
    }
}
