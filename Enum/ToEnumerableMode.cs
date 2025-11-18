namespace Sys.Enum
{
    /// <summary>
    /// 指定在转换为可枚举类型失败时的处理方式。
    /// </summary>
    public enum ToEnumerableFailMode
    {
        /// <summary>
        /// 发生失败时抛出异常。
        /// </summary>
        Exception,

        /// <summary>
        /// 发生失败时使用类型的默认值代替。
        /// </summary>
        AsDefault,

        /// <summary>
        /// 发生失败时跳过该项，不进行转换。
        /// </summary>
        Skip
    }
}
