using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Sys.Com.Att;

namespace Sys.Com.IO
{
    [SupportedOSPlatform("windows5.1.2600")]
    /// <summary>
    /// 用于文件映射函数
    /// </summary>
    public static class FileMapMethod
    {
        /// <summary>
        ///为指定文件创建或打开命名或未命名的文件映射对象。
        /// </summary>
        /// <param name="hFile">要从中创建文件映射对象的文件的句柄。</param>
        /// <param name="flProtect">访问权限,指定文件映射对象的页保护。 对象的所有映射视图都必须与此保护兼容。</param>
        /// <param name="dwMaximumSizeHigh">文件映射对象的最大大小（高位）</param>
        /// <param name="dwMaximumSizeLow">文件映射对象的最大大小（低位）</param>
        /// <param name="lpName">文件映射对象的名称。</param>
        /// <returns>如果函数成功，则返回值是新创建的文件映射对象的句柄。
        /// 如果对象在函数调用之前存在，则函数将返回一个句柄，该句柄指向现有对象(其当前大小，而不是指定大小) ，
        /// 如果函数失败，则返回值为 NULL。</returns>
        public static IntPtr CreateFileMapping(IntPtr hFile, FileMapping flProtect, uint dwMaximumSizeHigh, uint dwMaximumSizeLow,  string? lpName = null)
        {
            unsafe
            {
                fixed (char* name = lpName)
                {
                    return PInvoke.CreateFileMapping((HANDLE)hFile, (SECURITY_ATTRIBUTES*)IntPtr.Zero, (PAGE_PROTECTION_FLAGS)(int)flProtect,
                        dwMaximumSizeHigh, dwMaximumSizeLow, name);
                }
            }
        }
        /// <summary>
        /// 将文件映射到内存中的外部方法
        /// </summary>
        /// <param name="hFileMappingObject">文件映射对象的句柄</param>
        /// <param name="dwDesiredAccess">映射的访问权限</param>
        /// <param name="dwFileOffsetHigh">文件偏移的高32位</param>
        /// <param name="dwFileOffsetLow">文件偏移的低32位</param>
        /// <param name="dwNumberOfBytesToMap">要映射的字节数</param>
        /// <returns>映射到内存中的指针</returns>
        public static IntPtr MapViewOfFile(int hFileMappingObject, int dwDesiredAccess, uint dwFileOffsetHigh, uint dwFileOffsetLow, uint dwNumberOfBytesToMap)
        {
            unsafe
            {
                return (IntPtr)(void*)PInvoke.MapViewOfFile((HANDLE)(IntPtr)hFileMappingObject, (FILE_MAP)dwDesiredAccess,
                    dwFileOffsetHigh, dwFileOffsetLow, dwNumberOfBytesToMap);
            }
        }

        /// <summary>
        ///为指定文件创建或打开命名或未命名的文件映射对象。
        /// </summary>
        /// <param name="hFile">要从中创建文件映射对象的文件的句柄。</param>
        /// <param name="lpFileMappingAttributes">文件映射对象的属性,指向 SECURITY_ATTRIBUTES 结构的指针，该结构确定返回的句柄是否可以由子进程继承。 SECURITY_ATTRIBUTES 结构的 lpSecurityDescriptor 成员为新的文件映射对象指定安全描述符。</param>
        /// <param name="flProtect">访问权限,指定文件映射对象的页保护。 对象的所有映射视图都必须与此保护兼容。</param>
        /// <param name="dwMaximumSizeHigh">文件映射对象的最大大小（高位）</param>
        /// <param name="dwMaximumSizeLow">文件映射对象的最大大小（低位）</param>
        /// <param name="lpName">文件映射对象的名称。</param>
        /// <returns>如果函数成功，则返回值是新创建的文件映射对象的句柄。
        /// 如果对象在函数调用之前存在，则函数将返回一个句柄，该句柄指向现有对象(其当前大小，而不是指定大小) ，
        /// 如果函数失败，则返回值为 NULL。</returns>
        internal static SafeFileHandle CreateFileMapping(SafeFileHandle hFile, PAGE_PROTECTION_FLAGS flProtect, uint dwMaximumSizeHigh, uint dwMaximumSizeLow, SECURITY_ATTRIBUTES? lpFileMappingAttributes = null, string? lpName = null)
        => PInvoke.CreateFileMapping(hFile, lpFileMappingAttributes, flProtect, dwMaximumSizeHigh, dwMaximumSizeLow, lpName);

