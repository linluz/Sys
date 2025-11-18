using System.Runtime.Versioning;

namespace Sys.Com.Time
{
    [SupportedOSPlatform("windows6.0")]
    public static class TimeMethod
    {
        /// <summary>
        /// 设置文件的创建时间、最后访问时间和最后写入时间
        /// </summary>
        /// <param name="hFile">文件句柄</param>
        /// <param name="lpCreationTime">创建时间</param>
        /// <param name="lpLastAccessTime">最后访问时间</param>
        /// <param name="lpLastWriteTime">最后写入时间</param>
        /// <returns>如果设置成功，则为 true；否则为 false。</returns>
        private static bool SetFileTime(System.Runtime.InteropServices.SafeHandle hFile, FILETIME? lpCreationTime, FILETIME? lpLastAccessTime,
             FILETIME? lpLastWriteTime)
            => PInvoke.SetFileTime(hFile, lpCreationTime, lpLastAccessTime, lpLastWriteTime);

        /// <summary>
        /// 将本地时间转换为文件时间
        /// </summary>
        /// <param name="lpLocalFileTime">本地时间</param>
        /// <param name="lpFileTime">文件时间</param>
        /// <returns>如果转换成功，则为 true；否则为 false。</returns>
        private static bool LocalFileTimeToFileTime(in FILETIME lpLocalFileTime, out FILETIME lpFileTime)
            => PInvoke.LocalFileTimeToFileTime(in lpLocalFileTime, out lpFileTime);

        /// <summary>
        /// 将系统时间转换为文件时间
        /// </summary>
        /// <param name="lpSystemTime">系统时间</param>
        /// <param name="lpFileTime">文件时间</param>
        /// <returns>如果转换成功，则为 true；否则为 false。</returns>
        private static bool SystemTimeToFileTime(in SYSTEMTIME lpSystemTime, out FILETIME lpFileTime)
            => PInvoke.SystemTimeToFileTime(in lpSystemTime, out lpFileTime);

        //private static class NativeMethods
        //{
        //    [DllImport("kernel32.dll", SetLastError = true)]
        //    private static extern bool SetFileTime(IntPtr hFile, ref FILETIME lpCreationTime, ref FILETIME lpLastAccessTime, ref FILETIME lpLastWriteTime);
        //    [DllImport("kernel32.dll", SetLastError = true)]
        //    private static extern bool LocalFileTimeToFileTime(ref FILETIME lpLocalFileTime, ref FILETIME lpFileTime);
        //    [DllImport("kernel32.dll", SetLastError = true)]
        //    private static extern bool SystemTimeToFileTime(ref SYSTEMTIME lpSystemTime, ref FILETIME lpFileTime);
        //}
    }
}
