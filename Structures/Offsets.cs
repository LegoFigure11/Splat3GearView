namespace Splat3GearView.Structures
{
    internal class Offsets
    {
        private const uint GearList_Offs = 0x2C020;
        public const uint GearList_Head = 0xBCD55B30;
        public const uint GearList_Clothes = GearList_Head + GearList_Offs;
        public const uint GearList_Shoes = GearList_Clothes + GearList_Offs;

        public const uint GachaBlock = 0xBCE3B998;
    }
}