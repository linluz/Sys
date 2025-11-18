namespace Sys.Com.WindowsControls.Font
{
    /// <summary>
    /// 字体选择对话框的选项,ChooseFont 类型的 flags 参数定义
    /// </summary>
    /// <see cref="https://learn.microsoft.com/zh-cn/windows/win32/api/commdlg/ns-commdlg-choosefonta"/>
    [Flags]
    public enum CF_VALUE
    {
        /// <summary>
        ///  CF_VALUE
        /// </summary>
        CF_SCREENFONTS = 0x1,
        /// <summary>
        ///  显示打印机字体
        /// </summary>
        CF_PRINTERFONTS = 0x2,
        /// <summary>
        ///  两者都显示
        /// </summary>
        CF_BOTH = (CF_SCREENFONTS | CF_PRINTERFONTS),
        /// <summary>
        /// 显示帮助按钮
        /// </summary>
        CF_SHOWHELP = 0x4,
        /// <summary>
        /// 启用此结构的 lpfnHook 成员中指定的挂钩过程。
        /// </summary>
        CF_ENABLEHOOK = 0x8,
        /// <summary>
        /// 指示 hInstance 和 lpTemplateName 成员指定要用于替代默认模板的对话框模板。
        /// </summary>
        CF_ENABLETEMPLATE = 0x10,
        /// <summary>
        /// 指示 hInstance 成员标识包含预加载对话框模板的数据块。 如果指定了此标志，系统会忽略 lpTemplateName 成员。
        /// </summary>
        CF_ENABLETEMPLATEHANDLE = 0x20,
        /// <summary>
        /// ChooseFont 应使用 lpLogFont 成员指向的结构来初始化对话框控件。
        /// </summary>
        CF_INITTOLOGFONTSTRUCT = 0x40,
        /// <summary>
        /// lpszStyle 成员是指向包含样式数据的缓冲区的指针，ChooseFont 应使用该数据初始化字体样式组合框。 当用户关闭对话框时， ChooseFont 会将用户选择的样式数据复制到此缓冲区。
        /// </summary>
        CF_USESTYLE = 0x80,
        /// <summary>
        ///  添加字体效果，使对话框显示允许用户指定删除线、下划线和文本颜色选项的控件。
        /// </summary>
        CF_EFFECTS = 0x100,
        /// <summary>
        /// 显示应用按钮
        /// </summary>
        CF_APPLY = 0x200,
        [Obsolete("CF_ANSIONLY 已经过时，请改用 CF_SCRIPTSONLY")]
        CF_ANSIONLY = 0x400,
        /// <summary>
        /// ChooseFont 应允许为所有非 OEM 字符集和符号字符集以及 ANSI 字符集选择字体。 这将取代 CF_ANSIONLY 值。
        /// </summary>
#pragma warning disable CS0618 // 类型或成员已过时
        CF_SCRIPTSONLY = CF_ANSIONLY,
#pragma warning restore CS0618 // 类型或成员已过时
        /// <summary>
        /// ChooseFont 不应允许选择矢量字体。
        /// </summary>
        CF_NOVECTORFONTS = 0x800,
        /// <summary>
        /// 与 CF_NOVECTORFONTS 标志相同。
        /// </summary>
        CF_NOOEMFONTS = CF_NOVECTORFONTS,
        /// <summary>
        /// ChooseFont 不应显示或允许选择字体模拟。
        /// </summary>
        CF_NOSIMULATIONS = 0x1000,
        /// <summary>
        ///  设置字体大小限制,ChooseFont 应仅选择 nSizeMin 和 nSizeMax 成员指定的范围内的字号。
        /// </summary>
        CF_LIMITSIZE = 0x2000,
        /// <summary>
        /// ChooseFont 应枚举并允许仅选择固定音调字体。
        /// </summary>
        CF_FIXEDPITCHONLY = 0x4000,
        /// <summary>
        ///  必须也含有 CF_SCREENFONTS CF_PRINTERFONTS
        /// </summary>
        [Obsolete("CF_WYSIWYG 已经过时，请改用 CF_BOTH")]
        CF_WYSIWYG = 0x8000,
        /// <summary>
        /// 如果用户尝试选择对话框中未列出的字体或样式，ChooseFont 应指示错误条件。
        /// </summary>
        CF_FORCEFONTEXIST = 0x10000,
        /// <summary>
        /// 指定 ChooseFont 应仅允许选择可缩放字体。 可缩放字体包括矢量字体、可缩放打印机字体、TrueType 字体以及按其他技术缩放的字体。
        /// </summary>
        CF_SCALABLEONLY = 0x20000,
        /// <summary>
        /// ChooseFont 应仅枚举并允许选择 TrueType 字体。
        /// </summary>
        CF_TTONLY = 0x40000,
        /// <summary>
        /// 
        /// </summary>
        CF_NOFACESEL = 0x80000,
        /// <summary>
        /// 使用结构初始化对话框控件时，使用此标志可阻止对话框显示“ 字体大小 ”组合框的初始选择。 当没有单一字号适用于文本选择时，这非常有用。
        /// </summary>
        CF_NOSTYLESEL = 0x100000,
        /// <summary>
        /// 使用结构初始化对话框控件时，使用此标志可阻止对话框显示“ 字体大小 ”组合框的初始选择。 当没有单一字号适用于文本选择时，这非常有用。
        /// </summary>
        CF_NOSIZESEL = 0x200000,
        /// <summary>
        /// 在输入时指定时，仅显示 LOGFONT 结构的 lfCharSet 成员中标识的字符集的字体。 不允许用户更改 脚本组合框中 指定的字符集。
        /// </summary>
        CF_SELECTSCRIPT = 0x400000,
        /// <summary>
        /// 禁用 “脚本 ”组合框。 设置此标志后，当 ChooseFont 返回时，LOGFONT 结构的 lfCharSet 成员将设置为 DEFAULT_CHARSET。 此标志仅用于初始化对话框。
        /// </summary>
        CF_NOSCRIPTSEL =0x00800000,
        /// <summary>
        /// 导致“ 字体 ”对话框仅列出水平方向的字体。
        /// </summary>
        CF_NOVERTFONTS = 0x1000000,
        /// <summary>
        /// ChooseFont 还应另外显示设置为“在字体中隐藏”的字体控制面板。
        /// </summary>
        CF_INACTIVEFONTS = 0x2000000,
    }
}
