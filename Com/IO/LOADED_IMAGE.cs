using System.Runtime.InteropServices;

namespace Sys.Com.IO
{
    /// <summary>
    /// 表示一个已加载的映像的结构。
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct LOADED_IMAGE
    {
        /// <summary>
        /// 模块名称。
        /// </summary>
        public IntPtr ModuleName;

        /// <summary>
        /// 文件句柄。
        /// </summary>
        public IntPtr hFile;

        /// <summary>
        /// 映射地址。
        /// </summary>
        public IntPtr MappedAddress;

        /// <summary>
        /// 文件头。
        /// </summary>
        public IntPtr FileHeader;

        /// <summary>
        /// 最后一个RVA节。
        /// </summary>
        public IntPtr LastRvaSection;

        /// <summary>
        /// 节的数量。
        /// </summary>
        public IntPtr NumberOfSections;

        /// <summary>
        /// 第一个RVA节。
        /// </summary>
        public IntPtr FirstRvaSection;

        /// <summary>
        /// 特征。
        /// </summary>
        public IntPtr Characteristics;

        /// <summary>
        /// 是否为系统映像。
        /// </summary>
        public IntPtr fSystemImage;

        /// <summary>
        /// 是否为DOS映像。
        /// </summary>
        public IntPtr fDOSImage;

        /// <summary>
        /// 是否为只读。
        /// </summary>
        public IntPtr fReadOnly;

        /// <summary>
        /// 版本。
        /// </summary>
        public IntPtr Version;

        /// <summary>
        /// 链接。
        /// </summary>
        public IntPtr Links;

        /// <summary>
        /// 映像的大小。
        /// </summary>
        public IntPtr SizeOfImage;
    }
}
