using System.Drawing;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Sys.Com.Att;
using Sys.Com.Key;
using Sys.Com.WindowsControls.Font;

namespace Sys.Com.WindowsControls
{
    [SupportedOSPlatform("windows6.0.6000")]
    public static class WindowsControlsMethod
    {
        #region 用于文本框查找定位函数

        /// <summary>
        /// 向指定的窗口发送消息
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="msg">消息类型</param>
        /// <param name="wParam">消息的附加参数</param>
        /// <param name="lParam">消息的附加参数</param>
        /// <returns>消息处理结果</returns>
        internal static LRESULT SendMessage(HWND hWnd, SendMsgValue msg, WPARAM wParam, LPARAM lParam)
            => NativeMethods.SendMessageA(hWnd, (uint)msg, wParam, lParam);

        /// <summary>
        /// 向指定的窗口发送消息
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="msg">消息类型</param>
        /// <param name="wParam">消息的附加参数</param>
        /// <param name="lParam">消息的附加参数</param>
        /// <returns>消息处理结果</returns>
        internal static LRESULT SendMessageOLD(HWND hWnd, int msg, WPARAM wParam, LPARAM lParam)
            => NativeMethods.SendMessageA(hWnd, (uint)msg, wParam, lParam);

        /// <summary>
        /// 向指定的窗口发送消息
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="msg">消息类型</param>
        /// <param name="wParam">消息的附加参数</param>
        /// <param name="lParam">消息的附加参数</param>
        /// <returns>消息处理结果</returns>
        internal static LRESULT SendMessageLNG(HWND hWnd, SendMsgValue msg, WPARAM wParam, LPARAM lParam)
            => PInvoke.SendMessage(hWnd, (uint)msg, wParam, lParam);

        /// <summary>
        /// 向指定的窗口发送消息
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="msg">消息类型</param>
        /// <param name="wParam">消息的附加参数</param>
        /// <param name="lParam">消息的附加参数</param>
        /// <returns>消息处理结果</returns>
        public static int SendMessageLNG(int hWnd, SendMsgValue msg, uint wParam,int lParam)
            => (int)(IntPtr)SendMessageLNG((HWND)(IntPtr)hWnd, msg, (UIntPtr)wParam, lParam);
        #endregion

        /// <summary>
        /// 设置编辑控件中的最大文本长度，原最大长度为30000个字符（双字节字符算1个）
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="newLength"></param>
        /// <param name="mode">true则允许长度变短</param>
        /// <returns>当前的最大文本长度</returns>
        private static int SetTextBoxLength(IntPtr hwnd, int newLength, bool mode)
        {
            var len = (int)SendMessageLNG((HWND)hwnd, SendMsgValue.EM_GETLIMITTEXT, 0, 0).Value;//获取最大文本长度
            if (newLength < len
                && (!mode || newLength > len / 3 || newLength <= 30000))
                return len;
            len = newLength * 2;
            _ = SendMessageLNG((HWND)hwnd, SendMsgValue.EM_LIMITTEXT, (nuint)len, 0).Value;//设置新的文本最大长度
            return len;
        }

        /// <summary>
        /// 设置编辑控件中的最大文本长度，原最大长度为30000个字符（双字节字符算1个）
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="newLength"></param>
        /// <param name="mode">true则允许长度变短</param>
        /// <returns>当前的最大文本长度</returns>
        public static int SetTextBoxLength(int hwnd, int newLength, bool mode)
            => SetTextBoxLength((IntPtr)hwnd, newLength, mode);

