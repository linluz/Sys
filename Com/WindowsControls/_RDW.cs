namespace Sys.Com.WindowsControls
{
    /// <summary>
    /// RedrawWindow 函数的 fuRedraw 参数定义
    /// </summary>
    /// <see cref="https://learn.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-redrawwindow"/>
    public enum RDW: uint
    {
        /// <summary>
        /// 禁用（屏蔽）重绘区域
        /// </summary>
        RDW_INVALIDATE = 0x1,

        /// <summary>
        /// 即使窗口并非无效，也向其投递一条WM_PAINT消息
        /// </summary>
        RDW_INTERNALPAINT = 0x2,

        /// <summary>
        /// 重绘前，先清除重绘区域的背景。也必须指定RDW_INVALIDATE
        /// </summary>
        RDW_ERASE = 0x4,

        /// <summary>
        /// 检验重绘区域
        /// </summary>
        RDW_VALIDATE = 0x8,

        /// <summary>
        /// 禁止内部生成或由这个函数生成的任何待决WM_PAINT消息。针对无效区域，仍会生成WM_PAINT消息
        /// </summary>
        RDW_NOINTERNALPAINT = 0x10,

        /// <summary>
        /// 禁止删除重绘区域的背景
        /// </summary>
        RDW_NOERASE = 0x20,

        /// <summary>
        /// 重绘操作排除子窗口（前提是它们存在于重绘区域）
        /// </summary>
        RDW_NOCHILDREN = 0x40,

        /// <summary>
        /// 重绘操作包括子窗口（前提是它们存在于重绘区域）
        /// </summary>
        RDW_ALLCHILDREN = 0x80,

        /// <summary>
        /// 立即更新指定的重绘区域
        /// </summary>
        RDW_UPDATENOW = 0x100,

        /// <summary>
        /// 立即删除指定的重绘区域
        /// </summary>
        RDW_ERASENOW = 0x200,

        /// <summary>
        /// 如非客户区包含在重绘区域中，则对非客户区进行更新。也必须指定RDW_INVALIDATE
        /// </summary>
        RDW_FRAME = 0x400,

        /// <summary>
        /// 禁止非客户区域重绘（如果它是重绘区域的一部分）。也必须指定RDW_VALIDATE
        /// </summary>
        RDW_NOFRAME = 0x800,

    }
}
