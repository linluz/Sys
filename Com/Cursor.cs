using System.Runtime.Versioning;
using Point = System.Drawing.Point;

namespace Sys.Com
{
    [SupportedOSPlatform("windows6.0")]
    public static partial class CommonMethod
    {
        /// <summary>
        /// 获取光标的屏幕位置
        /// </summary>
        /// <param name="lpPoint"></param>
        /// <returns></returns>
        public static bool GetCursorPos(out Point lpPoint) 
            => PInvoke.GetCursorPos(out lpPoint);

        /// <summary>
        /// 将光标移动到指定的屏幕坐标。
        /// 如果新坐标不在由最近的 ClipCursor 函数调用设置的屏幕矩形内，则系统会自动调整坐标，使光标停留在矩形内。
        /// </summary>
        /// <param name="x">光标的新 x 坐标（以屏幕坐标为单位）。</param>
        /// <param name="y">光标的新 x 坐标（以屏幕坐标为单位）。</param>
        /// <returns></returns>
        public static bool SetCursorPos(int x, int y)
            => PInvoke.SetCursorPos(x, y);


        /// <summary>
        /// 转换屏幕光标坐标为工作区坐标
        /// </summary>
        /// <param name="hwnd">窗口句柄</param>
        /// <param name="lpPoint">指向 POINT 结构的指针，该结构指定要转换的屏幕坐标。</param>
        /// <returns></returns>
        internal static bool ScreenToClient(HWND hwnd, ref Point lpPoint) 
            => PInvoke.ScreenToClient(hwnd, ref lpPoint);

        /// <summary>
        /// 转换工作区光标坐标为屏幕坐标
        /// </summary>
        /// <param name="hwnd">窗口句柄</param>
        /// <param name="lpPoint">指向 POINT 结构的指针，该结构包含要转换的客户端坐标。 如果函数成功，则新的屏幕坐标将复制到此结构中。</param>
        /// <returns></returns>
        internal static bool ClientToScreen(HWND hwnd, ref Point lpPoint)
            => PInvoke.ClientToScreen(hwnd, ref lpPoint);
    }
}