        /// <summary>
        /// 取消进程确认
        /// </summary>
        /// <param name="buttonHwnd">按钮句柄</param>
        /// <param name="keyHwnd">键盘句柄</param>
        /// <param name="messageBoxfFunc">弹出确认对话框</param>
        /// <returns>是否取消进程</returns>
        public static bool StopProcess(IntPtr buttonHwnd, VirtualKey keyHwnd, Func<bool> messageBoxfFunc)
        {
            var button = (HWND)buttonHwnd;
            // 检查是否按下指定键
            if (KeyMethod.GetAsyncKeyState(keyHwnd) < 0)
            {

                // 设置按钮状态为按下
                _ = SendMessageLNG(button, SendMsgValue.BM_SETSTATE, (nuint)1, (nint)0);
                // 弹出确认对话框
                if (messageBoxfFunc.Invoke())
                    return false;
            }
            // 检查按钮状态是否为鼠标中键弹起
            else if ((nint)SendMessageLNG(button, SendMsgValue.BM_GETSTATE, 0, 0) == (int)SendMsgValue.WM_MBUTTONUP)
            {
                // 设置按钮状态为按下
                _ = SendMessageLNG(button, SendMsgValue.BM_SETSTATE, 1, 0);
                // 弹出确认对话框
                if (messageBoxfFunc.Invoke())
                    return false;
            }
            else
                return false;

            // 隐藏取消操作按钮
            ShowWindow(button, SHOW_WINDOW_CMD.SW_HIDE);
            // 禁用 Esc 键，因主对话框会响应而退出
            EnableWindow((HWND)(IntPtr)keyHwnd, true);

            return true;
        }

        /// <summary>
        /// 显示或取消取消进程按钮
        /// </summary>
        /// <param name="buttonHwnd"> 按钮的句柄</param>
        /// <param name="keyHwnd">键盘的句柄</param>
        /// <param name="mode">true表示显示按钮，false表示隐藏按</param>
        public static void ShowButton(IntPtr buttonHwnd, IntPtr keyHwnd, bool mode)
        {
            var button=(HWND)buttonHwnd;
            if (mode)
            {
                //显示取消操作按钮
                ShowWindow(button, SHOW_WINDOW_CMD.SW_SHOW);
                //禁用 Esc 键，因主对话框会响应而退出
                EnableWindow((HWND)keyHwnd, false);
                //清除按键记录，因为 GetAsyncKeyState 会记录最近一次
                KeyMethod.GetAsyncKeyState((VirtualKey)keyHwnd);
            }
            else
            {
                //隐藏取消操作按钮
                ShowWindow(button, SHOW_WINDOW_CMD.SW_HIDE);
                //启用 Esc 键，因主对话框会响应而被禁用
                EnableWindow((HWND)keyHwnd, true);
            }
        }

        #region 用于控件的显示和隐藏

        /// <summary>
        /// 显示窗口
        /// </summary>
        /// <param name="hwnd">窗口句柄</param>
        /// <param name="nCmdShow">窗口显示方式</param>
        /// <returns>是否成功</returns>
        internal static bool ShowWindow(HWND hwnd, SHOW_WINDOW_CMD nCmdShow)
            => PInvoke.ShowWindow(hwnd, nCmdShow);

        /// <summary>
        /// 启用窗口
        /// </summary>
        /// <param name="hwnd">窗口句柄</param>
        /// <param name="fEnable">是否启用</param>
        /// <returns>是否成功</returns>
        internal static bool EnableWindow(HWND hwnd, bool fEnable)
            => PInvoke.EnableWindow(hwnd, fEnable);

        #endregion

        #region 用于控件句柄的获取

        /// <summary>
        /// 获取当前焦点窗口的句柄。
        /// </summary>
        /// <returns>当前焦点窗口的句柄。</returns>
        internal static HWND GetFocus()
            => PInvoke.GetFocus();

        /// <summary>
        /// 获取对话框中指定ID的子窗口句柄。
        /// </summary>
        /// <param name="hDlg">对话框句柄。</param>
        /// <param name="nIdDlgItem">子窗口的ID。</param>
        /// <returns>子窗口句柄。</returns>
        public static IntPtr GetDlgItem(IntPtr hDlg, int nIdDlgItem)
            => PInvoke.GetDlgItem((HWND)hDlg, nIdDlgItem);
        internal static HWND GetDlgItem(HWND hDlg, int nIdDlgItem)
            => PInvoke.GetDlgItem(hDlg, nIdDlgItem);

