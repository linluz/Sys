namespace Sys.Com.String.CodePage
{
    /// <summary>
    /// GetLocaleInfo/SetLocaleInfo()中 LCTYPE values 的具体意义
    /// </summary>
    public enum LOCALE:uint
    {
        /// <summary>、
        /// 语言ID
        /// </summary>
        LOCALE_ILANGUAGE = 0x1,
        /// <summary>、
        /// 语言区域名称，如: "English (United States)"
        /// </summary>
        LOCALE_SLANGUAGE = 0x2,
        /// <summary>、
        /// 语言英语名称
        /// </summary>
        LOCALE_SENGLANGUAGE = 0x1001,
        /// <summary>、
        /// 语言名称缩写，如: "ENU"
        /// </summary>
        LOCALE_SABBREVLANGNAME = 0x3,
        /// <summary>、
        /// 当地语言名称，如: "English"
        /// </summary>
        LOCALE_SNATIVELANGNAME = 0x4,
        /// <summary>、
        /// 国家代码
        /// </summary>
        LOCALE_ICOUNTRY = 0x5,
        /// <summary>、
        /// 国家本地名称
        /// </summary>
        LOCALE_SCOUNTRY = 0x6,
        /// <summary>、
        /// 国家英语名称
        /// </summary>
        LOCALE_SENGCOUNTRY = 0x1002,
        /// <summary>、
        /// 国家名称缩写
        /// </summary>
        LOCALE_SABBREVCTRYNAME = 0x7,
        /// <summary>、
        /// 当地语言国家名称
        /// </summary>
        LOCALE_SNATIVECTRYNAME = 0x8,
        /// <summary>、
        /// 缺省语言ID
        /// </summary>
        LOCALE_IDEFAULTLANGUAGE = 0x9,
        /// <summary>、
        /// 缺省国家代码
        /// </summary>
        LOCALE_IDEFAULTCOUNTRY = 0xA,
        /// <summary>、
        /// 缺省的OEM代码
        /// </summary>
        LOCALE_IDEFAULTCODEPAGE = 0xB,
        /// <summary>、
        /// 缺省的ASCII代码
        /// </summary>
        LOCALE_IDEFAULTANSICODEPAGE = 0x1004,
        /// <summary>、
        /// 缺省的MACINTOH代码
        /// </summary>
        LOCALE_IDEFAULTMACCODEPAGE = 0x1011
    }
}
