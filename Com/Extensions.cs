using System.Runtime.InteropServices;

namespace Sys.Com
{
    internal static class Extensions
    {
        /// <summary>
        /// 释放转换PWSTR类的缓冲区，若转换为字串输出，则无需释放，否则一定要用完后释放
        /// </summary>
        /// <param name="o">转换PWSTR类的缓冲区</param>
        public static unsafe void Free(this PWSTR o) => Marshal.FreeHGlobal(new IntPtr(o.Value));
        public static unsafe void Free(this PSTR o) => Marshal.FreeHGlobal(new IntPtr(o.Value));

        public static void Free(this IntPtr p) => Marshal.FreeHGlobal(p);
        public static IntPtr GetArrayPtr<T>(this T[] a) => Marshal.UnsafeAddrOfPinnedArrayElement(a, 0);
        /// <summary>
        /// 建立指定大小的文本缓冲区并输出起始指针
        /// </summary>
        /// <param name="size">缓冲区大小</param>
        /// <returns>起始指针</returns>
        internal static unsafe char* GetStrBuffer(this int size)
            => (char*)Marshal.AllocHGlobal(size * Marshal.SizeOf<char>());
        /// <summary>
        /// 建立指定大小的缓冲区并输出起始指针
        /// </summary>
        /// <param name="size">缓冲区大小,单位字节</param>
        /// <returns>起始指针</returns>
        internal static IntPtr GetBuffer(this int size)
            => Marshal.AllocHGlobal(size);
        /// <summary>
        /// 将字串转换为Ansi的指针
        /// </summary>
        /// <param name="str">要转换的字串，不能含ascii外的字符（如中文）</param>
        /// <returns>指针，使用完需手动销毁</returns>
        internal static unsafe byte* GetHGlobalAnsi(this string str)
            => (byte*)Marshal.StringToHGlobalAnsi(str);
    }
}
