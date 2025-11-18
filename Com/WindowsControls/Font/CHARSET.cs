namespace Sys.Com.WindowsControls.Font
{
    /// <summary>
    /// 字符集枚举， 用于 LOG_FONT 类型的 lfCharSet
    /// </summary>
    public enum CHARSET:byte
    {
        /// <summary>
        ///  ANSI字符集
        /// </summary>
        ANSI_CHARSET = 0,
        /// <summary>
        ///  默认字符集
        /// </summary>
        DEFAULT_CHARSET = 1,
        /// <summary>
        ///  符号字符集
        /// </summary>
        SYMBOL_CHARSET = 2,
        /// <summary>
        ///  Mac字符集
        /// </summary>
        MAC_CHARSET = 77,
        /// <summary>
        ///  ShiftJIS字符集
        /// </summary>
        SHIFTJIS_CHARSET = 128,
        /// <summary>
        ///  韩文字符集
        /// </summary>
        HANGEUL_CHARSET = 129,
        /// <summary>
        ///  Johab字符集
        /// </summary>
        JOHAB_CHARSET = 130,
        /// <summary>
        ///  GB2312字符集
        /// </summary>
        GB2312_CHARSET = 134,
        /// <summary>
        ///  繁体中文字符集
        /// </summary>
        CHINESEBIG5_CHARSET = 136,
        /// <summary>
        ///  希腊字符集
        /// </summary>
        GREEK_CHARSET = 161,
        /// <summary>
        ///  土耳其字符集
        /// </summary>
        TURKISH_CHARSET = 162,
        /// <summary>
        ///  希伯来字符集
        /// </summary>
        HEBREW_CHARSET = 177,
        /// <summary>
        ///  阿拉伯字符集
        /// </summary>
        ARABIC_CHARSET = 178,
        /// <summary>
        ///  波罗的海字符集
        /// </summary>
        BALTIC_CHARSET = 186,
        /// <summary>
        ///  俄语字符集
        /// </summary>
        RUSSIAN_CHARSET = 204,
        /// <summary>
        ///  泰语字符集
        /// </summary>
        THAI_CHARSET = 222,
        /// <summary>
        ///  东欧字符集
        /// </summary>
        EASTEUROPE_CHARSET = 238,
        /// <summary>
        ///  OEM字符集
        /// </summary>
        OEM_CHARSET = 255,
    }
}
