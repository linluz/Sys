namespace Sys.Com.String.DelphiString
{
    /// <summary>
    /// ShortString		可以容纳255个字符,主要为了老版本兼容
    /// </summary>
    public struct DELPHI_SHORT_STRING
    {
        /// <summary>
        /// 字符串字节长度，1个字节
        /// </summary>
        public byte Length;
        ///// <summary>
        ///// 字符串，字节长度为 Length * 1
        ///// </summary>
        //public byte[] Strings;
        ///// <summary>
        ///// 不一定以0x00结束
        ///// </summary>
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        //public byte[] EndChar;
    }
}
