using Splat3GearView.Resources;
using static System.Buffers.Binary.BinaryPrimitives;

namespace Splat3GearView.Structures
{
    public partial class Gear
    {
        public const byte SIZE = 0xB0;

        public readonly byte[] Data; // Raw data
        public Gear(byte[] data) => Data = data;
        public Gear(int size) => Data = new byte[size];

        public virtual bool IsValid { get => Validate(); } // Does this look like a piece of gear

        public virtual byte GearType { get; set; }

        public virtual ushort ID { get => ReadUInt16LittleEndian(Data.AsSpan(0x00)); }
        public virtual ushort EXP { get => ReadUInt16LittleEndian(Data.AsSpan(0x48)); }
        public virtual byte Rarity { get => Data[0x50]; }
        public virtual byte Ability_Primary { get => Data[0x54]; }
        public virtual byte Ability_SubCount { get => Data[0x68]; }
        public virtual byte Ability_Sub1 { get => Data[0x6C]; }
        public virtual byte Ability_Sub2 { get => Data[0x70]; }
        public virtual byte Ability_Sub3 { get => Data[0x74]; }
        public virtual uint Seed { get => ReadUInt32LittleEndian(Data.AsSpan(0x80)); }

        // Derived Values
        public virtual string? Name { get; set; }
        public virtual string? Brand { get; set; }

        // Methods
        private bool Validate()
        {
            if (ID == 0) return false;
            if (Rarity > 5) return false;
            if (Ability_SubCount > Rarity + 1) return false;
            if (
                Ability_Primary > (byte)Abilities.DropRoller ||
                Ability_Sub1 > (byte)Abilities.IntensifyAction ||
                Ability_Sub2 > (byte)Abilities.IntensifyAction ||
                Ability_Sub3 > (byte)Abilities.IntensifyAction
                ) return false;
            if (Seed == 0) return false;
            return true;
        }

        public void SetInfoFromJSON()
        {
            GearDataFromJSON g = GearData.FindGear(ID, GearType);
            Brand = GearData.MasterBrands[g.Brand!]!.GetValue<string>();
            if (GearType == (byte)GearTypes.Headgear)
                Name = GearData.MasterHeadgear[g.MasterID!]!.GetValue<string>();
            else if (GearType == (byte)GearTypes.Clothes)
                Name = GearData.MasterClothes[g.MasterID!]!.GetValue<string>();
            else Name = GearData.MasterShoes[g.MasterID!]!.GetValue<string>();
        }
    }
}
