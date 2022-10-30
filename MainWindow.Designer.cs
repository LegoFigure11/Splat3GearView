namespace Splat3GearView
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.LabelSwitchIP = new System.Windows.Forms.Label();
            this.LabelStatus = new System.Windows.Forms.Label();
            this.InputSwitchIP = new System.Windows.Forms.TextBox();
            this.ConnectionStatusText = new System.Windows.Forms.Label();
            this.ButtonConnect = new System.Windows.Forms.Button();
            this.ButtonDisconnect = new System.Windows.Forms.Button();
            this.ButtonDumpGear = new System.Windows.Forms.Button();
            this.LabelLoadedGear = new System.Windows.Forms.Label();
            this.LabelGearBrand = new System.Windows.Forms.Label();
            this.GearBrand = new System.Windows.Forms.TextBox();
            this.GearID = new System.Windows.Forms.TextBox();
            this.LabelGearID = new System.Windows.Forms.Label();
            this.GearRarity = new System.Windows.Forms.TextBox();
            this.LabelGearRarity = new System.Windows.Forms.Label();
            this.GearSeed = new System.Windows.Forms.TextBox();
            this.LabelGearSeed = new System.Windows.Forms.Label();
            this.ButtonPrevious = new System.Windows.Forms.Button();
            this.ButtonNext = new System.Windows.Forms.Button();
            this.LabelIndex = new System.Windows.Forms.Label();
            this.GearSlots = new System.Windows.Forms.TextBox();
            this.LabelGearSlots = new System.Windows.Forms.Label();
            this.GearPrimaryAbility = new System.Windows.Forms.TextBox();
            this.LabelGearPrimaryAbility = new System.Windows.Forms.Label();
            this.GearSubAbility1 = new System.Windows.Forms.TextBox();
            this.LabelGearSubAbility1 = new System.Windows.Forms.Label();
            this.GearSubAbility2 = new System.Windows.Forms.TextBox();
            this.LabelGearSubAbility2 = new System.Windows.Forms.Label();
            this.GearSubAbility3 = new System.Windows.Forms.TextBox();
            this.LabelGearSubAbility3 = new System.Windows.Forms.Label();
            this.LabelLoadedHeadgear = new System.Windows.Forms.Label();
            this.LabelLoadedClothes = new System.Windows.Forms.Label();
            this.LabelLoadedShoes = new System.Windows.Forms.Label();
            this.GearName = new System.Windows.Forms.TextBox();
            this.LabelGearName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LabelSwitchIP
            // 
            this.LabelSwitchIP.AutoSize = true;
            this.LabelSwitchIP.Location = new System.Drawing.Point(14, 10);
            this.LabelSwitchIP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelSwitchIP.Name = "LabelSwitchIP";
            this.LabelSwitchIP.Size = new System.Drawing.Size(58, 15);
            this.LabelSwitchIP.TabIndex = 0;
            this.LabelSwitchIP.Text = "Switch IP:";
            // 
            // LabelStatus
            // 
            this.LabelStatus.AutoSize = true;
            this.LabelStatus.Location = new System.Drawing.Point(31, 33);
            this.LabelStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelStatus.Name = "LabelStatus";
            this.LabelStatus.Size = new System.Drawing.Size(42, 15);
            this.LabelStatus.TabIndex = 1;
            this.LabelStatus.Text = "Status:";
            // 
            // InputSwitchIP
            // 
            this.InputSwitchIP.Location = new System.Drawing.Point(85, 7);
            this.InputSwitchIP.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.InputSwitchIP.Name = "InputSwitchIP";
            this.InputSwitchIP.Size = new System.Drawing.Size(129, 23);
            this.InputSwitchIP.TabIndex = 2;
            this.InputSwitchIP.Text = "www.www.www.www";
            this.InputSwitchIP.TextChanged += new System.EventHandler(this.InputSwitchIP_Changed);
            // 
            // ConnectionStatusText
            // 
            this.ConnectionStatusText.AutoSize = true;
            this.ConnectionStatusText.Location = new System.Drawing.Point(85, 33);
            this.ConnectionStatusText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ConnectionStatusText.Name = "ConnectionStatusText";
            this.ConnectionStatusText.Size = new System.Drawing.Size(89, 15);
            this.ConnectionStatusText.TabIndex = 3;
            this.ConnectionStatusText.Text = "Not connected.";
            // 
            // ButtonConnect
            // 
            this.ButtonConnect.Location = new System.Drawing.Point(14, 52);
            this.ButtonConnect.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ButtonConnect.Name = "ButtonConnect";
            this.ButtonConnect.Size = new System.Drawing.Size(97, 27);
            this.ButtonConnect.TabIndex = 4;
            this.ButtonConnect.Text = "Connect";
            this.ButtonConnect.UseVisualStyleBackColor = true;
            this.ButtonConnect.Click += new System.EventHandler(this.Connect_ClickAsync);
            // 
            // ButtonDisconnect
            // 
            this.ButtonDisconnect.Enabled = false;
            this.ButtonDisconnect.Location = new System.Drawing.Point(118, 52);
            this.ButtonDisconnect.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ButtonDisconnect.Name = "ButtonDisconnect";
            this.ButtonDisconnect.Size = new System.Drawing.Size(97, 27);
            this.ButtonDisconnect.TabIndex = 5;
            this.ButtonDisconnect.Text = "Disconnect";
            this.ButtonDisconnect.UseVisualStyleBackColor = true;
            this.ButtonDisconnect.Click += new System.EventHandler(this.Disconnect_Click);
            // 
            // ButtonDumpGear
            // 
            this.ButtonDumpGear.Enabled = false;
            this.ButtonDumpGear.Location = new System.Drawing.Point(14, 85);
            this.ButtonDumpGear.Name = "ButtonDumpGear";
            this.ButtonDumpGear.Size = new System.Drawing.Size(200, 23);
            this.ButtonDumpGear.TabIndex = 6;
            this.ButtonDumpGear.Text = "Dump gear to website format";
            this.ButtonDumpGear.UseVisualStyleBackColor = true;
            this.ButtonDumpGear.Click += new System.EventHandler(this.ButtonDumpGear_Click);
            // 
            // LabelLoadedGear
            // 
            this.LabelLoadedGear.AutoSize = true;
            this.LabelLoadedGear.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelLoadedGear.Location = new System.Drawing.Point(14, 119);
            this.LabelLoadedGear.Name = "LabelLoadedGear";
            this.LabelLoadedGear.Size = new System.Drawing.Size(85, 15);
            this.LabelLoadedGear.TabIndex = 7;
            this.LabelLoadedGear.Text = "Loaded Gear: 0";
            // 
            // LabelGearBrand
            // 
            this.LabelGearBrand.AutoSize = true;
            this.LabelGearBrand.Location = new System.Drawing.Point(265, 67);
            this.LabelGearBrand.Name = "LabelGearBrand";
            this.LabelGearBrand.Size = new System.Drawing.Size(41, 15);
            this.LabelGearBrand.TabIndex = 8;
            this.LabelGearBrand.Text = "Brand:";
            // 
            // GearBrand
            // 
            this.GearBrand.Location = new System.Drawing.Point(313, 64);
            this.GearBrand.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GearBrand.Name = "GearBrand";
            this.GearBrand.ReadOnly = true;
            this.GearBrand.Size = new System.Drawing.Size(132, 23);
            this.GearBrand.TabIndex = 9;
            // 
            // GearID
            // 
            this.GearID.Location = new System.Drawing.Point(313, 94);
            this.GearID.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GearID.Name = "GearID";
            this.GearID.ReadOnly = true;
            this.GearID.Size = new System.Drawing.Size(132, 23);
            this.GearID.TabIndex = 11;
            // 
            // LabelGearID
            // 
            this.LabelGearID.AutoSize = true;
            this.LabelGearID.Location = new System.Drawing.Point(258, 97);
            this.LabelGearID.Name = "LabelGearID";
            this.LabelGearID.Size = new System.Drawing.Size(48, 15);
            this.LabelGearID.TabIndex = 10;
            this.LabelGearID.Text = "Gear ID:";
            // 
            // GearRarity
            // 
            this.GearRarity.Location = new System.Drawing.Point(313, 155);
            this.GearRarity.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GearRarity.Name = "GearRarity";
            this.GearRarity.ReadOnly = true;
            this.GearRarity.Size = new System.Drawing.Size(41, 23);
            this.GearRarity.TabIndex = 15;
            // 
            // LabelGearRarity
            // 
            this.LabelGearRarity.AutoSize = true;
            this.LabelGearRarity.Location = new System.Drawing.Point(266, 158);
            this.LabelGearRarity.Name = "LabelGearRarity";
            this.LabelGearRarity.Size = new System.Drawing.Size(40, 15);
            this.LabelGearRarity.TabIndex = 14;
            this.LabelGearRarity.Text = "Rarity:";
            // 
            // GearSeed
            // 
            this.GearSeed.Location = new System.Drawing.Point(313, 125);
            this.GearSeed.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GearSeed.Name = "GearSeed";
            this.GearSeed.ReadOnly = true;
            this.GearSeed.Size = new System.Drawing.Size(132, 23);
            this.GearSeed.TabIndex = 13;
            // 
            // LabelGearSeed
            // 
            this.LabelGearSeed.AutoSize = true;
            this.LabelGearSeed.Location = new System.Drawing.Point(271, 128);
            this.LabelGearSeed.Name = "LabelGearSeed";
            this.LabelGearSeed.Size = new System.Drawing.Size(35, 15);
            this.LabelGearSeed.TabIndex = 12;
            this.LabelGearSeed.Text = "Seed:";
            // 
            // ButtonPrevious
            // 
            this.ButtonPrevious.Location = new System.Drawing.Point(313, 7);
            this.ButtonPrevious.Name = "ButtonPrevious";
            this.ButtonPrevious.Size = new System.Drawing.Size(33, 23);
            this.ButtonPrevious.TabIndex = 16;
            this.ButtonPrevious.Text = "<<";
            this.ButtonPrevious.UseVisualStyleBackColor = true;
            this.ButtonPrevious.Click += new System.EventHandler(this.ButtonPrevious_Click);
            // 
            // ButtonNext
            // 
            this.ButtonNext.Location = new System.Drawing.Point(412, 7);
            this.ButtonNext.Name = "ButtonNext";
            this.ButtonNext.Size = new System.Drawing.Size(33, 23);
            this.ButtonNext.TabIndex = 17;
            this.ButtonNext.Text = ">>";
            this.ButtonNext.UseVisualStyleBackColor = true;
            this.ButtonNext.Click += new System.EventHandler(this.ButtonNext_Click);
            // 
            // LabelIndex
            // 
            this.LabelIndex.AutoSize = true;
            this.LabelIndex.Location = new System.Drawing.Point(355, 12);
            this.LabelIndex.Name = "LabelIndex";
            this.LabelIndex.Size = new System.Drawing.Size(48, 15);
            this.LabelIndex.TabIndex = 18;
            this.LabelIndex.Text = "ww/ww";
            // 
            // GearSlots
            // 
            this.GearSlots.Location = new System.Drawing.Point(404, 154);
            this.GearSlots.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GearSlots.Name = "GearSlots";
            this.GearSlots.ReadOnly = true;
            this.GearSlots.Size = new System.Drawing.Size(41, 23);
            this.GearSlots.TabIndex = 20;
            // 
            // LabelGearSlots
            // 
            this.LabelGearSlots.AutoSize = true;
            this.LabelGearSlots.Location = new System.Drawing.Point(362, 158);
            this.LabelGearSlots.Name = "LabelGearSlots";
            this.LabelGearSlots.Size = new System.Drawing.Size(35, 15);
            this.LabelGearSlots.TabIndex = 19;
            this.LabelGearSlots.Text = "Slots:";
            // 
            // GearPrimaryAbility
            // 
            this.GearPrimaryAbility.Location = new System.Drawing.Point(313, 185);
            this.GearPrimaryAbility.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GearPrimaryAbility.Name = "GearPrimaryAbility";
            this.GearPrimaryAbility.ReadOnly = true;
            this.GearPrimaryAbility.Size = new System.Drawing.Size(132, 23);
            this.GearPrimaryAbility.TabIndex = 22;
            // 
            // LabelGearPrimaryAbility
            // 
            this.LabelGearPrimaryAbility.AutoSize = true;
            this.LabelGearPrimaryAbility.Location = new System.Drawing.Point(218, 188);
            this.LabelGearPrimaryAbility.Name = "LabelGearPrimaryAbility";
            this.LabelGearPrimaryAbility.Size = new System.Drawing.Size(88, 15);
            this.LabelGearPrimaryAbility.TabIndex = 21;
            this.LabelGearPrimaryAbility.Text = "Primary Ability:";
            // 
            // GearSubAbility1
            // 
            this.GearSubAbility1.Location = new System.Drawing.Point(313, 215);
            this.GearSubAbility1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GearSubAbility1.Name = "GearSubAbility1";
            this.GearSubAbility1.ReadOnly = true;
            this.GearSubAbility1.Size = new System.Drawing.Size(132, 23);
            this.GearSubAbility1.TabIndex = 24;
            // 
            // LabelGearSubAbility1
            // 
            this.LabelGearSubAbility1.AutoSize = true;
            this.LabelGearSubAbility1.Location = new System.Drawing.Point(230, 218);
            this.LabelGearSubAbility1.Name = "LabelGearSubAbility1";
            this.LabelGearSubAbility1.Size = new System.Drawing.Size(76, 15);
            this.LabelGearSubAbility1.TabIndex = 23;
            this.LabelGearSubAbility1.Text = "Sub Ability 1:";
            // 
            // GearSubAbility2
            // 
            this.GearSubAbility2.Location = new System.Drawing.Point(313, 245);
            this.GearSubAbility2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GearSubAbility2.Name = "GearSubAbility2";
            this.GearSubAbility2.ReadOnly = true;
            this.GearSubAbility2.Size = new System.Drawing.Size(132, 23);
            this.GearSubAbility2.TabIndex = 26;
            // 
            // LabelGearSubAbility2
            // 
            this.LabelGearSubAbility2.AutoSize = true;
            this.LabelGearSubAbility2.Location = new System.Drawing.Point(230, 248);
            this.LabelGearSubAbility2.Name = "LabelGearSubAbility2";
            this.LabelGearSubAbility2.Size = new System.Drawing.Size(76, 15);
            this.LabelGearSubAbility2.TabIndex = 25;
            this.LabelGearSubAbility2.Text = "Sub Ability 2:";
            // 
            // GearSubAbility3
            // 
            this.GearSubAbility3.Location = new System.Drawing.Point(313, 275);
            this.GearSubAbility3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GearSubAbility3.Name = "GearSubAbility3";
            this.GearSubAbility3.ReadOnly = true;
            this.GearSubAbility3.Size = new System.Drawing.Size(132, 23);
            this.GearSubAbility3.TabIndex = 28;
            // 
            // LabelGearSubAbility3
            // 
            this.LabelGearSubAbility3.AutoSize = true;
            this.LabelGearSubAbility3.Location = new System.Drawing.Point(230, 278);
            this.LabelGearSubAbility3.Name = "LabelGearSubAbility3";
            this.LabelGearSubAbility3.Size = new System.Drawing.Size(76, 15);
            this.LabelGearSubAbility3.TabIndex = 27;
            this.LabelGearSubAbility3.Text = "Sub Ability 3:";
            // 
            // LabelLoadedHeadgear
            // 
            this.LabelLoadedHeadgear.AutoSize = true;
            this.LabelLoadedHeadgear.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelLoadedHeadgear.Location = new System.Drawing.Point(29, 134);
            this.LabelLoadedHeadgear.Name = "LabelLoadedHeadgear";
            this.LabelLoadedHeadgear.Size = new System.Drawing.Size(70, 15);
            this.LabelLoadedHeadgear.TabIndex = 29;
            this.LabelLoadedHeadgear.Text = "Headgear: 0";
            // 
            // LabelLoadedClothes
            // 
            this.LabelLoadedClothes.AutoSize = true;
            this.LabelLoadedClothes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelLoadedClothes.Location = new System.Drawing.Point(40, 149);
            this.LabelLoadedClothes.Name = "LabelLoadedClothes";
            this.LabelLoadedClothes.Size = new System.Drawing.Size(59, 15);
            this.LabelLoadedClothes.TabIndex = 30;
            this.LabelLoadedClothes.Text = "Clothes: 0";
            // 
            // LabelLoadedShoes
            // 
            this.LabelLoadedShoes.AutoSize = true;
            this.LabelLoadedShoes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelLoadedShoes.Location = new System.Drawing.Point(49, 164);
            this.LabelLoadedShoes.Name = "LabelLoadedShoes";
            this.LabelLoadedShoes.Size = new System.Drawing.Size(50, 15);
            this.LabelLoadedShoes.TabIndex = 31;
            this.LabelLoadedShoes.Text = "Shoes: 0";
            // 
            // GearName
            // 
            this.GearName.Location = new System.Drawing.Point(313, 35);
            this.GearName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.GearName.Name = "GearName";
            this.GearName.ReadOnly = true;
            this.GearName.Size = new System.Drawing.Size(132, 23);
            this.GearName.TabIndex = 33;
            // 
            // LabelGearName
            // 
            this.LabelGearName.AutoSize = true;
            this.LabelGearName.Location = new System.Drawing.Point(237, 38);
            this.LabelGearName.Name = "LabelGearName";
            this.LabelGearName.Size = new System.Drawing.Size(69, 15);
            this.LabelGearName.TabIndex = 32;
            this.LabelGearName.Text = "Gear Name:";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 308);
            this.Controls.Add(this.GearName);
            this.Controls.Add(this.LabelGearName);
            this.Controls.Add(this.LabelLoadedShoes);
            this.Controls.Add(this.LabelLoadedClothes);
            this.Controls.Add(this.LabelLoadedHeadgear);
            this.Controls.Add(this.GearSubAbility3);
            this.Controls.Add(this.LabelGearSubAbility3);
            this.Controls.Add(this.GearSubAbility2);
            this.Controls.Add(this.LabelGearSubAbility2);
            this.Controls.Add(this.GearSubAbility1);
            this.Controls.Add(this.LabelGearSubAbility1);
            this.Controls.Add(this.GearPrimaryAbility);
            this.Controls.Add(this.LabelGearPrimaryAbility);
            this.Controls.Add(this.GearSlots);
            this.Controls.Add(this.LabelGearSlots);
            this.Controls.Add(this.LabelIndex);
            this.Controls.Add(this.ButtonNext);
            this.Controls.Add(this.ButtonPrevious);
            this.Controls.Add(this.GearRarity);
            this.Controls.Add(this.LabelGearRarity);
            this.Controls.Add(this.GearSeed);
            this.Controls.Add(this.LabelGearSeed);
            this.Controls.Add(this.GearID);
            this.Controls.Add(this.LabelGearID);
            this.Controls.Add(this.GearBrand);
            this.Controls.Add(this.LabelGearBrand);
            this.Controls.Add(this.LabelLoadedGear);
            this.Controls.Add(this.ButtonDumpGear);
            this.Controls.Add(this.ButtonDisconnect);
            this.Controls.Add(this.ButtonConnect);
            this.Controls.Add(this.ConnectionStatusText);
            this.Controls.Add(this.InputSwitchIP);
            this.Controls.Add(this.LabelStatus);
            this.Controls.Add(this.LabelSwitchIP);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainWindow";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelSwitchIP;
        private System.Windows.Forms.Label LabelStatus;
        private System.Windows.Forms.TextBox InputSwitchIP;
        private System.Windows.Forms.Label ConnectionStatusText;
        private System.Windows.Forms.Button ButtonConnect;
        private System.Windows.Forms.Button ButtonDisconnect;
        private Button ButtonDumpGear;
        private Label LabelLoadedGear;
        private Label LabelGearBrand;
        private TextBox GearBrand;
        private TextBox GearID;
        private Label LabelGearID;
        private TextBox GearRarity;
        private Label LabelGearRarity;
        private TextBox GearSeed;
        private Label LabelGearSeed;
        private Button ButtonPrevious;
        private Button ButtonNext;
        private Label LabelIndex;
        private TextBox GearSlots;
        private Label LabelGearSlots;
        private TextBox GearPrimaryAbility;
        private Label LabelGearPrimaryAbility;
        private TextBox GearSubAbility1;
        private Label LabelGearSubAbility1;
        private TextBox GearSubAbility2;
        private Label LabelGearSubAbility2;
        private TextBox GearSubAbility3;
        private Label LabelGearSubAbility3;
        private Label LabelLoadedHeadgear;
        private Label LabelLoadedClothes;
        private Label LabelLoadedShoes;
        private TextBox GearName;
        private Label LabelGearName;
    }
}

