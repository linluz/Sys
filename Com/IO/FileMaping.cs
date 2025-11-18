namespace Sys.Com.IO
{
    [Flags]
    public enum FileMapping : uint
    {
        #region PAGE 只能选择一个

        PAGE_READONLY = 0x02, // 只读
        PAGE_READWRITE = 0x04, // 读写
        PAGE_WRITECOPY = 0x08, // 写拷贝
        PAGE_EXECUTE = 0x10, // 执行
        PAGE_EXECUTE_READ = 0x20, // 可执行读
        PAGE_EXECUTE_READWRITE = 0x40, // 可执行读写
        PAGE_EXECUTE_WRITECOPY = 0x80, // 可执行写拷贝

        #endregion

        #region SEC

        SEC_IMAGE = 0x1000000, // 映像
        SEC_RESERVE = 0x4000000, // 保留
        SEC_COMMIT = 0x8000000, // 提交
        SEC_NOCACHE = 0x10000000, // 不缓存
        SEC_IMAGE_NO_EXECUTE = 0x11000000, // 映像不可执行
        SEC_LARGE_PAGES = 0x80000000, // 大页
        SEC_WRITECOMBINE = 0x40000000, // 写合并

        #endregion

        #region GENERIC

        GENERIC_WRITE = 0x40000000, // 通用写
        GENERIC_READ = 0x80000000, // 通用读

        #endregion

        #region OPEN

        OPEN_EXISTING = 3, // 打开已存在
        OPEN_ALWAYS = 4, // 打开或创建

        #endregion

        #region FILE_MAP

        FILE_MAP_COPY = 0x01, // 拷贝映射
        FILE_MAP_WRITE = 0x02, // 写映射
        FILE_MAP_READ = 0x04, // 读映射
        FILE_MAP_ALL_ACCESS = 0x02 | 0x04, // 全部访问权限
        FILE_MAP_EXECUTE = 0x20, // 执行映射

        #endregion

        #region FILE_SHARE

        FILE_SHARE_READ = 0x01, // 共享读
        FILE_SHARE_WRITE = 0x02, // 共享写

        #endregion

        #region FILE_ATTRIBUTE

        FILE_ATTRIBUTE_READONLY = 0x01, // 只读文件
        FILE_ATTRIBUTE_HIDDEN = 0x02, // 隐藏文件
        FILE_ATTRIBUTE_SYSTEM = 0x04, // 系统文件
        FILE_ATTRIBUTE_ARCHIVE = 0x20, // 存档文件
        FILE_ATTRIBUTE_NORMAL = 0x80 // 普通文件

        #endregion
    }
}
