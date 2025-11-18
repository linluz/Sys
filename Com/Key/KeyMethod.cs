using System.Runtime.Versioning;

namespace Sys.Com.Key
{
    [SupportedOSPlatform("windows6.0")]
    public static class KeyMethod
    {
        /// <summary>
        /// 获取鼠标按键状态
        /// </summary>
        /// <param name="vKey"></param>
        /// <returns>
        /// 指定虚拟键瞬时的硬件中断状态值，它有四种返回值：
        /// 0 键当前未处于按下状态，而且自上次调用GetAsyncKeyState后该键也未被按过
        /// 1 键当前未处于按下状态，但在此之前（自上次调用GetAsyncKeyState后）键曾经被按过
        /// -32768（即0x8000）键当前处于按下状态，但在此之前（自上次调用GetAsyncKeyState后）键未被按过
        /// -32767（即0x8001）键当前处于按下状态，而且在此之前（自上次调用GetAsyncKeyState后）键也曾经被按过
        /// </returns>
        //bug KeyState与short的范围不一致 待http://www.pinvoke.net/恢复后确定确定
        public static KeyState GetAsyncKeyState(VirtualKey vKey)
            => (KeyState)PInvoke.GetAsyncKeyState((int)vKey);
    }
}
