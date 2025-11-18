using System.Runtime.Versioning;

namespace Sys.Com
{
    [SupportedOSPlatform("windows6.0")]
    public static class VersionInfoMethod
    {
        //private static class NativeMethods
        //{
        //    [DllImport("kernel32.dll")]
        //    public static extern bool GetVersionEx(ref OSVERSIONINFO lpVersionInformation);
        //}
        /// <summary>
        /// 获取系统版本信息
        /// </summary>
        /// <param name="lpVersionInformation">接收操作系统信息的 OSVERSIONINFO 或 OSVERSIONINFOEX 结构。
        /// 在调用 GetVersionEx 函数之前，请根据需要设置结构的 dwOSVersionInfoSize 成员，以指示要传递给此函数的数据结构。</param>
        /// <returns></returns>
        /// <remarks>注意 bas上使用的是FormatMessageA 但此处只有FormatMessageW</remarks>
        internal static bool GetVersionEx(ref OSVERSIONINFOW lpVersionInformation)
            => PInvoke.GetVersionEx(ref lpVersionInformation);
        #region 文件版本信息

        /// <summary>
        /// 获取文件版本信息
        /// </summary>
        /// <param name="lptstrFilename">文件名</param>
        /// <param name="dwlen">lpData 参数指向的缓冲区的大小（以字节为单位）。</param>
        /// <param name="lpData">返回的数据缓冲区指针,用完后必须使用Free方法释放</param>
        /// <returns>是否成功</returns>
        public static bool GetFileVersionInfo(string lptstrFilename, uint dwlen, out IntPtr lpData)
        {
            unsafe
            {
                lpData = ((int)dwlen).GetBuffer();
                return PInvoke.GetFileVersionInfo(lptstrFilename, dwlen, lpData.ToPointer());
            }
        }

        /// <summary>
        /// 获取文件版本信息大小
        /// </summary>
        /// <param name="lptstrFilename">文件名</param>
        /// <param name="lpdwHandle">指向函数设置为零的变量的指针。</param>
        /// <returns>如果函数成功，则返回值为文件版本信息的大小（以字节为单位）。
        /// 如果函数失败，则返回值为零。</returns>
        public static uint GetFileVersionInfoSize(string lptstrFilename, out uint lpdwHandle)
        {
            unsafe
            {
                fixed (uint* p = &lpdwHandle)
                {
                    return PInvoke.GetFileVersionInfoSize(lptstrFilename, p);
                }
            }
        }

        /// <summary>
        /// 查询版本信息
        /// </summary>
        /// <param name="pBlock">GetFileVersionInfo 函数返回的版本信息资源。</param>
        /// <param name="lpSubBlock">要检索的版本信息值。 字符串必须由反斜杠 (\) 分隔的名称组成</param>
        /// <param name="lplpBuffer">此方法返回时，包含 指向 pBlock 指向的缓冲区中请求的版本信息的指针的地址。</param>
        /// <param name="puLen">
        /// <para>对于版本信息值，为存储在 lplpBuffer 处的字符串的长度（以字符为单位）;</para>
        /// <para>对于转换数组值，则为存储在 lplpBuffer 处的数组的大小（以字节为单位）;</para>
        /// <para>对于根块，则为 结构的大小（以字节为单位）。</para>
        /// </param>
        /// <returns>是否成功</returns>
        public static bool VerQueryValue(IntPtr pBlock, string lpSubBlock, out IntPtr lplpBuffer, out uint puLen)
        {
            unsafe
            {
                var resu = PInvoke.VerQueryValue(pBlock.ToPointer(), lpSubBlock, out var p, out puLen);
                lplpBuffer = (IntPtr)p;
                return resu;
            }
        }
        /// <summary>
        /// 查询版本信息字串
        /// </summary>
        /// <param name="pBlock">GetFileVersionInfo 函数返回的版本信息资源。</param>
        /// <param name="lpSubBlock">要检索的版本信息值。 字符串必须由反斜杠 (\) 分隔的名称组成</param>
        /// <param name="value">获得的字串值</param>
        /// <param name="free">是否释放pBlock指针，默认为否，仅当最后一次使用pBlock时才应该设置为真，否则会导致后续调用报错</param>
        /// <returns></returns>
        public static bool VerQueryString(IntPtr pBlock, string lpSubBlock, out string value, bool free = false)
        {
            unsafe
            {
                try
                {
                    var resu = PInvoke.VerQueryValue(pBlock.ToPointer(), lpSubBlock, out var p, out var puLen);
                    value = new string((char*)p, 0, (int)puLen);
                    return resu;
                }
                finally
                {
                    if (free) pBlock.Free();
                }
            }
        }
        #endregion

        //private static partial class NativeMethods
        //{
        //[DllImport("Version.dll", EntryPoint = "GetFileVersionInfoA", CharSet = CharSet.Auto, SetLastError = true)]
        //internal static extern bool GetFileVersionInfo(string lptstrFilename, int dwhandle, int dwlen, [Out] IntPtr lpData);
        //[DllImport("Version.dll", EntryPoint = "GetFileVersionInfoSizeA", CharSet = CharSet.Auto, SetLastError = true)]
        //internal static extern int GetFileVersionInfoSize(string lptstrFilename, [Out, Optional] IntPtr lpdwHandle);
        //[DllImport("Version.dll", EntryPoint = "VerQueryValueA", CharSet = CharSet.Auto, SetLastError = true)]
        //internal static extern bool VerQueryValue(IntPtr pBlock, string lpSubBlock, [Out] IntPtr lplpBuffer, [Out] int puLen);
        //}
    }
}
