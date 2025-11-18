namespace Sys.Enum
{
    /// <summary>
    /// 表示已知的代码页（CodePage）常量。
    /// </summary>
    public enum KnownCodePage
    {
        /// <summary>
        /// 未知代码页。
        /// </summary>
        CP_UNKNOWN = -1,

        /// <summary>
        /// 当前系统默认 Windows ANSI 代码页。
        /// </summary>
        CP_ACP = 0,

        /// <summary>
        /// 当前系统默认 OEM 代码页。
        /// </summary>
        CP_OEMCP = 1,

        /// <summary>
        /// 当前系统默认 Macintosh 代码页。
        /// </summary>
        CP_MACCP = 2,

        /// <summary>
        /// 当前线程的 ANSI 代码页。
        /// </summary>
        CP_THREAD_ACP = 3,

        /// <summary>
        /// 符号代码页。
        /// </summary>
        CP_SYMBOL = 42,

        #region 阿拉伯

        /// <summary>
        /// Bidi Windows 代码页。
        /// </summary>
        CP_AWIN = 101,

        /// <summary>
        /// MS-DOS 阿拉伯语支持，CP 709。
        /// </summary>
        CP_709 = 102,

        /// <summary>
        /// MS-DOS 阿拉伯语支持，CP 720。
        /// </summary>
        CP_720 = 103,

        /// <summary>
        /// ASMO 708 代码页。
        /// </summary>
        CP_A708 = 104,

        /// <summary>
        /// ASMO 449+ 代码页。
        /// </summary>
        CP_A449 = 105,

        /// <summary>
        /// MS 透明阿拉伯语代码页。
        /// </summary>
        CP_TARB = 106,

        /// <summary>
        /// Nafitha 增强型阿拉伯字符集。
        /// </summary>
        CP_NAE = 107,

        /// <summary>
        /// Nafitha v 4.0 代码页。
        /// </summary>
        CP_V4 = 108,

        /// <summary>
        /// Mussaed Al Arabi (MA/2)，CP 786。
        /// </summary>
        CP_MA2 = 109,

        /// <summary>
        /// IBM 阿拉伯语补充，CP 864。
        /// </summary>
        CP_I864 = 110,

        /// <summary>
        /// ANSI 437 代码页。
        /// </summary>
        CP_A437 = 111,

        /// <summary>
        /// Macintosh 代码页。
        /// </summary>
        CP_AMAC = 112,

        #endregion
        #region 希伯来语

        /// <summary>
        /// Bidi Windows 代码页。
        /// </summary>
        CP_HWIN = 201,

        /// <summary>
        /// IBM 希伯来语补充，CP 862。
        /// </summary>
        CP_862I = 202,

        /// <summary>
        /// IBM 希伯来语补充，CP 862 折叠。
        /// </summary>
        CP_7BIT = 203,

        /// <summary>
        /// ISO 希伯来语 8859-8 字符集。
        /// </summary>
        CP_ISO = 204,

        /// <summary>
        /// ANSI 437 代码页。
        /// </summary>
        CP_H437 = 205,

        /// <summary>
        /// Macintosh 代码页。
        /// </summary>
        CP_HMAC = 206,

        #endregion
        #region OEM 代码页

        /// <summary>
        /// OEM 美国。
        /// </summary>
        CP_IBM437 = 437,

        /// <summary>
        /// 阿拉伯语（ASMO 708）。
        /// </summary>
        CP_ASMO708 = 708,

        /// <summary>
        /// 阿拉伯语（透明 ASMO）；阿拉伯语（DOS）。
        /// </summary>
        CP_DOS720 = 720,

        /// <summary>
        /// OEM 希腊语（原 437G）；希腊语（DOS）。
        /// </summary>
        CP_IBM737 = 737,

        /// <summary>
        /// OEM 波罗的海；波罗的海（DOS）。
        /// </summary>
        CP_IMB775 = 775,

        /// <summary>
        /// OEM 多语言拉丁 1；西欧（DOS）。
        /// </summary>
        CP_IBM850 = 850,

        /// <summary>
        /// OEM 拉丁 2；中欧（DOS）。
        /// </summary>
        CP_IBM852 = 852,

        /// <summary>
        /// OEM 西里尔字母（主要为俄语）。
        /// </summary>
        CP_IBM855 = 855,

        /// <summary>
        /// OEM 土耳其语；土耳其语（DOS）。
        /// </summary>
        CP_IBM857 = 857,

        /// <summary>
        /// OEM 多语言拉丁 1 + 欧元符号。
        /// </summary>
        CP_IBM00858 = 858,

        /// <summary>
        /// OEM 葡萄牙语；葡萄牙语（DOS）。
        /// </summary>
        CP_IBM860 = 860,

        /// <summary>
        /// OEM 冰岛语；冰岛语（DOS）。
        /// </summary>
        CP_IMB861 = 861,

        /// <summary>
        /// OEM 希伯来语；希伯来语（DOS）。
        /// </summary>
        CP_DOS862 = 862,

        /// <summary>
        /// OEM 法语加拿大；法语加拿大（DOS）。
        /// </summary>
        CP_IBM863 = 863,

        /// <summary>
        /// OEM 阿拉伯语；阿拉伯语（864）。
        /// </summary>
        CP_IBM864 = 864,

        /// <summary>
        /// OEM 北欧；北欧（DOS）。
        /// </summary>
        CP_IBM865 = 865,

        /// <summary>
        /// OEM 俄语；西里尔字母（DOS）。
        /// </summary>
        CP_CP866 = 866,

        /// <summary>
        /// OEM 现代希腊语；现代希腊语（DOS）。
        /// </summary>
        CP_IMB869 = 869,

        /// <summary>
        /// IBM EBCDIC 多语言/ROECE（拉丁 2）；IBM EBCDIC 多语言拉丁 2。
        /// </summary>
        CP_IMB870 = 870,

        /// <summary>
        /// ANSI/OEM 泰语（同 28605，ISO 8859-15）；泰语（Windows）。
        /// </summary>
        CP_THAI = 874,

        /// <summary>
        /// IBM EBCDIC 现代希腊语。
        /// </summary>
        CP_CP875 = 875,

        /// <summary>
        /// ANSI/OEM 日语；日语（Shift-JIS）。
        /// </summary>
        CP_JAPAN = 932,

        /// <summary>
        /// ANSI/OEM 简体中文（中国大陆、新加坡）；简体中文（GBK）。
        /// </summary>
        CP_CHINA = 936,

        /// <summary>
        /// ANSI/OEM 韩语（统一韩文代码）。
        /// </summary>
        CP_KOREA = 949,

        /// <summary>
        /// ANSI/OEM 繁体中文（台湾、香港特别行政区、中国）；繁体中文（Big5）。
        /// </summary>
        CP_TAIWAN = 950,

        #endregion
        #region Windows UNICODE 代码页

        /// <summary>
        /// Unicode UTF-16，小端字节顺序（ISO 10646 的 BMP）；仅对托管应用程序可用。
        /// </summary>
        CP_UniCodeLitte = 1200,

        /// <summary>
        /// Unicode UTF-16，大端字节顺序；仅对托管应用程序可用。
        /// </summary>
        CP_UniCodeBig = 1201,

        #endregion
        #region Windows ANSI 代码页

        /// <summary>
        /// ANSI 中欧；中欧（Windows）。
        /// </summary>
        CP_EASTEUROPE = 1250,

        /// <summary>
        /// ANSI 西里尔字母；西里尔字母（Windows）。
        /// </summary>
        CP_RUSSIAN = 1251,

        /// <summary>
        /// ANSI Latin 1；西欧（Windows）。
        /// </summary>
        CP_WESTEUROPE = 1252,

        /// <summary>
        /// ANSI 希腊语；希腊语（Windows）。
        /// </summary>
        CP_GREEK = 1253,

        /// <summary>
        /// ANSI 土耳其语；土耳其语（Windows）。
        /// </summary>
        CP_TURKISH = 1254,

        /// <summary>
        /// ANSI 希伯来语；希伯来语（Windows）。
        /// </summary>
        CP_HEBREW = 1255,

        /// <summary>
        /// ANSI 阿拉伯语；阿拉伯语（Windows）。
        /// </summary>
        CP_ARABIC = 1256,

        /// <summary>
        /// ANSI 波罗的海；波罗的海（Windows）。
        /// </summary>
        CP_BALTIC = 1257,

        /// <summary>
        /// ANSI/OEM 越南语；越南语（Windows）。
        /// </summary>
        CP_VIETNAMESE = 1258,

        /// <summary>
        /// 韩语（Johab）。
        /// </summary>
        CP_JOHAB = 1361,
        #endregion
        #region MAC

        /// <summary>
        /// MAC Roman；西欧（Mac）。
        /// </summary>
        CP_MAC_ROMAN = 10000,

        /// <summary>
        /// 日语（Mac）。
        /// </summary>
        CP_MAC_JAPAN = 10001,

        /// <summary>
        /// MAC 繁体中文（Big5）；繁体中文（Mac）。
        /// </summary>
        CP_MAC_CHINESETRAD = 10002,

        /// <summary>
        /// 韩语（Mac）。
        /// </summary>
        CP_MAC_KOREAN = 10003,

        /// <summary>
        /// 阿拉伯语（Mac）。
        /// </summary>
        CP_MAC_ARABIC = 10004,

        /// <summary>
        /// 希伯来语（Mac）。
        /// </summary>
        CP_MAC_HEBREW = 10005,

        /// <summary>
        /// 希腊语（Mac）。
        /// </summary>
        CP_MAC_GREEK = 10006,

        /// <summary>
        /// 西里尔字母（Mac）。
        /// </summary>
        CP_MAC_CYRILLIC = 10007,

        /// <summary>
        /// MAC 简体中文（GB 2312）；简体中文（Mac）。
        /// </summary>
        CP_MAC_CHINESESIMP = 10008,

        /// <summary>
        /// 罗马尼亚语（Mac）。
        /// </summary>
        CP_MAC_ROMANIAN = 10010,

        /// <summary>
        /// 乌克兰语（Mac）。
        /// </summary>
        CP_MAC_UKRAINIAN = 10017,

        /// <summary>
        /// 泰语（Mac）。
        /// </summary>
        CP_MAC_THAI = 10021,

        /// <summary>
        /// MAC Latin 2；中欧（Mac）。
        /// </summary>
        CP_MAC_LATIN2 = 10029,

        /// <summary>
        /// 冰岛语（Mac）。
        /// </summary>
        CP_MAC_ICELANDIC = 10079,

        /// <summary>
        /// 土耳其语（Mac）。
        /// </summary>
        CP_MAC_TURKISH = 10081,

        /// <summary>
        /// 克罗地亚语（Mac）。
        /// </summary>
        CP_MAC_CROATIAN = 10082,

        #endregion
        #region Windows UNICODE 代码页

        /// <summary>
        /// Unicode UTF-32，小端字节顺序；仅对托管应用程序可用。
        /// </summary>
        CP_UTF_32LE = 12000,

        /// <summary>
        /// Unicode UTF-32，大端字节顺序；仅对托管应用程序可用。
        /// </summary>
        CP_UTF_32BE = 12001,

        #endregion
        #region 代码页

        /// <summary>
        /// CNS 台湾；繁体中文（CNS）。
        /// </summary>
        CP_CHINESECNS = 20000,

        /// <summary>
        /// Eten 台湾；繁体中文（Eten）。
        /// </summary>
        CP_CHINESEETEN = 20002,

        /// <summary>
        /// Wang 台湾。
        /// </summary>
        CP_IA5WEST = 20105,

        /// <summary>
        /// IA5 德语（7 位）。
        /// </summary>
        CP_IA5GERMAN = 20106,

        /// <summary>
        /// IA5 瑞典（7 位）。
        /// </summary>
        CP_IA5SWEDISH = 20107,

        /// <summary>
        /// IA5 挪威（7 位）。
        /// </summary>
        CP_IA5NORWEGIAN = 20108,

        /// <summary>
        /// US-ASCII（7 位）。
        /// </summary>
        CP_ASCII = 20127,

        /// <summary>
        /// 俄罗斯（KOI8-R）；西里尔字母（KOI8-R）。
        /// </summary>
        CP_RUSSIANKOI8R = 20866,

        /// <summary>
        /// 乌克兰（KOI8-U）；西里尔字母（KOI8-U）。
        /// </summary>
        CP_RUSSIANKOI8U = 21866,

        /// <summary>
        /// ISO 8859-1 Latin 1；西欧语言。
        /// </summary>
        CP_ISOLATIN1 = 28591,

        /// <summary>
        /// ISO 8859-2 中欧语言；中欧语言（ISO）。
        /// </summary>
        CP_ISOEASTEUROPE = 28592,

        /// <summary>
        /// ISO 8859-3 Latin 3；南欧语言，世界语也可用此字符集显示。
        /// </summary>
        CP_ISOTURKISH = 28593,

        /// <summary>
        /// ISO 8859-4 Baltic；北欧语言。
        /// </summary>
        CP_ISOBALTIC = 28594,

        /// <summary>
        /// ISO 8859-5 西里尔字母；斯拉夫语言。
        /// </summary>
        CP_ISORUSSIAN = 28595,

        /// <summary>
        /// ISO 8859-6 阿拉伯语。
        /// </summary>
        CP_ISOARABIC = 28596,

        /// <summary>
        /// ISO 8859-7 希腊语。
        /// </summary>
        CP_ISOGREEK = 28597,

        /// <summary>
        /// ISO 8859-8 希伯来语；希伯来语（视觉顺序）；ISO 8859-8-I 是希伯来语（逻辑顺序）。
        /// </summary>
        CP_ISOHEBREW = 28598,

        /// <summary>
        /// ISO 8859-9 土耳其语，将 Latin-1 的冰岛语字母换为土耳其语字母。
        /// </summary>
        CP_ISOTURKISH2 = 28599,

        /// <summary>
        /// ISO 8859-13 爱沙尼亚语；波罗的语族。
        /// </summary>
        CP_ISOESTONIAN = 28603,

        /// <summary>
        /// ISO 8859-15 Latin 9；西欧语言，加入 Latin-1 欠缺的芬兰语字母和大写法语重音字母，以及欧元（€）符号。
        /// </summary>
        CP_ISOLATIN9 = 28605,

        /// <summary>
        /// ISO 8859-8 希伯来语；希伯来语（逻辑顺序）。
        /// </summary>
        CP_HEBREWLOG = 38598,

        CP_USER = 50000,

        CP_AUTOALL = 50001,

        /// <summary>
        /// ISO 2022 日语中不带半宽片假名；日语（JIS）。
        /// </summary>
        CP_JAPANNHK = 50220,

        /// <summary>
        /// ISO 2022 日语中带半宽片假名；日语（JIS，允许 1 字节假名）。
        /// </summary>
        CP_JAPANESC = 50221,

        /// <summary>
        /// ISO 2022 日语 JIS X 0201-1989；日语（JIS，允许 1 字节假名 - SO/SI）。
        /// </summary>
        CP_JAPANISO = 50222,

        /// <summary>
        /// ISO 2022 韩语。
        /// </summary>
        CP_KOREAISO = 50225,

        /// <summary>
        /// ISO 2022 简体中文；简体中文（ISO 2022）。
        /// </summary>
        CP_TAIWANISO = 50227,

        /// <summary>
        /// ISO 2022 繁体中文。
        /// </summary>
        CP_CHINAISO = 50229,

        CP_AUTOJAPAN = 50932,

        /// <summary>
        /// EBCDIC 简体中文。
        /// </summary>
        CP_AUTOCHINA = 50936,

        CP_AUTOKOREA = 50949,

        /// <summary>
        /// EBCDIC 繁体中文。
        /// </summary>
        CP_AUTOTAIWAN = 50950,

        /// <summary>
        /// EBCDIC 俄语。
        /// </summary>
        CP_AUTORUSSIAN = 51251,

        /// <summary>
        /// EBCDIC 希腊语。
        /// </summary>
        CP_AUTOGREEK = 51253,

        /// <summary>
        /// EBCDIC 阿拉伯语。
        /// </summary>
        CP_AUTOARABIC = 51256,

        /// <summary>
        /// EUC 日语。
        /// </summary>
        CP_JAPANEUC = 51932,

        /// <summary>
        /// EUC 简体中文；简体中文（EUC）。
        /// </summary>
        CP_CHINAEUC = 51936,

        /// <summary>
        /// EUC 韩语。
        /// </summary>
        CP_KOREAEUC = 51949,

        /// <summary>
        /// EUC 繁体中文。
        /// </summary>
        CP_TAIWANEUC = 51950,

        /// <summary>
        /// HZ-GB2312 简体中文；简体中文（HZ）。
        /// </summary>
        CP_CHINAHZ = 52936,

        /// <summary>
        /// Windows XP 及更高：GB18030 简体中文（4 字节）；简体中文（GB18030）。
        /// </summary>
        CP_GB18030 = 54936,

        #endregion
        #region Windows UNICODE 代码页

        /// <summary>
        /// Unicode (UTF-7)。
        /// </summary>
        CP_UTF7 = 65000,

        /// <summary>
        /// Unicode (UTF-8)。
        /// </summary>
        CP_UTF8 = 65001,

        /// <summary>
        /// Unicode (UTF-32 小端)。
        /// </summary>
        CP_UTF32LE = 65005,

        /// <summary>
        /// Unicode (UTF-32 大端)。
        /// </summary>
        CP_UTF32BE = 65006,

        #endregion
    }
}
