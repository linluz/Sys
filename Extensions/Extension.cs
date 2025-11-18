using Sys.Enum;

namespace Sys.Extensions
{
    public static class Extension
    {
        /// <summary>
        /// 根据条件调用函数对输入值进行处理
        /// </summary>
        /// <typeparam name="TInp">输入类型</typeparam>
        /// <typeparam name="TOut">输出类型</typeparam>
        /// <param name="input">输入值</param>
        /// <param name="control">控制条件</param>
        /// <param name="trueFunc">true时执行的函数</param>
        /// <param name="falseFunc">false时执行的函数</param>
        /// <returns></returns>
        public static TOut? If<TInp, TOut>(this TInp input, bool control, Func<TInp, TOut>? trueFunc = null,
            Func<TInp, TOut>? falseFunc = null)
            => control
                ? trueFunc != null
                    ? trueFunc.Invoke(input)
                    : input is TOut output0
                        ? output0
                        : default
                : falseFunc != null
                    ? falseFunc.Invoke(input)
                    : input is TOut output1
                        ? output1
                        : default;

        #region num

        public static int Min(this int a, int b)
            => a < b ? a : b;

        public static int Max(this int a, int b)
            => a > b ? a : b;

        public static short Min(this short a, short b)
            => a < b ? a : b;

        public static short Max(this short a, short b)
            => a > b ? a : b;

        /// <summary>
        /// 判断值是否在范围内
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="value">要判断的值</param>
        /// <param name="min">下限，最小值</param>
        /// <param name="max">上限，最大值</param>
        /// <param name="mode">决定是否包含上限或下限</param>
        /// <returns></returns>
        public static bool Between<T>(this T value, T min, T max, BetweenMode mode = BetweenMode.Open)
            where T : IComparable<T>
            => value.CompareTo(min) >= (mode.HasFlag(BetweenMode.ClosOpen) ? 0 : 1)
               && value.CompareTo(max) <= (mode.HasFlag(BetweenMode.OpenClose) ? 0 : -1);

        #endregion
    }
}
