using System.Runtime.Versioning;
using Sys.Com.SafeHandle;

namespace Sys.Com.WindowsControls
{
    [Obsolete("替换改写为自带")]
    [SupportedOSPlatform("windows6.0")]
    internal class MenuMethod
    {
        /// <summary>
        /// 创建下拉菜单、子菜单或快捷菜单。 菜单最初为空。 
        /// </summary>
        /// <returns>如果函数成功，则返回值是新创建的菜单的句柄,否则为null</returns>
        public static HMENU CreatePopupMenu()
            => PInvoke.CreatePopupMenu();

        /// <summary>
        /// 将新项追加到指定菜单栏、下拉菜单、子菜单或快捷菜单的末尾。 可以使用此函数指定菜单项的内容、外观和行为。
        /// </summary>
        /// <param name="hMenu">要更改的菜单栏、下拉菜单、子菜单或快捷菜单的句柄。</param>
        /// <param name="uFlags">控制新菜单项的外观和行为。</param>
        /// <param name="uIdNewItem">新菜单项的标识符;如果 uFlags 参数设置为 MF_POPUP，则为下拉菜单或子菜单的句柄。</param>
        /// <param name="lpNewItem">新菜单项的内容，lpNewItem 的解释取决于 uFlags 参数</param>
        /// <returns></returns>
        public static bool AppendMenu(SafeMenuHandle hMenu, MENU_ITEM_FLAGS uFlags, UIntPtr uIdNewItem,
            string lpNewItem)
            => PInvoke.AppendMenu(hMenu, uFlags, uIdNewItem, lpNewItem);

        /// <summary>
        /// 在指定位置显示快捷菜单，并跟踪菜单上项的选择。 快捷菜单可以出现在屏幕上的任意位置。
        /// </summary>
        /// <param name="hMenu">要显示的快捷菜单的句柄。</param>
        /// <param name="uFlags">控制的标志</param>
        /// <param name="x">快捷菜单的水平位置（以屏幕坐标表示）。</param>
        /// <param name="y">快捷菜单的垂直位置（以屏幕坐标表示）。</param>
        /// <param name="hWnd">拥有快捷菜单的窗口的句柄。 此窗口接收来自菜单的所有消息。 </param>
        /// <returns>是否成功。指定了指定TPM_RETURNCMD时，更多效果请看文档</returns>
        public static bool TrackPopupMenu(SafeMenuHandle hMenu, TRACK_POPUP_MENU_FLAGS uFlags, int x, int y, HWND hWnd)
            => PInvoke.TrackPopupMenu(hMenu, uFlags, x, y, hWnd, null);
        
        /// <summary>
        /// 销毁指定的菜单并释放该菜单占用的任何内存。
        /// </summary>
        /// <param name="hMenu"></param>
        /// <returns></returns>
        public static bool DestroyMenu(SafeMenuHandle hMenu)
            => PInvoke.DestroyMenu((HMENU)hMenu);

        /// <summary>
        /// 检索用户前台窗口的句柄。 系统为创建前台窗口的线程分配的优先级略高于其他线程。
        /// </summary>
        /// <returns>前台窗口的句柄</returns>
        public static HWND GetForegroundWindow()
            => PInvoke.GetForegroundWindow();

        /// <summary>
        /// 将指定菜单项的文本字符串复制到指定的缓冲区中。
        /// </summary>
        /// <param name="hMenu">菜单的句柄。</param>
        /// <param name="uIdItem">要更改的菜单项，由 uFlag 参数确定。</param>
        /// <param name="lpString">接收以 null 结尾的字符串的缓冲区。 如果字符串的长度或长度与 lpString 相同，则字符串将被截断，并添加终止 null 字符。 如果 lpString 为 NULL，则该函数返回菜单字符串的长度。</param>
        /// <param name="nMaxCount">要复制的字符串的最大长度（以字符为单位）。 如果字符串的长度超过 nMaxCount 参数中指定的最大值，则会截断额外的字符。 如果 nMaxCount 为 0，则函数返回菜单字符串的长度。</param>
        /// <param name="uFlag">指示如何解释 uIDItem 参数。</param>
        /// <returns>
        /// <para>如果函数成功，则返回值将指定复制到缓冲区的字符数，不包括终止 null 字符。</para>
        /// <para>如果函数失败，则返回值为零。</para>
        /// <para>如果指定的项不是 MIIM_STRING 或 MFT_STRING 类型，则返回值为零。</para>
        /// </returns>
        public static  int GetMenuString(SafeMenuHandle hMenu, uint uIdItem, out string lpString, int nMaxCount, MENU_ITEM_FLAGS uFlag)
        {
            unsafe
            {
                PWSTR str = nMaxCount.GetStrBuffer();
                var resu = PInvoke.GetMenuString(hMenu, uIdItem, str, nMaxCount, uFlag);
                lpString = str.ToString();
                return resu;
            }
        }

        //private static class NativeMethods
        //{
        //    [DllImport("user32.dll")]
        //    public static extern IntPtr CreatePopupMenu();
        //    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        //    public static extern bool AppendMenu(IntPtr hMenu, int uFlags, int uIDNewItem, string lpNewItem);
        //    [DllImport("user32.dll")]
        //    public static extern bool TrackPopupMenu(IntPtr hMenu, int uFlags, int x, int y, int nReserved, IntPtr hWnd, IntPtr prcRect);
        //    [DllImport("user32.dll")]
        //    public static extern bool DestroyMenu(IntPtr hMenu);
        //    [DllImport("user32.dll")]
        //    public static extern IntPtr GetForegroundWindow();
        //    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        //    public static extern int GetMenuString(IntPtr hMenu, int uIDItem, [Out] StringBuilder lpString, int nMaxCount, int uFlag);
        //}
    }
}
