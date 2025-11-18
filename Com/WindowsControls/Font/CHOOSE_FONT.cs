using System.Runtime.InteropServices;

namespace Sys.Com.WindowsControls.Font
{
    /// <summary>
    /// 字体对话框类型
    /// </summary>
    /// <see cref="https://learn.microsoft.com/zh-cn/windows/win32/api/commdlg/ns-commdlg-choosefontw"/>
    [StructLayout(LayoutKind.Sequential)]
    internal struct CHOOSE_FONT
    {
        /// <summary>
        ///  CHOOSEFONT结构的大小（以字节为单位）
        /// </summary>
        public uint lStructSize;
        /// <summary>
        ///  调用者的窗口句柄
        /// </summary>
        public HWND hwndOwner;
        /// <summary>
        ///  打印机DC/IC或NULL
        /// </summary>
        public HDC hDC;
        /// <summary>
        ///  LogFont结构的地址
        /// </summary>
        public unsafe LOGFONTW* lpLogFont;
        /// <summary>
        ///  选定字体的大小（以磅为单位）
        /// </summary>
        public int iPointSize;
        /// <summary>
        ///  枚举类型的标志
        /// </summary>
        public CF_VALUE flags;
        /// <summary>
        ///  返回的文本颜色
        /// </summary>
        public COLORREF rgbColors;
        /// <summary>
        ///  传递给钩子函数的数据
        /// </summary>
        public LPARAM lCustData;
        /// <summary>
        ///  钩子函数的指针
        /// </summary>
        public IntPtr lpfnHook;
        /// <summary>
        ///  自定义模板名称
        /// </summary>
        public PSTR lpTemplateName;
        /// <summary>
        ///  包含自定义对话框模板的.EXE的实例句柄
        /// </summary>
        public IntPtr hInstance;
        /// <summary>
        ///  在此返回样式字段，必须是LF_FACESIZE或更大
        /// </summary>
        public PSTR lpszStyle;
        /// <summary>
        ///  与添加了额外的FONTTYPE_位的EnumFonts回调一起报告的相同值
        /// </summary>
        public FONTTYPE nFontType;
        public ushort ___MISSING_ALIGNMENT__;
        /// <summary>
        ///  如果使用CF_LIMITSIZE，则允许的最小磅数
        /// </summary>
        public int nSizeMin;
        /// <summary>
        ///  如果使用CF_LIMITSIZE，则允许的最大磅数
        /// </summary>
        public int nSizeMax;
    }
}
