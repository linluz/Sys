namespace Sys.Com.Key
{
    /// <summary>
    /// 指定虚拟键瞬时的硬件中断状态值
    /// </summary>
    public enum KeyState
    {
        /// <summary>
        /// 键当前未处于按下状态，而且自上次调用GetAsyncKeyState后该键也未被按过
        /// </summary>
        NotPressed = 0,

        /// <summary>
        /// 键当前未处于按下状态，但在此之前（自上次调用GetAsyncKeyState后）键曾经被按过
        /// </summary>
        PreviouslyPressed = 1,

        /// <summary>
        /// 键当前处于按下状态，但在此之前（自上次调用GetAsyncKeyState后）键未被按过
        /// </summary>
        CurrentlyPressed = 0x8000,

        /// <summary>
        /// 键当前处于按下状态，而且在此之前（自上次调用GetAsyncKeyState后）键也曾经被按过
        /// </summary>
        PreviouslyAndCurrentlyPressed = 0x8001
    }
}
