using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Linq;
using Sys.Extensions;

namespace Sys.Com.String.CodePage;

/// <summary>
/// 表示代码页的详细信息（与 Win32 API <c>CPINFOEX</c> 结构对应）。
/// 通过调用 <see href="https://docs.microsoft.com/windows/desktop/api/winnls/nf-winnls-getcpinfoexa">GetCPInfoEx</see>
/// 可获取指定代码页的最大字符长度、默认替代字符、前导字节范围、Unicode 默认字符、代码页标识以及本地化的代码页名称等信息。
/// </summary>
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
public unsafe struct CpInfoEx
{
    /// <summary>
    /// 指定该代码页中一个字符的最大字节数。
    ///  <see href="https://docs.microsoft.com/windows/desktop/Intl/single-byte-character-sets">单字节字符集</see>（SBCS）通常为 1，
    ///  <see href="https://docs.microsoft.com/windows/desktop/Intl/double-byte-character-sets">双字节字符集</see>（DBCS）通常为 2，
    /// 某些字符集可能大于 2。注意：仅依靠该值无法区分 SBCS/DBCS，因为还可能受其他编码机制（如 ISCII、ISO‑2022‑xx）影响。
    /// </summary>
    public uint MaxCharSize;

    /// <summary>
    /// 将 Unicode 转换为指定代码页时使用的默认替代字符（当未显式指定时）。
    /// 通常为问号字符 "?"。当使用 <see href="https://docs.microsoft.com/windows/desktop/api/stringapiset/nf-stringapiset-widechartomultibyte">WideCharToMultiByte</see>
    /// 进行转换且遇到无法映射的字符时，可能会使用该替代字符。
    /// </summary>
    public fixed byte DefaultChar[2];

    /// <summary>
    /// 前导字节范围表（固定长度数组）。若代码页无前导字节（非 DBCS），数组所有元素均为 <b>null</b>。
    /// 若存在前导字节，则以“起始值-结束值”为一组描述每个范围（含端点），最多 5 组，以两个 null bytes 作为终止。
    /// <b>注意</b>：部分代码页可能同时使用前导字节与其他机制，本成员通常仅在使用前导字节的代码页中填充。
    /// 详见 <see href="https://learn.microsoft.com/windows/win32/api/winnls/ns-winnls-cpinfoexw#members">CPINFOEX 成员说明</see>。
    /// </summary>
    public fixed byte LeadByte[12];

    /// <summary>
    /// 从指定代码页转换到 Unicode 时使用的默认 Unicode 替代字符。
    /// 通常为问号字符或片假名中点字符。当 <see href="https://docs.microsoft.com/windows/desktop/api/stringapiset/nf-stringapiset-multibytetowidechar">MultiByteToWideChar</see>函数
    /// 遇到无法映射的字节序列时使用。
    /// </summary>
    public char UnicodeDefaultChar;

    /// <summary>
    /// 代码页标识（与 <see href="https://docs.microsoft.com/windows/desktop/api/winnls/nf-winnls-getcpinfoexa">GetCPInfoEx</see>
    /// 传入的代码页参数一致）。参见 <see href="https://docs.microsoft.com/windows/desktop/Intl/code-page-identifiers">代码页标识</see>
    /// 中常见 ANSI 及其他代码页编号列表。
    /// </summary>
    internal uint CodePage;

    /// <summary>
    /// 代码页的完整名称。该名称为本地化字符串，不保证在不同系统版本或计算机之间的唯一性与一致性。
    /// </summary>
    private fixed byte _codePageName[CodePageNameLength];

    private const int CodePageNameLength = 260;
    /// <summary>
    /// 节名(最大8个单字节字符)
    /// </summary>
    public string CodePageName
    {
        get => Encoding.ASCII.GetString(CodePageNameArray.ToArray());//todo 此处是否可能会本地化成中文  待测试
        set => CodePageNameArray = (value ?? throw new ArgumentNullException(nameof(value))).ToLimitAsciiBytes(CodePageNameLength);//todo 此处是否可能会本地化成中文  待测试
    }

    /// <summary>
    /// 节名(最大8个单字节字符)
    /// </summary>

    private Span<byte> CodePageNameArray
    {
        get
        {
            fixed (byte* ptr = _codePageName)
            {
                return new Span<byte>(ptr, CodePageNameLength);
            }
        }
        set
        {
            if (value is not { Length: CodePageNameLength })
                throw new ArgumentException($"{nameof(CodePageNameArray)} must be length {CodePageNameLength}");
            value.CopyTo(CodePageNameArray);
        }
    }
}