namespace Sys.Com.String.DelphiString
{
    /// <summary>
    /// WideString		可以容纳2的30次方个字符,主要在COM中用的比较多
    /// </summary>
    public struct DELPHI_WIDE_STRING
    {
        /// <summary>
        /// 字符串字节长度，4个字节
        /// </summary>
        public int Length;
        ///// <summary>
        ///// 字符串，字节长度为 Length * 1
        ///// </summary>
        //public byte[] Strings;
        ///// <summary>
        ///// 以0x0000结束
        ///// </summary>
        //MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        //public short[] EndChar;
    }
}
