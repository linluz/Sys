namespace Sys.Com.String.DelphiString
{
    /// <summary>
    /// UnicodeString	可以容纳2的30次方个字符,D2009及以后的默认String类型
    /// </summary>
    public struct DELPHI_UNICODE_STRING
    {
        /// <summary>
        /// 字符串代码页，2个字节，支持 Unicode, UTF-8, ANSI
        /// </summary>
        public short CodePage;
        /// <summary>
        /// 每个字符的字节数，2个字节，Unicode = 2, UTF-8 = 1 or 3, GB2312 = 2
        /// </summary>
        public short elemSize;
        /// <summary>
        /// 字符串引用次数，4个字节
        /// </summary>
        public int RefCount;
        /// <summary>
        /// 字符串的字符数，4个字节
        /// </summary>
        public int Length;
        ///// <summary>
        ///// 字符串，字节长度为 Length * elemSize
        ///// </summary>
        //public byte[] Strings;
        ///// <summary>
        ///// 以0x0000结束
        ///// </summary>
        //MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        //public short[] EndChar;
    }
}
