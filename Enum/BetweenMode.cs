namespace Sys.Enum;

/// <summary>
/// 是否包含上下限
/// </summary>
[Flags]
public enum BetweenMode : short
{
    /// <summary>
    /// 开区间，不含上下限
    /// </summary>
    Open,

    /// <summary>
    /// 左闭右开区间，含下限
    /// </summary>
    ClosOpen,

    /// <summary>
    /// 左开右闭区间，含上限
    /// </summary>
    OpenClose,

    /// <summary>
    /// 闭区间，含上下限
    /// </summary>
    Close = OpenClose | ClosOpen
}