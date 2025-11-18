namespace Sys.Com.String.DelphiString
{
    /// <summary>
    /// AnsiString		可以容纳2的31次方个字符,D2009前默认的String类型
    /// </summary>
    public struct DELPHI_ANSI_STRING
    {
        /// <summary>
        /// 字符串引用次数，4个字节
        /// </summary>
        public int RefCount;
        /// <summary>
        /// 字符串字节长度，4个字节
        /// </summary>
        public int Length;
        ///// <summary>
        ///// 字符串，字节长度为 Length * 1
        ///// </summary>
        //public byte[] Strings;
        ///// <summary>
        ///// 以0x00结束
        ///// </summary>
        //MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        //public byte[] EndChar;
    }
}
