namespace Sys.Com.WindowsControls
{
    /// <summary>
    /// DrawText 的 wFormat 参数定义
    /// </summary>
    public enum DrawTextConstants
    {
        /// <summary>
        /// 正文顶端对齐（仅对单行）。
        /// </summary>
        DT_TOP = 0x0,
        /// <summary>
        /// 正文左对齐。
        /// </summary>
        DT_LEFT = 0x0,
        /// <summary>
        /// 使正文在矩形中水平居中。
        /// </summary>
        DT_CENTER = 0x1,
        /// <summary>
        /// 正文右对齐。
        /// </summary>
        DT_RIGHT = 0x2,
        /// <summary>
        /// 正文水平居中（仅对单行）。
        /// </summary>
        DT_VCENTER = 0x4,
        /// <summary>
        /// 将正文调整到矩形底部。此值必须和 DT_SINGLELINE 组合。
        /// </summary>
        DT_BOTTOM = 0x8,
        /// <summary>
        /// 断开字。当一行中的字符将会延伸到由lpRect指定的矩形的边框时，此行自动地在字之间断开。一个回车一换行也能使行折断。
        /// </summary>
        DT_WORDBREAK = 0x10,
        /// <summary>
        /// 显示正文的同一行，回车和换行符都不能折行。
        /// </summary>
        DT_SINGLELINE = 0x20,
        /// <summary>
        /// 扩展制表符，每个制表符的缺省字符数是8
        /// </summary>
        DT_EXPANDTABS = 0x40,
        /// <summary>
        /// 设置制表，参数uFormat的15"C8位（低位字中的高位字节）指定每个制表符的字符数，每个制表符的缺省字符数是8。
        /// </summary>
        DT_TABSTOP = 0x80,
        /// <summary>
        /// 无裁剪绘制当DT_NOCLIP使用时DrawText的使用会有所加快。
        /// </summary>
        DT_NOCLIP = 0x100,
        /// <summary>
        /// 在行的高度里包含字体的外部标头，通常，外部标头不被包含在正文行的高度里。
        /// </summary>
        DT_EXTERNALLEADING = 0x200,
        /// <summary>
        /// 决定矩形的宽和高。如果正文有多行，DrawText使用lpRect定义的矩形的宽度，并扩展矩形的底训以容纳正文的最后一行，
        /// 如果正文只有一行，则DrawText改变矩形的右边界，以容纳下正文行的最后一个字符，上述任何一种情况，DrawText返回格式化正文的高度而不是写正文。
        /// </summary>
        DT_CALCRECT = 0x400,
        /// <summary>
        /// 关闭前缀字符的处理，通常DrawText解释助记前缀字符，&为给其后的字符加下划线，解释&&为显示单个&。指定DT_NOPREFIX，这种处理被关闭。
        /// </summary>
        DT_NOPREFIX = 0x800,
        /// <summary>
        /// 用系统字体来计算正文度量。
        /// </summary>
        DT_INTERNAL = 0x1000,
        /// <summary>
        /// 复制多行编辑控制的正文显示特性，特殊地，为编辑控制的平均字符宽度是以同样的方法计算的，此函数不显示只是部分可见的最后一行。
        /// </summary>
        DT_EDITCONTROL = 0x2000,
        /// <summary>
        /// 可以指定DT_END_ELLIPSIS来替换在字符串末尾的字符，或指定DT_PATH_ELLIPSIS来替换字符串中间的字符。
        /// </summary>
        DT_PATH_ELLIPSIS = 0x4000,    
        /// <summary>
        /// 可以指定DT_END_ELLIPSIS来替换在字符串末尾的字符，或指定DT_PATH_ELLIPSIS来替换字符串中间的字符。
        /// 如果字符串里含有反斜扛，DT_PATH_ELLIPSIS尽可能地保留最后一个反斜杠之后的正文。 
        /// </summary>
        DT_END_ELLIPSIS = 0x8000,
        /// <summary>
        /// 修改给定的字符串来匹配显示的正文，此标志必须和DT_END_ELLIPSIS或DT_PATH_ELLIPSIS同时使用。
        /// </summary>
        DT_MODIFYSTRING = 0x10000,
        /// <summary>
        /// 当选择进设备环境的字体是Hebrew或Arabicf时，为双向正文安排从右到左的阅读顺序都是从左到右的。
        /// </summary>
        DT_RTLREADING = 0x20000,
        /// <summary>
        /// 截短不符合矩形的正文，并增加椭圆。
        /// </summary>
        DT_WORD_ELLIPSIS = 0x40000,
        //注意：DT_CALCRECT, DT_EXTERNALLEADING, DT_INTERNAL, DT_NOCLIP, DT_NOPREFIX值不能和DT_TABSTOP值一起使用。
    }
}