        /// <summary>
        /// 根据给定的坐标获取窗口句柄。
        /// </summary>
        /// <param name="xPoint">X坐标。</param>
        /// <param name="yPoint">Y坐标。</param>
        /// <returns>窗口句柄。</returns>
        internal static HWND WindowFromPoint(int xPoint, int yPoint)
            => WindowFromPoint(new Point(xPoint, yPoint));

        internal static HWND WindowFromPoint(Point point)
            => PInvoke.WindowFromPoint(point);

        /// <summary>
        /// 根据指定坐标获取子窗口句柄
        /// </summary>
        /// <param name="hwnd">父窗口句柄</param>
        /// <param name="xPoint">X坐标</param>
        /// <param name="yPoint">Y坐标</param>
        /// <returns>子窗口句柄</returns>
        internal static HWND ChildWindowFromPoint(HWND hwnd, int xPoint, int yPoint)
            => PInvoke.ChildWindowFromPoint(hwnd, new Point(xPoint, yPoint));

        internal static HWND ChildWindowFromPoint(HWND hwnd, Point point)
            => PInvoke.ChildWindowFromPoint(hwnd,point);

        #endregion

        #region 获取和设置滚动条位置函数

        /// <summary>
        /// GetScrollPos 函数检索指定滚动条中 (thumb) 滚动框的当前位置。
        /// 当前位置是一个相对值，取决于当前滚动范围。
        /// 例如，如果滚动范围是 0 到 100，而滚动框位于条的中间，则当前位置为 50。
        /// </summary>
        /// <param name="hwnd">滚动条控件或具有标准滚动条的窗口的句柄，具体取决于 nBar 参数的值。</param>
        /// <param name="nBar">滚动条控件或具有标准滚动条的窗口的句柄，具体取决于 nBar 参数的值。
        /// SB_CTL 检索滚动条控件中滚动框的位置。 hWnd 参数必须是滚动条控件的句柄。
        /// SB_HORZ 检索滚动框在窗口的标准水平滚动条中的位置。
        /// SB_VERT 检索滚动框在窗口的标准垂直滚动条中的位置。
        /// </param>
        /// <returns></returns>
        internal static int GetScrollPos(HWND hwnd, SCROLLBAR_CONSTANTS nBar)
            => PInvoke.GetScrollPos(hwnd, nBar);

        /// <summary>
        /// 指定滚动条中设置滚动框的位置，并根据需要重绘滚动条以反映滚动框的新位置。
        /// </summary>
        /// <param name="hwnd">滚动条控件或具有标准滚动条的窗口的句柄，具体取决于 nBar 参数的值。</param>
        /// <param name="nBar">指定要设置的滚动条
        /// SB_CTL 检索滚动条控件中滚动框的位置。 hWnd 参数必须是滚动条控件的句柄。
        /// SB_HORZ 检索滚动框在窗口的标准水平滚动条中的位置。
        /// SB_VERT 检索滚动框在窗口的标准垂直滚动条中的位置。
        /// </param>
        /// <param name="nPos">指定滚动框的新位置。 位置必须在滚动范围内。</param>
        /// <param name="bRedraw">指定是否重绘滚动条以反映新的滚动框位置。 如果此参数为 TRUE，则重绘滚动条。 如果为 FALSE，则不重绘滚动条。</param>
        /// <returns>如果函数成功，则返回值为滚动框的上一位置。如果函数失败，则返回值为零。</returns>
        [Obsolete("SetScrollPos is obsolete, please use SetScrollInfo instead.")]
        internal static int SetScrollPos(HWND hwnd, SCROLLBAR_CONSTANTS nBar, int nPos, bool bRedraw)
            => PInvoke.SetScrollPos(hwnd, nBar, nPos, bRedraw);
      

        internal static int SetScrollInfo(HWND hwnd, SCROLLBAR_CONSTANTS nBar,in SCROLLINFO lpsi,bool redraw) 
            => PInvoke.SetScrollInfo(hwnd, nBar, in lpsi, redraw);

        #endregion

