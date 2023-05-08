using static System.Buffers.Binary.BinaryPrimitives;

namespace Splat3GearView.Structures
{
    public partial class GachaSeed
    {
        public const byte SIZE = 0x10;

        public readonly byte[] Data; // Raw data
        public GachaSeed(byte[] data) => Data = data;
        public GachaSeed(int size) => Data = new byte[size];

        public virtual uint s0 { get => ReadUInt32LittleEndian(Data.AsSpan(0x00)); }
        public virtual uint s1 { get => ReadUInt32LittleEndian(Data.AsSpan(0x04)); }
        public virtual uint s2 { get => ReadUInt32LittleEndian(Data.AsSpan(0x08)); }
        public virtual uint s3 { get => ReadUInt32LittleEndian(Data.AsSpan(0x0C)); }
    }
}