        /// <summary>
        /// 将文件映射到内存中的外部方法
        /// </summary>
        /// <param name="hFileMappingObject">文件映射对象的句柄</param>
        /// <param name="dwDesiredAccess">映射的访问权限</param>
        /// <param name="dwFileOffsetHigh">文件偏移的高32位</param>
        /// <param name="dwFileOffsetLow">文件偏移的低32位</param>
        /// <param name="dwNumberOfBytesToMap">要映射的字节数</param>
        /// <returns>映射到内存中的指针</returns>
        internal static MEMORY_MAPPED_VIEW_ADDRESS MapViewOfFile(SafeFileHandle hFileMappingObject, FILE_MAP dwDesiredAccess, uint dwFileOffsetHigh, uint dwFileOffsetLow, uint dwNumberOfBytesToMap)
        => PInvoke.MapViewOfFile(hFileMappingObject, dwDesiredAccess, dwFileOffsetHigh, dwFileOffsetLow, dwNumberOfBytesToMap);

        /// <summary>
        /// 映射一个文件到进程的地址空间
        /// </summary>
        /// <param name="hFileMappingObject">文件映射对象的句柄</param>
        /// <param name="dwDesiredAccess">访问映射视图的方式</param>
        /// <param name="dwFileOffsetHigh">文件偏移的高32位</param>
        /// <param name="dwFileOffsetLow">文件偏移的低32位</param>
        /// <param name="dwNumberOfBytesToMap">要映射的字节数</param>
        /// <param name="lpBaseAddress">映射视图的基地址</param>
        /// <returns>映射视图的基地址</returns>
        internal static MEMORY_MAPPED_VIEW_ADDRESS MapViewOfFileEx(SafeFileHandle hFileMappingObject, FILE_MAP dwDesiredAccess, uint dwFileOffsetHigh, uint dwFileOffsetLow, uint dwNumberOfBytesToMap, IntPtr lpBaseAddress)
        {
            unsafe
            {
                return PInvoke.MapViewOfFileEx(hFileMappingObject, dwDesiredAccess, dwFileOffsetHigh, dwFileOffsetLow,
                    dwNumberOfBytesToMap, lpBaseAddress.ToPointer());
            }
        }

        /// <summary>
        /// 取消映射指定地址的文件视图
        /// </summary>
        /// <param name="lpBaseAddress">要取消映射的文件视图的基地址</param>
        /// <returns>如果取消映射成功，则为 true；否则为 false。</returns>
        public static bool UnmapViewOfFile(int lpBaseAddress)
        {
            unsafe
            {
                return PInvoke.UnmapViewOfFile((MEMORY_MAPPED_VIEW_ADDRESS)(void*)lpBaseAddress);
            }
        }

        /// <summary>
        /// 取消映射指定地址的文件视图
        /// </summary>
        /// <param name="lpBaseAddress">要取消映射的文件视图的基地址</param>
        /// <returns>如果取消映射成功，则为 true；否则为 false。</returns>
        internal static bool UnmapViewOfFile(MEMORY_MAPPED_VIEW_ADDRESS lpBaseAddress)
        => PInvoke.UnmapViewOfFile(lpBaseAddress);

        /// <summary>
        /// 刷新指定内存区域的修改到文件
        /// </summary>
        /// <param name="lpBaseAddress">要刷新的内存区域的起始地址</param>
        /// <param name="dwNumberOfBytesToFlush">要刷新的字节数</param>
        /// <returns>如果刷新成功，则为 true；否则为 false。</returns>
        internal static bool FlushViewOfFile(IntPtr lpBaseAddress, uint dwNumberOfBytesToFlush)
        {
            unsafe
            {
                return PInvoke.FlushViewOfFile(lpBaseAddress.ToPointer(), dwNumberOfBytesToFlush);
            }
        }

