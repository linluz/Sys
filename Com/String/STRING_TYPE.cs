namespace Sys.Com.String
{
    /// <summary>
    /// 自定义字符串类型定义
    /// </summary>
    public struct STRING_TYPE
    {
        /// <summary>
        /// 字符串类型的名称
        /// </summary>
        public string sName;
        /// <summary>
        /// 所有字符串标识符所在位置, 0 = 字串前, 1 = 引用地址前
        /// </summary>
        public int CodeLoc;
        /// <summary>
        /// 第一个字符串标识符位于字串前的位置
        /// </summary>
        public int FristCodePos;
        /// <summary>
        /// 字符串代码页标识符位于字串前的位置
        /// </summary>
        public int CPCodePos;
        /// <summary>
        /// 字符串代码页标识符的字节数
        /// </summary>
        public int CPCodeSize;
        /// <summary>
        /// 字符串代码页标识符开始标记(Hex文本)
        /// </summary>
        public string CPCodeStartString;
        /// <summary>
        /// 字符串代码页标识符开始标记(Hex文本)的字节长度
        /// </summary>
        public int CPCodeStartLength;
        /// <summary>
        /// 字符串代码页标识符开始标记(Hex文本)的字节数组
        /// </summary>
        public byte[] CPCodeStartByte;
        /// <summary>
        /// 字符串长度标识符位于字串前的位置
        /// </summary>
        public int LengthCodePos;
        /// <summary>
        /// 字符串长度标识符的字节数
        /// </summary>
        public int LengthCodeSize;
        /// <summary>
        /// 字符串长度标识符的字串长度计算依据
        /// </summary>
        public int LengthMode;
        /// <summary>
        /// 字符串长度标识符的字串长度调整值
        /// </summary>
        public int LengthReviseVal;
        /// <summary>
        /// 字符串长度标识符的字串长度调整值
        /// </summary>
        public int ByteLengthReviseVal;
        /// <summary>
        /// 字符串长度标识符的字串长度调整值
        /// </summary>
        public int CharLengthReviseVal;
        /// <summary>
        /// 字符串长度标识符开始标记(Hex文本)
        /// </summary>
        public string LengthCodeStartString;
        /// <summary>
        /// 字符串长度标识符开始标记(Hex文本)的字节数
        /// </summary>
        public int LengthCodeStartLength;
        /// <summary>
        /// 字符串长度标识符开始标记(Hex文本)的字节数组
        /// </summary>
        public byte[] LengthCodeStartByte;
        /// <summary>
        /// 字符串开始标识符位于字串前的位置
        /// </summary>
        public int StartCodePos;
        /// <summary>
        /// 字符串开始标识符(Hex文本)
        /// </summary>
        public string StartCodeString;
        /// <summary>
        /// 字符串开始标识符的字节数
        /// </summary>
        public int StartCodeLength;
        /// <summary>
        /// 字符串开始标识符的字节数组
        /// </summary>
        public byte[] StartCodeByte;
        /// <summary>
        /// 字符串结束标识符(Hex文本)
        /// </summary>
        public string EndCodeString;
        /// <summary>
        /// 字符串结束标识符的字节数
        /// </summary>
        public int EndCodeLength;
        /// <summary>
        /// 字符串结束标识符的字节数组
        /// </summary>
        public byte[] EndCodeByte;
        /// <summary>
        /// 引用代码开始位于引用代码前的位置
        /// </summary>
        public int RefCodeStartPos;
        /// <summary>
        /// 引用代码开始标记(Hex文本)
        /// </summary>
        public string RefCodeStartString;
        /// <summary>
        /// 引用代码开始标记(Hex文本)的字节数
        /// </summary>
        public int RefCodeStartLength;
        /// <summary>
        /// 引用代码开始标记(Hex文本)的字节数组
        /// </summary>
        public byte[] RefCodeStartByte;
        /// <summary>
        /// 正则表达式模板
        /// </summary>
        public string[] RegExpPattern;
    }
}
