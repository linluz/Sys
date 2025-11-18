using System.Runtime.InteropServices;

namespace Sys.Com.Time
{
    /// <summary>
    /// 表示文件时间的结构体
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct FILETIME
    {
        /// <summary>
        /// 文件时间的低32位
        /// </summary>
        public uint dwLowDateTime;

        /// <summary>
        /// 文件时间的高32位
        /// </summary>
        public uint dwHighDateTime;
    }
}
