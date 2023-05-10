using static System.Buffers.Binary.BinaryPrimitives;

namespace Splat3GearView.Structures
{
    public partial class GachaSeed
    {
        public static uint NORMAL_KEY = 0x55663B19;
        public static uint FEST_KEY = 0xA00259CF;
        public static uint MURCH_KEY = 0xCCC5FFFB;
        public static uint STRUCT_SIZE = 0x80;
        public static uint SEED_OFFSET = 0x48;
        public static byte SEED_SIZE = 0x10;
        public static uint SIZE = 0x880;

        public readonly byte[] Data; // Raw data
        public GachaSeed(byte[] data) => Data = data;
        public GachaSeed(int size) => Data = new byte[size];

        public virtual uint s0 { get => ReadUInt32LittleEndian(Data.AsSpan(0x00)); }
        public virtual uint s1 { get => ReadUInt32LittleEndian(Data.AsSpan(0x04)); }
        public virtual uint s2 { get => ReadUInt32LittleEndian(Data.AsSpan(0x08)); }
        public virtual uint s3 { get => ReadUInt32LittleEndian(Data.AsSpan(0x0C)); }
    }
}
