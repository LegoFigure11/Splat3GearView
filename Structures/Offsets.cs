namespace Splat3GearView.Structures
{
    internal class Offsets
    {
        public const uint DLC_Offs = 0x3B000;

        private const uint GearList_Offs = 0x2C020;
        public const uint GearList_Head = 0xBA304DD8;
        public const uint GearList_Clothes = GearList_Head + GearList_Offs;
        public const uint GearList_Shoes = GearList_Clothes + GearList_Offs;

        public const uint GachaBlock = 0xBA3FBD28;
    }
}