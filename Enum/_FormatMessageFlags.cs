namespace Sys.Enum
{
    /// <summary>
    /// <see cref="https://learn.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-formatmessage">
    ///错误消息定义
    /// </see>
    /// </summary>
    [Flags]
    public enum _FormatMessageFlags : uint
    {      /// <summary>
           ///     The function allocates a buffer large enough to hold the formatted message, and places a pointer to the allocated
           ///     buffer at the address specified by lpBuffer. The nSize parameter specifies the minimum number of TCHARs to allocate
           ///     for an output message buffer. The caller should use the LocalFree function to free the buffer when it is no longer
           ///     needed.
           ///     <para>
           ///         If the length of the formatted message exceeds 128K bytes, then FormatMessage will fail and a subsequent call
           ///         to <see cref="GetLastError" /> will return <see cref="Win32ErrorCode.ERROR_MORE_DATA" />.
           ///     </para>
           ///     <para>
           ///         In previous versions of Windows, this value was not available for use when compiling Windows Store apps. As
           ///         of Windows 10 this value can be used.
           ///     </para>
           ///     <para>
           ///         Windows Server 2003 and Windows XP: If the length of the formatted message exceeds 128K bytes, then
           ///         FormatMessage will not automatically fail with an error of <see cref="Win32ErrorCode.ERROR_MORE_DATA" />.
           ///     </para>
           ///     <para>
           ///         Windows 10: LocalFree is not in the modern SDK, so it cannot be used to free the result buffer. Instead, use
           ///         HeapFree (GetProcessHeap(), allocatedMessage). In this case, this is the same as calling LocalFree on memory.
           ///     </para>
           ///     <para>
           ///         Important: LocalAlloc() has different options: LMEM_FIXED, and LMEM_MOVABLE. FormatMessage() uses LMEM_FIXED,
           ///         so HeapFree can be used. If LMEM_MOVABLE is used, HeapFree cannot be used.
           ///     </para>
           /// </summary>
        FORMAT_MESSAGE_ALLOCATE_BUFFER = 0x100,

        /// <summary>
        ///     The Arguments parameter is not a va_list structure, but is a pointer to an array of values that represent the
        ///     arguments. This flag cannot be used with 64-bit integer values. If you are using a 64-bit integer, you must use the
        ///     va_list structure.
        /// </summary>
        FORMAT_MESSAGE_ARGUMENT_ARRAY = 0x2000,

        /// <summary>
        ///     The lpSource parameter is a module handle containing the message-table resource(s) to search. If this lpSource
        ///     handle is NULL, the current process's application image file will be searched. This flag cannot be used with
        ///     <see cref="FORMAT_MESSAGE_FROM_STRING" />.
        ///     <para>
        ///         If the module has no message table resource, the function fails with
        ///         <see cref="Win32ErrorCode.ERROR_RESOURCE_TYPE_NOT_FOUND" />.
        ///     </para>
        /// </summary>
        FORMAT_MESSAGE_FROM_HMODULE = 0x800,

        /// <summary>
        ///     The lpSource parameter is a pointer to a null-terminated string that contains a message definition. The
        ///     message definition may contain insert sequences, just as the message text in a message table resource may. This
        ///     flag cannot be used with <see cref="FORMAT_MESSAGE_FROM_HMODULE" /> or <see cref="FORMAT_MESSAGE_FROM_SYSTEM" />.
        /// </summary>
        FORMAT_MESSAGE_FROM_STRING = 0x400,
        /// <summary>
        /// 将忽略消息定义中的插入序列（如 %1），并将其传递到未更改的输出缓冲区。
        /// 此标志可用于提取消息以便以后进行格式设置。 如果设置了此标志，则忽略 Arguments 参数。
        /// </summary>
        FORMAT_MESSAGE_IGNORE_INSERTS = 0x200,
        /// <summary>
        /// 	函数应在系统消息表资源搜索请求的消息。
        /// 如果使用 FORMAT_MESSAGE_FROM_HMODULE 指定此标志，则如果在 lpSource 指定的模块中找不到该消息，则函数将搜索系统消息表。
        /// 此标志不能与 FORMAT_MESSAGE_FROM_STRING一起使用。
        /// </summary>
        FORMAT_MESSAGE_FROM_SYSTEM = 0x1000,
        /// <summary>
        ///     The function ignores regular line breaks in the message definition text. The function stores hard-coded line breaks
        ///     in the message definition text into the output buffer. The function generates no new line breaks.
        ///     <para>
        ///         Without this flag set: There are no output line width restrictions. The function stores line breaks that are
        ///         in the message definition text into the output buffer. It specifies the maximum number of characters in an
        ///         output line. The function ignores regular line breaks in the message definition text. The function never splits
        ///         a string delimited by white space across a line break. The function stores hard-coded line breaks in the
        ///         message definition text into the output buffer. Hard-coded line breaks are coded with the %n escape sequence.
        ///     </para>
        /// </summary>
        FORMAT_MESSAGE_MAX_WIDTH_MASK = 0xff,
    }
}
