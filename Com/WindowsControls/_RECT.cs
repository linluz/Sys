using System.Runtime.InteropServices;

namespace Sys.Com.WindowsControls
{
    /// <summary>
    /// 像素矩形坐标定义，与库重复
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int Left;
        public int Top;

        public int Right;
        public int Bottom;
    }
}