        #region 获取字符串的像素大小使用的函数

        /// <summary>
        /// 获取指定窗口的设备上下文句柄。
        /// </summary>
        /// <param name="hwnd">窗口句柄。</param>
        /// <returns>设备上下文句柄。</returns>
        internal static HDC GetDC(HWND hwnd)
            => PInvoke.GetDC(hwnd);

        /// <summary>
        /// 释放设备上下文句柄
        /// </summary>
        /// <param name="hwnd">窗口句柄</param>
        /// <param name="hDc">设备上下文句柄</param>
        /// <returns>如果成功释放设备上下文句柄，则返回true；否则返回false</returns>
        internal static bool ReleaseDC(HWND hwnd, HDC hDc)
            => PInvoke.ReleaseDC(hwnd, hDc) != 0;

        /// <summary>
        /// 在指定的设备上下文中绘制文本。
        /// </summary>
        /// <param name="hDc">设备上下文的句柄。</param>
        /// <param name="lpStr">要绘制的文本。</param>
        /// <param name="nCount">要绘制的字符数。</param>
        /// <param name="lpRect">指定文本绘制区域的矩形。</param>
        /// <param name="wFormat">指定文本绘制的格式。</param>
        /// <returns>如果成功绘制文本，则返回true；否则返回false。</returns>
        /// <remarks>注意 原文中使用A版本，此处调用的是W版本,因cswin32无法获取A版本</remarks>
        internal static bool DrawText(HDC hDc, string lpStr, int nCount, ref Rectangle lpRect, DRAW_TEXT_FORMAT wFormat)
        {
            unsafe
            {
                fixed (char* a = lpStr)
                {
                    var r = (RECT)lpRect;
                    var res = PInvoke.DrawText(hDc, a, nCount, ref r, wFormat) != 0;
                    lpRect = r;
                    return res;
                }
            }
        }

        /// <summary>
        /// 获取指定字符串的文本尺寸。
        /// </summary>
        /// <param name="hDc">设备上下文句柄。</param>
        /// <param name="lpString">要测量的字符串。</param>
        /// <param name="cbString">字符串的字节数。</param>
        /// <param name="lpSize">用于存储文本尺寸的 POINTAPI 结构。</param>
        /// <returns>如果成功，则返回true；否则返回false。</returns>
        private static bool GetTextExtentPoint32(HDC hDc, string lpString, int cbString, out SIZE lpSize)
            => PInvoke.GetTextExtentPoint32A(hDc, lpString, cbString, out lpSize);

        #endregion

        /// <summary>
        /// 将指定设备上下文的文本颜色设置为指定颜色
        /// </summary>
        /// <param name="hDc">设备上下文句柄</param>
        /// <param name="crColor">颜色值</param>
        /// <returns>
        ///如果函数成功，则返回值是上一个文本颜色的颜色引用，作为 COLORREF 值。
        /// COLORREF 为0x00蓝蓝绿绿红红
        /// 如果函数失败，则返回值为 CLR_INVALID。
        /// </returns>
        internal static COLORREF SetTextColor(HDC hDc, COLORREF crColor)
            => PInvoke.SetTextColor(hDc, crColor);

        /// <summary>
        /// 指向 CHOOSEFONT 结构的指针
        /// </summary>
        /// <param name="pChoosefont">指向CHOOSE_FONT结构的引用</param>
        /// <returns>是否成功</returns>
        /// <remarks>cswin32无,metadata有</remarks>
        internal static bool ChooseFont(ref CHOOSE_FONT pChoosefont)
        {
            unsafe
            {
                fixed (CHOOSE_FONT* p=&pChoosefont)
                {
                    return NativeMethods.ChooseFont(p);
                }
            }
        }

        /// <summary>
        /// 初始化字体对象
        /// </summary>
        /// <param name="lpLogFont">指向LOG_FONT结构的引用</param>
        /// <param name="FontHandle">指向字体的句柄</param>
        /// <returns>是否成功</returns>
        /// <remarks>原A，CS无</remarks>
        internal static bool CreateFontIndirect(in LOGFONTW lpLogFont, out DeleteObjectSafeHandle FontHandle)
        {
            FontHandle = PInvoke.CreateFontIndirect(in lpLogFont);
            return !FontHandle.IsInvalid;
        }

