using System.Runtime.CompilerServices;

namespace Sys.Com
{
    public static partial class CommonMethod
    {
        /// <summary>
        /// 内存复制函数
        /// </summary>
        /// <param name="destination">目标内存地址</param>
        /// <param name="source">源内存地址</param>
        /// <param name="length">复制的字节数</param>
        public static void CopyMemory<TD, TS>(ref TD destination, ref TS source, int length) where TD : unmanaged where TS : unmanaged
        {
            unsafe
            {
                fixed (void* pDest = &destination)
                {
                    fixed (void* pSrc = &source)
                    {
                        Unsafe.CopyBlock(pDest, pSrc, (uint)length);
                    }
                }
            }
        }

        /// <summary>
        /// 内存复制函数
        /// </summary>
        /// <param name="destination">目标内存地址</param>
        /// <param name="source">源内存指针</param>
        /// <param name="length">复制的字节数</param>
        public static void CopyMemory<TD>(ref TD destination, IntPtr source, int length) where TD : unmanaged
        {
            unsafe
            {
                fixed (void* pDest = &destination)
                {
                    Unsafe.CopyBlock(pDest, (void*)source, (uint)length);
                }
            }
        }

        /// <summary>
        /// 比较内存数据
        /// </summary>
        /// <param name="dest">目标内存地址</param>
        /// <param name="source">源内存地址</param>
        /// <param name="length">比较的字节数</param>
        /// <returns>返回值表示比较结果</returns>
        public static UIntPtr CompMemory<TD, TS>(ref TD dest, ref TS source, uint length) where TD : unmanaged where TS : unmanaged
        {
            unsafe
            {
                fixed (void* p1 = &dest)
                {
                    fixed (void* p2 = &source)
                    {
                        return PInvoke.RtlCompareMemory(p1, p2, length);
                    }
                }
            }
        }

        /// <summary>
        /// 将内存块从一个位置移动到另一个位置
        /// </summary>
        /// <param name="dest">目标内存地址</param>
        /// <param name="source">源内存地址</param>
        /// <param name="length">移动的字节数</param>
        public static void MoveMemory<TD>(ref TD dest, IntPtr source, int length) where TD : unmanaged
        {
            unsafe
            {
                fixed (void* pDest = &dest)
                {
                    Unsafe.CopyBlock(pDest, (void*)source, (uint)length);
                }
            }
        }
        /// <summary>
        /// 将内存块从一个位置移动到另一个位置
        /// </summary>
        /// <param name="dest">目标内存地址</param>
        /// <param name="source">源内存地址</param>
        /// <param name="length">移动的字节数</param>
        public static void MoveMemory<TS>(IntPtr dest, ref TS source, int length) where TS : unmanaged
        {
            unsafe
            {
                fixed (void* pSrc = &source)
                {
                    Unsafe.CopyBlock((void*)dest, pSrc, (uint)length);
                }
            }
        }

        /// <summary>
        /// 从指定内存地址读取数据
        /// </summary>
        /// <param name="dest">目标内存地址</param>
        /// <param name="source">源内存地址</param>
        /// <param name="length">读取的字节数</param>
        public static void ReadMemory(IntPtr dest, IntPtr source, int length)
        {
            unsafe
            {
                Unsafe.CopyBlock((void*)dest, (void*)source, (uint)length);
            }
        }

        /// <summary>
        /// 将数据写入指定内存地址
        /// </summary>
        /// <param name="dest">目标内存地址</param>
        /// <param name="source">源数据</param>
        /// <param name="length">写入的字节数</param>
        public static void WriteMemory<TS>(IntPtr dest, ref TS source, int length) where TS : unmanaged
        {
            unsafe
            {
                fixed (void* pSrc = &source)
                {
                    Unsafe.CopyBlock((void*)dest, pSrc, (uint)length);
                }
            }
        }

        /// <summary>
        /// 获取变量的内存地址
        /// </summary>
        /// <param name="ptr">变量</param>
        /// <returns>返回变量的内存地址</returns>
        [Obsolete("获取结构的指针")]
        public static IntPtr VarPtr<T>(ref T ptr) where T : unmanaged
        {
            unsafe
            {
                return (IntPtr)Unsafe.AsPointer(ref ptr);
            }
        }
    }
}