        /// <summary>
        /// 加载指定的映像文件，并将其映射到内存中
        /// </summary>
        /// <param name="imageName">要加载的映像文件的名称,不能含中文</param>
        /// <param name="dllPath">映像文件的路径,不能含中文</param>
        /// <param name="loadedImage">加载的映像文件的信息</param>
        /// <param name="dotDll">指示是否为DLL文件</param>
        /// <param name="readOnly">指示是否以只读方式加载</param>
        /// <returns>如果加载成功，则为 true；否则为 false。</returns>
        /// <remarks>CSWin32无，Metadata有</remarks>
        public static bool MapAndLoad(string imageName, string dllPath, out LOADED_IMAGE loadedImage, bool dotDll,
            bool readOnly)
        {
            unsafe
            {
                PSTR str1 = imageName.GetHGlobalAnsi();
                PSTR str2 = dllPath.GetHGlobalAnsi();
                try
                {
                    fixed (LOADED_IMAGE* p2 = &loadedImage)
                    {
                        return NativeMethods.MapAndLoad(str1, str2, p2, dotDll, readOnly);
                    }
                }
                finally
                {
                    str1.Free();
                    str2.Free();
                }
            }
        }

        /// <summary>
        /// 取消映射指定的映像文件并释放相关资源
        /// </summary>
        /// <param name="loadedImage">要取消映射的映像文件的信息</param>
        /// <returns>如果取消映射成功，则为 true；否则为 false。</returns>
        /// <remarks>CSWin32无，Metadata有</remarks>
        public static bool UnMapAndLoad(ref LOADED_IMAGE loadedImage)
        {
            unsafe
            {
                fixed (LOADED_IMAGE* p = &loadedImage)
                {
                    return NativeMethods.UnMapAndLoad(p);
                }
            }
        }
        [SupportedOSPlatform("windows5.1.2600")]
        private static class NativeMethods
        {

            //[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            //internal static extern IntPtr CreateFileMapping(IntPtr hFile, [Optional] IntPtr lpFileMappingAttributes,
            //    FileMapping flProtect, uint dwMaximumSizeHigh, uint dwMaximumSizeLow, [Optional] string lpName);
            //[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            //internal static extern IntPtr MapViewOfFile(IntPtr hFileMappingObject, FileMapping dwDesiredAccess,
            //    uint dwFileOffsetHigh, uint dwFileOffsetLow, uint dwNumberOfBytesToMap);
            //[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            //internal static extern IntPtr MapViewOfFileEx(IntPtr hFileMappingObject, FileMapping dwDesiredAccess,
            //    uint dwFileOffsetHigh, uint dwFileOffsetLow, uint dwNumberOfBytesToMap, IntPtr lpBaseAddress);
            //[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            //internal static extern bool UnmapViewOfFile(IntPtr lpBaseAddress);
            //[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            //internal static extern bool FlushViewOfFile(IntPtr lpBaseAddress, uint dwNumberOfBytesToFlush);
          
            [Documentation("https://learn.microsoft.com/windows/win32/api/imagehlp/nf-imagehlp-mapandload")]
            [DllImport("imagehlp.dll", ExactSpelling = true, PreserveSig = false, SetLastError = true)]
            public static extern unsafe BOOL MapAndLoad([Const][In] PSTR imageName, [Const][In][Optional] PSTR dllPath, [Out] LOADED_IMAGE* loadedImage, [In] BOOL dotDll, [In] BOOL readOnly);

            [Documentation("https://learn.microsoft.com/windows/win32/api/imagehlp/nf-imagehlp-unmapandload")]
            [DllImport("imagehlp.dll", ExactSpelling = true, PreserveSig = false, SetLastError = true)]
            public static extern unsafe BOOL UnMapAndLoad([In][Out] LOADED_IMAGE* loadedImage);
        }
    }
}