        #region Object

        /// <summary>
        /// 从gdi32.dll动态链接库中导入GetObjectAPI函数，用于获取对象信息
        /// </summary>
        /// <param name="hObject">对象句柄</param>
        /// <param name="nCount">对象信息的大小</param>
        /// <param name="lpvObject">指向对象信息的引用,必须足够大</param>
        /// <returns>是否成功</returns>
        /// <remarks>
        /// 如果函数成功，并且 lpvObject 是有效的指针，则返回值是存储在缓冲区中的字节数。
        /// 如果函数成功，并且 lpvObject 为 NULL，则返回值是保存函数将存储到缓冲区中的信息所需的字节数。
        /// 如果函数失败，则返回值为零。
        /// </remarks>
        internal static int GetObjectAPI(HGDIOBJ hObject, int nCount,  IntPtr? lpvObject=null)
        {
            unsafe
            {
              return  PInvoke.GetObject(hObject, nCount, lpvObject.HasValue ? lpvObject.Value.ToPointer() : null);
            }
        }

        /// <summary>
        /// 从gdi32.dll动态链接库中导入SelectObject函数，用于选择对象
        /// </summary>
        /// <param name="hDc">设备上下文句柄</param>
        /// <param name="hObject">对象句柄</param>
        /// <returns>
        ///如果所选对象不是区域且函数成功，则返回值是被替换对象的句柄。
        /// 如果所选对象是一个区域，并且函数成功，则返回区域性质常数。
        /// 如果发生错误并且所选对象不是区域，则返回值为 NULL。 否则，HGDI_ERROR。
        /// </returns>
        internal static HGDIOBJ SelectObject(HDC hDc, HGDIOBJ hObject)
        =>PInvoke.SelectObject(hDc, hObject);

        /// <summary>
        /// 从gdi32.dll动态链接库中导入DeleteObject函数，用于删除对象
        /// </summary>
        /// <param name="hObject">对象句柄</param>
        /// <returns>是否成功</returns>
        internal static bool DeleteObject(HGDIOBJ hObject)
            => PInvoke.DeleteObject(hObject);

        #endregion

        /// <summary>
        /// 更新窗口工作区中的指定矩形或区域。
        /// </summary>
        /// <param name="hwnd">要重绘的窗口的句柄。 如果此参数为 NULL，则更新桌面窗口。</param>
        /// <param name="lprcUpdate">指向 RECT 结构的指针，该结构包含更新矩形的坐标（以设备单位为单位）。 如果 hrgnUpdate 参数标识区域，则忽略此参数。</param>
        /// <param name="hrgnUpdate">更新区域的句柄。 如果 hrgnUpdate 和 lprcUpdate 参数均为 NULL，则整个工作区将添加到更新区域。</param>
        /// <param name="fuRedraw">一个或多个重绘标志。 此参数可用于使窗口失效或验证、控件重新绘制以及控制受 RedrawWindow 影响的窗口。</param>
        /// <returns></returns>
        internal static bool RedrawWindow(HWND hwnd, Rectangle? lprcUpdate, System.Runtime.InteropServices.SafeHandle hrgnUpdate,
            REDRAW_WINDOW_FLAGS fuRedraw)
            => PInvoke.RedrawWindow(hwnd, lprcUpdate, hrgnUpdate, fuRedraw);

        #region 获取窗口标题或控件中的文本

        /// <summary>
        /// 如果指定的窗口是控件，则函数将检索控件内文本的长度。
        /// 但是 GetWindowTextLength 无法检索另一个应用程序中编辑控件的文本长度。 </see>
        /// </summary>
        /// <param name="hwnd">窗口或控件的句柄。</param>
        /// <returns>如果函数成功，则返回值为文本的长度（以字符为单位）。 在某些情况下，此值可能大于文本的长度， (请参阅备注) 。如果窗口没有文本，则返回值为零。</returns>
        internal static int GetWindowTextLength(HWND hwnd)
            => PInvoke.GetWindowTextLength(hwnd);

