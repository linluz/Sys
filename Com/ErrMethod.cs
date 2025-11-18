using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace Sys.Com
{
    [SupportedOSPlatform("windows6.0")]
    public static class ErrMethod
    {
        /// <summary>
        /// 获取最近一次发生的错误代码
        /// </summary>
        /// <returns>最近一次发生的错误代码</returns>
        public static int GetLastError() => Marshal.GetLastWin32Error();

        /// <summary>
        /// <see cref="https://learn.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-formatmessage">
        /// 格式化错误消息,注意：lpSource被挪到了倒数第二
        /// </see>
        /// </summary>
        /// <param name="dwFlags">格式化选项</param>
        /// <param name="lpSource">消息源</param>
        /// <param name="dwMessageId">消息标识符</param>
        /// <param name="dwLanguageId">语言标识符</param>
        /// <param name="lpBuffer">接收格式化消息的缓冲区</param>
        /// <param name="nSize">缓冲区大小</param>
        /// <param name="arguments">可变参数</param>
        /// <returns>格式化的错误消息的长度</returns>
        internal static uint FormatMessage(FORMAT_MESSAGE_OPTIONS dwFlags, uint dwMessageId, uint dwLanguageId,
            out string lpBuffer, uint nSize, IntPtr lpSource = default, params IntPtr[] arguments)
        {
            unsafe
            {
                var sa = new sbyte*[arguments.Length];
                for (var i = 0; i < sa.Length; i++)
                    sa[i] = (sbyte*)arguments[i];

                fixed (sbyte** arg = sa)
                {
                    PWSTR str = ((int)nSize).GetStrBuffer();
                    var result = PInvoke.FormatMessage(dwFlags, lpSource.ToPointer(), dwMessageId, dwLanguageId, str, nSize,
                        arg);
                    lpBuffer = str.ToString();
                    return result;
                }
            }
        }

        //private static class NativeMethods
        //{
        //    [DllImport("kernel32.dll")]
        //    // ReSharper disable once MemberHidesStaticFromOuterClass
        //    internal static extern int GetLastError();
        //    [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        //    internal static extern uint FormatMessage(FormatMessageFlags dwFlags, [Optional] IntPtr lpSource,
        //        uint dwMessageId, uint dwLanguageId, [Out] StringBuilder lpBuffer, int nSize,
        //        [Optional] IntPtr[] arguments);
        //}

        /// <summary>
        /// 获取错误消息
        /// </summary>
        /// <param name="lpSource"></param>
        /// <param name="dwError"></param>
        public static unsafe string GetError(string lpSource, int dwError)
        {
            fixed (char* ip = lpSource)
            {
                FormatMessage(
                    FORMAT_MESSAGE_OPTIONS.FORMAT_MESSAGE_FROM_SYSTEM | FORMAT_MESSAGE_OPTIONS.FORMAT_MESSAGE_IGNORE_INSERTS,
                    (uint)dwError, 0, out var getLastDllErrMsg, 256,
                    (IntPtr)ip);
                return getLastDllErrMsg;
            }
        }
    }

}