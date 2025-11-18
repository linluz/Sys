namespace Sys.Com.WindowsControls.Font
{

    /// <summary>
    /// 字体类型， 用于 ChooseFont 函数
    /// </summary>
    [Flags]
    public enum FONTTYPE: ushort
    {
        /// <summary>
        /// 字体为粗体。此信息从 LOGFONT 结构成员 lfWeight 复制，并和FW_BOLD 等效。
        /// </summary>
        BOLD_FONTTYPE = 0x100,
        /// <summary>
        /// 字体为斜体。此信息从 LOGFONT 结构成员 lfItalic 复制。
        /// </summary>
        ITALIC_FONTTYPE = 0x200,
        /// <summary>
        /// 字体为打印机字体。
        /// </summary>
        PRINTER_FONTTYPE = 0x400,
        /// <summary>
        /// 字体为标准。此信息是从在 LOGFONT 结构成员 lfWeight 复制，并和 FW_REGULAR 等效。
        /// </summary>
        REGULAR_FONTTYPE = 0x400,
        /// <summary>
        /// 字体为屏幕字体。
        /// </summary>
        SCREEN_FONTTYPE = 0x2000,
        /// <summary>
        /// 字体被图形设备接口 (GDI) 模拟
        /// </summary>
        SIMULATED_FONTTYPE = 0x8000,

    }
}
