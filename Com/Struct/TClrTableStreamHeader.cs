using System.Runtime.InteropServices;

namespace Sys.Com.Struct
{
    /// <summary>
    /// .NET #~流 结构
    /// #~ Stream，保存了与强签名相关的数据
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Size = 24)]
    public struct TClrTableStreamHeader
    {
        /// <summary>
        /// 保留字段，始终为0。
        /// </summary>
        public int Reserved;

        /// <summary>
        /// 元数据表的主版本号，与.NET主版本号一致。
        /// </summary>
        public byte MajorVersion;

        /// <summary>
        /// 元数据表的副版本号，一般为0。
        /// </summary>
        public byte MinorVersion;

        /// <summary>
        /// 堆中定位数据时的索引的大小，为0表示16位索引值。
        /// 若堆中的数据超出16位数据表示范围，则使用32位索引值。
        /// 01h代表strings堆，02h代表GUID堆，04h代表blob堆。
        /// 在#-流中可以为20h或80h，前者代表流中包含在Edit-And-Continue的调试中修改的数据，
        /// 后者表示元数据中个别项被标识为已删除。
        /// </summary>
        public byte HeapSizes;

        /// <summary>
        /// 所有元数据表中记录的最大索引值，在运行时由.NET计算，文件中通常为1。
        /// </summary>
        public byte Rid;

        /// <summary>
        /// 8字节长度的掩码，每个位代表一个表，为1表示该表有效，为0表示无该表。
        /// </summary>
        public long MaskValid;

        /// <summary>
        /// 8字节长度的掩码，每个位代表一个表，为1表示该表已排序，反之为0。
        /// </summary>
        public long Sorted;
    }
}