        /// <summary>
        /// 如果指定的窗口是控件，则函数将检索控件内文本的长度。
        /// 但是 GetWindowTextLength 无法检索另一个应用程序中编辑控件的文本长度。 </see>
        /// </summary>
        /// <param name="hwnd">窗口或控件的句柄。</param>
        /// <returns>如果函数成功，则返回值为文本的长度（以字符为单位）。 在某些情况下，此值可能大于文本的长度， (请参阅备注) 。如果窗口没有文本，则返回值为零。</returns>
        public static int GetWindowTextLength(int hwnd) => GetWindowTextLength((HWND)(IntPtr)hwnd);
        /// <summary>
        /// 如果指定窗口的标题栏有一个文本，则复制指定窗口标题栏的文本 。
        /// 如果指定的窗口是控件，则复制控件的文本。
        /// 但是， GetWindowText 无法检索另一个应用程序中控件的文本。
        /// </summary>
        /// <param name="hwnd">包含文本的窗口或控件的句柄。</param>
        /// <param name="lpString">将接收文本的缓冲区。 如果字符串长或长于缓冲区，则字符串将被截断并终止为 null 字符。</param>
        /// <param name="cch">要复制到缓冲区的最大字符数，包括 null 字符。 如果文本超出此限制，则会将其截断。</param>
        /// <returns>如果函数成功，则返回值为复制的字符串的长度（以字符为单位），不包括终止 null 字符。 如果窗口没有标题栏或文本，如果标题栏为空，或者窗口或控件句柄无效，则返回值为零。</returns>
        internal static int GetWindowText(HWND hwnd, out string lpString, int cch)
        {
            unsafe
            {
                PWSTR str = cch.GetStrBuffer();
                var resu = PInvoke.GetWindowText(hwnd, str, cch);
                lpString = str.ToString();
                return resu;
            }
        }

        /// <summary>
        /// 如果指定窗口的标题栏有一个文本，则复制指定窗口标题栏的文本 。
        /// 如果指定的窗口是控件，则复制控件的文本。
        /// 但是， GetWindowText 无法检索另一个应用程序中控件的文本。
        /// </summary>
        /// <param name="hwnd">包含文本的窗口或控件的句柄。</param>
        /// <param name="lpString">将接收文本的缓冲区。 如果字符串长或长于缓冲区，则字符串将被截断并终止为 null 字符。</param>
        /// <param name="cch">要复制到缓冲区的最大字符数，包括 null 字符。 如果文本超出此限制，则会将其截断。</param>
        /// <returns>如果函数成功，则返回值为复制的字符串的长度（以字符为单位），不包括终止 null 字符。 如果窗口没有标题栏或文本，如果标题栏为空，或者窗口或控件句柄无效，则返回值为零。</returns>
        public static string GetWindowText(int hwnd, int cch)
            => GetWindowText((HWND)(IntPtr)hwnd, out var s, cch) == 0
                ? string.Empty
                : s;
        // 设置窗口标题或控件中的文本
        // 不能改变在其他应用程序中的控件的文本内容，如果需要可以用 SendMessage 函数发送一条 WM_SETTEX 消息。
        /// <summary>
        ///如果指定窗口的标题栏有一个文本 ， (更改该窗口的标题栏的文本。
        /// 如果指定的窗口是控件，则更改控件的文本。
        /// 但是， SetWindowText 无法更改另一个应用程序中控件的文本。
        /// </summary>
        /// <param name="hwnd">要更改其文本的窗口或控件的句柄。</param>
        /// <param name="lpString">新的标题或控件文本。</param>
        /// <returns>是否成功</returns>
        internal static bool SetWindowText(HWND hwnd, string? lpString = null)
            => PInvoke.SetWindowText(hwnd, lpString);

