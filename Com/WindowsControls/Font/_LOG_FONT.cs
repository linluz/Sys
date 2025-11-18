using System.Runtime.InteropServices;

namespace Sys.Com.WindowsControls.Font
{
    /// <summary>
    /// 字体类型
    /// </summary>
    /// <see cref="https://learn.microsoft.com/zh-cn/windows/win32/api/wingdi/ns-wingdi-logfonta"/>
    [StructLayout(LayoutKind.Sequential)]
    public struct LOG_FONT
    {
        /// <summary>
        /// 字体大小
        /// 大于 0	字体映射器将此值转换为设备单位，并将其与可用字体的单元格高度匹配。
        /// 0 字体映射器在搜索匹配项时使用默认高度值。
        /// 小于 0	字体映射器将此值转换为设备单位，并将其绝对值与可用字体的字符高度匹配。
        /// </summary>
        public int lfHeight;
        /// <summary>
        ///  字体宽度
        /// </summary>
        public int lfWidth;
        /// <summary>
        ///  字体显示角度
        /// </summary>
        public int lfEscapement;
        /// <summary>
        ///  字体角度
        /// </summary>
        public int lfOrientation;
        /// <summary>
        ///  是否粗体
        /// </summary>
        public FW lfWeight;
        /// <summary>
        ///  是否斜体
        /// </summary>
        public bool lfItalic;
        /// <summary>
        ///  是否下划线
        /// </summary>
        public bool lfUnderline;
        /// <summary>
        ///  是否删除线
        /// </summary>
        public bool lfStrikeOut;
        /// <summary>
        ///  字符集
        /// </summary>
        public CHARSET lfCharSet;
        /// <summary>
        ///  输出精度
        /// </summary>
        public byte lfOutPrecision;
        /// <summary>
        ///  裁减精度
        /// </summary>
        public byte lfClipPrecision;
        /// <summary>
        ///  逻辑字体与输出设备实际字体之间的精度
        /// </summary>
        public byte lfQuality;
        /// <summary>
        ///  字体间距和字体集
        /// </summary>
        public byte lfPitchAndFamily;
        /// <summary>
        ///  字体名称
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] lfFaceName;
        /// <summary>
        ///  字体颜色
        /// </summary>
        public long lfColor;
    }
}
