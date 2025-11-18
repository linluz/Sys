using System.Runtime.Versioning;
using Windows.Win32.Foundation;
using Windows.Win32.Globalization;
using Sys.Enum;

namespace Sys.Com.String.CodePage
{
    /// <summary>
    /// 代码页转换
    /// todo 数组转换 或代码页转换 改成使用 System.Text.Encoding.GetBytes()
    /// </summary>
    [SupportedOSPlatform("windows6.0")]
    public static class CodePageMethod
    {
        #region NativeMethods

        /// <summary>
        /// 使用 MultiByteToWideChar 函数将多字节字符串转换为宽字符字符串
        /// </summary>
        /// <param name="codePage">代码页</param>
        /// <param name="dwFlags">标志位</param>
        /// <param name="lpMultiByteStr">多字节字符串</param>
        /// <param name="lpWideCharStr">宽字符字符串的缓冲区</param>
        /// <param name="cchWideChar">宽字符字符串的缓冲区长度</param>
        /// <returns>转换后的宽字符字符串的长度</returns>
        public static int MultiByteToWideChar(KnownCodePage codePage, uint dwFlags, byte[] lpMultiByteStr,
            out string lpWideCharStr, int cchWideChar)
        {
            unsafe
            {
                fixed (byte* b = lpMultiByteStr)
                {
                    var ccstr = (PCSTR)b;
                    PWSTR str = cchWideChar.GetStrBuffer();
                    var resu = PInvoke.MultiByteToWideChar((uint)codePage, (MULTI_BYTE_TO_WIDE_CHAR_FLAGS)dwFlags,
                        ccstr, lpMultiByteStr.Length + 1, str, cchWideChar);
                    lpWideCharStr = str.ToString();
                    return resu;
                }
            }
        }

        /// <summary>
        /// 使用 WideCharToMultiByte 函数将宽字符字符串转换为多字节字符串
        /// </summary>
        /// <param name="codePage">代码页</param>
        /// <param name="dwFlags">标志位</param>
        /// <param name="lpWideCharStr">宽字符字符串</param>
        /// <param name="lpMultiByteStr">多字节字符串的缓冲区</param>
        /// <param name="cchMultiByte">多字节字符串的缓冲区长度</param>
        /// <param name="lpUsedDefaultChar">是否使用了默认字符</param>
        /// <param name="lpDefaultChar">若代码页中无对应字符时，使用此字符。默认为null，且CP_UTF7 和 CP_UTF8必须使用null，否则报错</param>
        /// <returns>转换后的多字节字符串的长度</returns>
        public static int WideCharToMultiByte(
            KnownCodePage codePage,
            uint dwFlags,
            string lpWideCharStr,
            out byte[] lpMultiByteStr,
            int cchMultiByte,
            out bool lpUsedDefaultChar,
            char? lpDefaultChar = null)
        {
            if (lpDefaultChar != null && codePage is KnownCodePage.CP_UTF8 or KnownCodePage.CP_UTF7)
                throw new ArgumentException($"{nameof(codePage)}为 CP_UTF7 或 CP_UTF8 时{nameof(lpDefaultChar)}必须w为null");
            lpUsedDefaultChar = false;
            lpMultiByteStr = new byte[cchMultiByte];
            unsafe
            {
                fixed (byte* b = lpMultiByteStr)
                {
                    fixed (bool* bl =  &lpUsedDefaultChar)
                    {
                        return PInvoke.WideCharToMultiByte((uint)codePage, dwFlags, lpWideCharStr,
                            lpWideCharStr.Length + 1, b, cchMultiByte, lpDefaultChar?.ToString(), (BOOL*)bl);
                    }
                }
            }
        }

        /// <summary>
        /// 获取当前系统的 ANSI 代码页
        /// </summary>
        /// <returns>当前系统的 ANSI 代码页</returns>
        public static KnownCodePage GetACP()
            => (KnownCodePage)PInvoke.GetACP();

        /// <summary>
        /// 将指定代码页的信息复制到 CPINFOEX 结构中。
        /// </summary>
        /// <param name="codePage">代码页标识符</param>
        /// <param name="cie">将信息复制到的 CPINFOEX 结构</param>
        /// <returns>成功获取信息返回 true，否则返回 false</returns>
        public static bool GetCPInfoEx(KnownCodePage codePage,out CpInfoEx cie)
        {
            unsafe
            {
                fixed (CpInfoEx* p = &cie)
                {
                     return PInvoke.GetCPInfoEx((uint)(int)codePage, 0, (CPINFOEXW*)p);
                }
            }
        }

        /// <summary>
        /// 获取指定代码页的信息，若失败则抛出异常。针对mac 当前线程等奇怪的代码页
        /// </summary>
        /// <param name="codePage"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static KnownCodePage GetCP(this KnownCodePage codePage) 
            => GetCPInfoEx(codePage, out var cie) ? (KnownCodePage)cie.CodePage : throw new Exception($"输入的代码页无法获得代码页信息,错误代码：{ErrMethod.GetLastError()}");

        /// <summary>
        /// 获取指定区域设置的信息。
        /// </summary>
        /// <param name="locale">区域设置标识符</param>
        /// <param name="lcType">信息类型</param>
        /// <param name="lpLcData">缓冲区,若cchData为0，输出空字串</param>
        /// <param name="cchData">缓冲区长度,如为0，则只返回必要的缓冲区长度，不使用缓冲区</param>
        /// <returns>返回值表示成功获取的信息长度</returns>
        [Obsolete("替换为 System.Globalization.CultureInfo.CurrentCulture")] 
        public static int GetLocaleInfo(int locale, LOCALE lcType, out string lpLcData, int cchData)
        {
            lpLcData = "";
            unsafe
            {
                PWSTR str = cchData.GetStrBuffer();
                try
                {
                    var resu = PInvoke.GetLocaleInfo((uint)locale, (uint)lcType, str, cchData);
                    if (cchData != 0) lpLcData = str.ToString();
                    return resu;
                }
                finally
                {
                    str.Free();//由于不一定用到，所以手动释放以防万一
                }
            }
        }

        //private static class NativeMethods
        //{
        //    [DllImport("kernel32.dll")]
        //    private static extern int MultiByteToWideChar(
        //        KnownCodePage codePage,
        //        uint dwFlags,
        //        [MarshalAs(UnmanagedType.LPArray)] byte[] lpMultiByteStr,
        //        int cchMultiByte,
        //        [Out, MarshalAs(UnmanagedType.LPArray)] byte[] lpWideCharStr,
        //        int cchWideChar);
        //    [DllImport("kernel32.dll")]
        //    private static extern int WideCharToMultiByte(
        //        KnownCodePage codePage,
        //        uint dwFlags,
        //        [MarshalAs(UnmanagedType.LPArray)] byte[] lpWideCharStr,
        //        int cchWideChar,
        //        [Out, MarshalAs(UnmanagedType.LPArray)] byte[] lpMultiByteStr,
        //        int cchMultiByte,
        //        IntPtr lpDefaultChar,
        //        out bool lpUsedDefaultChar);
        //    [DllImport("kernel32.dll")]
        //    public static extern KnownCodePage GetACP();
        //    [DllImport("kernel32.dll")]
        //    public static extern int GetLocaleInfo(int locale, LOCALE lcType, StringBuilder lpLcData, int cchData);
        //}

        #endregion

    }
}
