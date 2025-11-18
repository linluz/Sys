using System.Runtime.InteropServices;

namespace Sys.Com.Time
{
    /// <summary>
    /// 表示系统时间的结构体
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SYSTEMTIME
    {
        /// <summary>
        /// 年份
        /// </summary>
        public ushort wYear;

        /// <summary>
        /// 月份
        /// </summary>
        public ushort wMonth;

        /// <summary>
        /// 星期几
        /// </summary>
        public ushort wDayOfWeek;

        /// <summary>
        /// 日期
        /// </summary>
        public ushort wDay;

        /// <summary>
        /// 小时
        /// </summary>
        public ushort wHour;

        /// <summary>
        /// 分钟
        /// </summary>
        public ushort wMinute;

        /// <summary>
        /// 秒
        /// </summary>
        public ushort wSecond;

        /// <summary>
        /// 毫秒
        /// </summary>
        public ushort wMilliseconds;
    }
}
