using System.Text.Json.Nodes;

namespace Splat3GearView.Resources
{
    public class GearData
    {
        public static List<GearDataFromJSON> Headgear { get => GetGear(HeadgearJSON); }
        public static List<GearDataFromJSON> Clothes { get => GetGear(ClothesJSON); }
        public static List<GearDataFromJSON> Shoes { get => GetGear(ShoesJSON); }
        public static JsonNode MasterBrands { get => MasterJSON!["CommonMsg/Gear/GearBrandName"]!; }
        public static JsonNode MasterHeadgear { get => MasterJSON!["CommonMsg/Gear/GearName_Head"]!; }
        public static JsonNode MasterClothes { get => MasterJSON!["CommonMsg/Gear/GearName_Clothes"]!; }
        public static JsonNode MasterShoes { get => MasterJSON!["CommonMsg/Gear/GearName_Shoes"]!; }

        private const string HeadgearFilename = ".\\Resources\\JSON\\GearInfoHead.json";
        private const string ClothesFilename = ".\\Resources\\JSON\\GearInfoClothes.json";
        private const string ShoesFilename = ".\\Resources\\JSON\\GearInfoShoes.json";
        private const string MasterFilename = ".\\Resources\\JSON\\EUen.json";

        static readonly JsonNode HeadgearJSON = JsonNode.Parse(File.ReadAllText(HeadgearFilename))!;
        static readonly JsonNode ClothesJSON = JsonNode.Parse(File.ReadAllText(ClothesFilename))!;
        static readonly JsonNode ShoesJSON = JsonNode.Parse(File.ReadAllText(ShoesFilename))!;
        static readonly JsonNode MasterJSON = JsonNode.Parse(File.ReadAllText(MasterFilename))!;

        private static List<GearDataFromJSON> GetGear(JsonNode file)
        {
            JsonArray arr = file.Root.AsArray();
            List<GearDataFromJSON> o = new();
            foreach (JsonNode? g in arr)
            {
                GearDataFromJSON c = new();
                if (g?["Id"] is JsonNode x)
                {
                    c.ID = ushort.Parse($"{x}");
                }
                if (g?["Brand"] is JsonNode y)
                {
                    c.Brand = $"{y}";
                }
                if (g?["__RowId"] is JsonNode z)
                {
                    c.RowID = $"{z}";
                    c.MasterID = $"{z}".Split("_")[1];
                }
                o.Add(c);
            }
            return o;
        }

        public static GearDataFromJSON FindGear(ushort ID, byte Type)
        {
            if (Type is (byte)GearTypes.Headgear)
                return Headgear.Where(g => g.ID == ID).First();
            else if (Type is (byte)GearTypes.Clothes)
                return Clothes.Where(g => g.ID == ID).First();
            else return Shoes.Where(g => g.ID == ID).First();
        }
    }

    public class GearDataFromJSON
    {
        public ushort ID { get; set; }
        public string? Brand { get; set; }
        public string? RowID { get; set; }
        public string? MasterID { get; set; }
    }
}
