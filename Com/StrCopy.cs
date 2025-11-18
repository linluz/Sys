using System.Runtime.InteropServices;
using System.Text;

namespace Sys.Com
{
    public class StrCopy
    {
        /// <summary>
        /// 将字符串复制到缓冲区。ascii
        /// </summary>
        /// <param name="lpString1">一个缓冲区，用于接收 lpString2 参数指向的字符串的内容。 缓冲区必须足够大才能包含字符串，包括终止 null 字符。</param>
        /// <param name="lpString2">要复制的以 null 结尾的字符串。</param>
        /// <returns>如果函数成功，则返回值是指向缓冲区的指针。
        /// 如果函数失败，则返回值为 NULL ， lpString1 可能不会以 null 结尾。
        /// </returns>
        /// <remarks> cswin32无,metedata有</remarks>
        [Obsolete("请勿使用。 请考虑改用 StringCchCopy ")]
        public static byte[] lstrcpy(out byte[] lpString1, byte[] lpString2)
        {
            //lpString1 = new byte[lpString2.Length];
            //unsafe
            //{
            //    fixed (byte* b1= lpString1)
            //    {
            //        fixed (byte* b2 = lpString2)
            //        {
            //            return NativeMethods.lstrcpyA(b1, b2).AsSpan().ToArray();
            //        }
            //    }
            //}
            throw new NotImplementedException();
        }

        /// <summary>
        /// 将字符串复制到缓冲区。w
        /// </summary>
        /// <param name="lpString1">一个缓冲区，用于接收 lpString2 参数指向的字符串的内容。 缓冲区必须足够大才能包含字符串，包括终止 null 字符。</param>
        /// <param name="lpString2">要复制的以 null 结尾的字符串。</param>
        /// <returns>如果函数成功，则返回值是指向缓冲区的指针。
        /// 如果函数失败，则返回值为 NULL ， lpString1 可能不会以 null 结尾。
        /// </returns>
        /// <remarks> cswin32无,metedata有</remarks>
        public static IntPtr lstrcpy(out string lpString1, string lpString2)
        {
            unsafe
            {
                fixed (char* b2 = lpString2)
                {
                    PWSTR str = lpString2.Length.GetStrBuffer();
                    var resu = NativeMethods.lstrcpyW(str, b2);
                    lpString1 = str.ToString();
                    return (IntPtr)resu.Value;
                }
            }
        }
        /// <summary>
        /// 将一个字符串复制到另一个字符串。 向函数提供目标缓冲区的大小，以确保它不会写入此缓冲区的末尾。
        /// </summary>
        /// <param name="pszDest">接收复制字符串的目标缓冲区。</param>
        /// <param name="pszSrc">源字符串。 此字符串必须以 null 结尾。</param>
        /// <returns>此函数可以返回以下值之一。 强烈建议使用 SUCCEEDED 和 FAILED 宏来测试此函数的返回值。</returns>
        /// <remarks>CSWIN32与metadata都无</remarks>
        public static int stringCchCopy(out StringBuilder pszDest, string pszSrc)
            => NativeMethods.stringCchCopy(pszDest = new StringBuilder(pszSrc.Length + 1), pszSrc.Length + 1, pszSrc);

        private static class NativeMethods
        {
            [DllImport("KERNEL32.dll", ExactSpelling = true, PreserveSig = false)]
            public static extern PSTR lstrcpyA([Out] PSTR lpString1, [In] PSTR lpString2);
            /// <summary>
            /// https://learn.microsoft.com/windows/win32/api/winbase/nf-winbase-lstrcpyw
            /// </summary>
            /// <param name="lpString1"></param>
            /// <param name="lpString2"></param>
            /// <returns></returns>
            [DllImport("KERNEL32.dll", ExactSpelling = true, PreserveSig = false)]
            public static extern PWSTR lstrcpyW([Out] PWSTR lpString1, [In] PWSTR lpString2);
            /// <summary>
            /// 将一个字符串复制到另一个字符串。 向函数提供目标缓冲区的大小，以确保它不会写入此缓冲区的末尾。
            /// </summary>
            /// <param name="pszDest">接收复制字符串的目标缓冲区。</param>
            /// <param name="cchDest">目标缓冲区的大小（以字符为单位）。 此值必须等于 pszSrc 的长度加 1，以解释复制的源字符串和终止 null 字符。 允许的最大字符数是 STRSAFE_MAX_CCH。</param>
            /// <param name="pszSrc">源字符串。 此字符串必须以 null 结尾。</param>
            /// <returns>此函数可以返回以下值之一。 强烈建议使用 SUCCEEDED 和 FAILED 宏来测试此函数的返回值。</returns>
            [DllImport("kernel32.dll", EntryPoint = "stringCchCopyA", CharSet = CharSet.Ansi, SetLastError = true)]
            public static extern int stringCchCopy(
                [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszDest,
                int cchDest,
                [MarshalAs(UnmanagedType.LPWStr)] string pszSrc
            );
        }
    }
}