        public static bool SetWindowText(int hwnd, string? lpString = null)
        => SetWindowText((HWND)(IntPtr)hwnd, lpString);
        #endregion

        private static class NativeMethods
        {
            [SupportedOSPlatform("windows5.0")]
            [Ansi]
            [Documentation("https://learn.microsoft.com/windows/win32/api/winuser/nf-winuser-sendmessagea")]
            [DllImport("USER32.dll", ExactSpelling = true, PreserveSig = false, SetLastError = true)]

            public static extern LRESULT SendMessageA([In] HWND hWnd, [In] uint Msg, [In] WPARAM wParam, [In] LPARAM lParam);

            //[DllImport("user32.dll", CharSet = CharSet.Auto)]
            //public static extern IntPtr SendMessageLNG(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
            //[DllImport("user32.dll", SetLastError = true)]
            //public static extern bool ShowWindow(IntPtr hwnd, ShowWindowValue nCmdShow);
            //[DllImport("user32.dll", SetLastError = true)]
            //public static extern bool EnableWindow(IntPtr hwnd, bool fEnable);
            //[DllImport("user32.dll")]
            //public static extern IntPtr GetFocus();
            //[DllImport("user32.dll")]
            //public static extern IntPtr GetDlgItem(IntPtr hDlg, int nIdDlgItem);
            //[DllImport("user32.dll")]
            //public static extern IntPtr WindowFromPoint(int xPoint, int yPoint);
            //[DllImport("user32.dll")]
            //public static extern IntPtr ChildWindowFromPoint(IntPtr hwnd, int xPoint, int yPoint);
            //[DllImport("user32.dll")]
            //public static extern IntPtr GetScrollPos(IntPtr hwnd, SendMsgValue nBar);
            //[Obsolete("SetScrollPos is obsolete, please use SetScrollInfo instead.")]
            //[DllImport("user32.dll", SetLastError = true)]
            //public static extern IntPtr SetScrollPos(IntPtr hwnd, SendMsgValue nBar, int nPos, bool bRedraw);
            //[DllImport("user32.dll")]
            //private static extern IntPtr GetDC(IntPtr hwnd);
            //[DllImport("user32.dll")]
            //private static extern bool ReleaseDC(IntPtr hwnd, IntPtr hDc);
            //[DllImport("user32.dll", CharSet = CharSet.Auto)]
            //private static extern bool DrawText(IntPtr hDc, string lpStr, int nCount, ref RECT lpRect, DrawTextConstants wFormat);
            //[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
            //private static extern bool GetTextExtentPoint32(IntPtr hDc, string lpString, int cbString, ref Point lpSize);
            //[DllImport("gdi32.dll")]
            //private static extern int SetTextColor(IntPtr hDc, int crColor);

            [Ansi]
            [Documentation("https://learn.microsoft.com/windows/win32/api/commdlg/nc-commdlg-choosefonta")]
            [DllImport("COMDLG32.dll", ExactSpelling = true, PreserveSig = false)]
            public static extern unsafe bool ChooseFont([In][Out] CHOOSE_FONT* pChoosefont);

            //[DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            //public static extern bool CreateFontIndirect(ref LOG_FONT lpLogFont);
            //[DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            //public static extern bool GetObjectAPI(IntPtr hObject, int nCount, ref IntPtr lpObject);
            //[DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            //public static extern bool SelectObject(IntPtr hDc, IntPtr hObject);
            //[DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            //public static extern bool DeleteObject(IntPtr hObject);
            //[DllImport("user32.dll")]
            //private static extern bool RedrawWindow(IntPtr hwnd, IntPtr lprcUpdate, IntPtr hrgnUpdate, RDW fuRedraw);
            //[DllImport("user32.dll", SetLastError = true)]
            //internal static extern int GetWindowText(IntPtr hwnd, [Out, MarshalAs(UnmanagedType.LPArray)] StringBuilder lpString, int cch);
            //[DllImport("user32.dll", SetLastError = true)]
            //internal static extern bool SetWindowText(IntPtr hwnd, [Optional] string lpString);
        }
    }
}
