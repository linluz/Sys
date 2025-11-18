namespace Sys.Com.String
{
    /// <summary>
    /// 字串长度判断值定义
    /// </summary>
    public struct STRING_TYPE_LENGTH
    {
        /// <summary>
        /// 正则表达式模板
        /// </summary>
        public string Pattern;
        /// <summary>
        /// 首个长度判断值
        /// </summary>
        public long Length1;
        /// <summary>
        /// 次个长度判断值
        /// </summary>
        public long Length2;
        /// <summary>
        /// 长度大小判断值
        /// </summary>
        public long Size;
        /// <summary>
        /// 长度的字节数组
        /// </summary>
        public byte[] Bytes;
        /// <summary>
        /// 字节序
        /// </summary>
        public ByteOrderType ByteOrder;
    }
    public enum ByteOrderType
    {
        /// <summary>
        /// 大端在前
        /// </summary>
        BigEndian = -1,
        /// <summary>
        /// 小端在前
        /// </summary>
        LittleEndian = 0,
        /// <summary>
        /// 未知
        /// </summary>
        Unknown = 1
    }
}
