using System.Runtime.Versioning;
using Sys.Com.Struct;

namespace Sys.Com
{
    [SupportedOSPlatform("windows6.0")]
    internal class FileMethods
    {
        /// <summary>
        /// 浏览文件夹
        /// </summary>
        /// <param name="folder">获得的文件夹路径</param>
        /// <param name="sTitle">文件夹浏览器标题</param>
        /// <returns>是否成功获得</returns>
        public static bool BrowseForFolder(ref string folder, string sTitle)
        {
            unsafe
            {
                var udtBi = GetBrowseinfow(sTitle);
                //调用文件夹浏览器 去浏览文件夹
                var lpIdList = SHBrowseForFolder(in udtBi);
                if (lpIdList == null)
                    return false;
                _ = SHGetPathFromIDList(lpIdList, out var path);
                CoTaskMemFree((IntPtr)lpIdList);
                folder = path.Replace("\0", "");
                return true;
            }
        }
        private static BROWSEINFOW GetBrowseinfow(string sTitle)
        {
            unsafe
            {
                fixed (char* p = sTitle)
                {
                    return new BROWSEINFOW
                    {
                        hwndOwner = (HWND)IntPtr.Zero,
                        lpszTitle = p,
                        ulFlags = (uint)(BrowseFolder.BIF_RETURNONLYFSDIRS | BrowseFolder.BIF_USENEWUI)
                    };
                }
            }
        }

        /// <summary>
        /// 释放由COM组件分配的内存空间
        /// </summary>
        /// <param name="hMem">要释放的内存块的句柄</param>
        private static void CoTaskMemFree(IntPtr hMem)
        {
            unsafe
            {
                PInvoke.CoTaskMemFree(hMem.ToPointer());
            }
        }

        /// <summary>
        /// 显示一个浏览文件夹的对话框，并返回用户选择的文件夹的句柄。
        /// </summary>
        /// <param name="lpbi">包含用于显示对话框信息的结构。 </param>
        /// <returns>
        /// 若用户选择了一个文件夹，则返回该文件夹的句柄；
        /// 若用户取消了选择或发生了错误，则返回IntPtr.Zero。
        /// </returns>
        private static unsafe ITEMIDLIST* SHBrowseForFolder(in BROWSEINFOW lpbi) 
            => PInvoke.SHBrowseForFolder(lpbi);

        /// <summary>
        /// 将项目标识符列表转换为文件系统路径。 （注意：SHGetPathFromIDList调用ANSI版本，必须调用SHGetPathFromIDListW进行.NET）
        /// </summary>
        /// <param name="pidl">指定相对于命名空间（桌面）根目录的文件或目录位置的项目标识符列表的地址。</param>
        /// <param name="pszPath">接收文件系统路径的缓冲区的地址。此缓冲区的大小必须至少为MAX_PATH个字符。</param>
        /// <param name="len">字串的最大长度+1，默认为260</param>
        /// <returns>如果成功，则返回TRUE；否则返回FALSE。</returns>
        private static unsafe bool SHGetPathFromIDList(ITEMIDLIST* pidl, out string pszPath, int len = 260)
        {
            PWSTR str = len.GetStrBuffer();
            var result = PInvoke.SHGetPathFromIDList(pidl, str);
            pszPath = str.ToString();
            return result;
        }
        /// <summary>
        /// 显示帮助窗口
        /// </summary>
        /// <param name="hwndCaller">指定调用 HtmlHelp 的窗口 (hwnd) 句柄。 帮助窗口归此窗口所有。</param>
        /// <param name="pszFile">指定调用 HtmlHelp 的窗口 (hwnd) 句柄。 帮助窗口归此窗口所有。</param>
        /// <param name="uCommand">指定要完成的 命令。</param>
        /// <param name="dwData">根据 uCommand 参数的值指定可能需要的任何数据。</param>
        /// <returns>
        /// <para>根据指定的 uCommand 和结果， HtmlHelp 返回以下一项或两项：</para>
        /// <para>句柄(帮助窗口的 hwnd) 。</para>
        /// <para>NULL.在某些情况下，NULL 表示失败; 在其他情况下，NULL 表示尚未创建帮助窗口。</para>
        /// </returns>
        public static IntPtr HtmlHelp(HWND hwndCaller, string pszFile, HTML_HELP_COMMAND uCommand, UIntPtr dwData)
            => PInvoke.HtmlHelp(hwndCaller, pszFile, uCommand, dwData);

        ///// <summary>
        ///// 显示帮助窗口
        ///// </summary>
        ///// <param name="hwndCaller">指定调用者的窗口</param>
        ///// <param name="pszFile">指定要调用的文件</param>
        ///// <param name="uCommand">发送给HtmlHelp的命令</param>
        ///// <param name="dwData">uCommand的参数</param>
        ///// <returns></returns>
        //[DllImport("hhctrl.ocx", CharSet = CharSet.Auto, SetLastError = true)]
        //public static extern IntPtr HtmlHelp(IntPtr hwndCaller, string pszFile, uint uCommand, int dwData);
    }
}
