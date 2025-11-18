using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Windows.Win32.System.Registry;

namespace Sys.Com.Reg
{
    public static class RegConst
    {
        public const string SE_RESTORE_NAME = "SeRestorePrivilege";
        public const string SE_BACKUP_NAME = "SeBackupPrivilege";
    }

    [SupportedOSPlatform("windows5.1.2600")]
    public static class RegMethod
    {
        /// <summary>
        /// 关闭指定注册表项的句柄。
        /// </summary>
        /// <param name="hKey">要关闭的打开键的句柄。
        /// 该句柄必须已由 RegCreateKeyEx、RegCreateKeyTransacted、RegOpenKeyEx、RegOpenKeyTransacted 或 RegConnectRegistry 函数打开。</param>
        /// <returns>
        /// 如果函数成功，则返回值为 ERROR_SUCCESS。
        /// 如果函数失败，则返回值为 Winerror.h 中定义的非零错误代码。
        /// 可以将 FormatMessage 函数与 FORMAT_MESSAGE_FROM_SYSTEM 标志一起使用，以获取错误的泛型说明。
        /// </returns>
        [Obsolete("请使用net自带的注册表函数")]
        internal static WIN32_ERROR RegCloseKey(HKEY hKey)
            => PInvoke.RegCloseKey(hKey);

        /// <summary>
        ///打开指定的注册表项。
        /// </summary>
        /// <param name="hKey">打开的注册表项的句柄。 此句柄由 RegCreateKeyEx 或 RegOpenKeyEx 函数返回，
        /// 也可以是以下 预定义键之一：
        /// HKEY_CLASSES_ROOT 、
        /// HKEY_CURRENT_CONFIG 、
        /// HKEY_CURRENT_USER、
        /// HKEY_LOCAL_MACHINE 、
        /// HKEY_USERS</param>
        /// <param name="lpSubKey">要打开的注册表项的名称。
        /// 此键必须是 由 hKey 参数标识的键的子项。
        /// 键名称不区分大小写。如果此参数为 NULL 或指向空字符串的指针，则该函数将返回传入的同一句柄。</param>
        /// <param name="phkResult">一个变量的指针，此变量指向已打开键的句柄。 如果该键不是预定义的注册表项之一，请在使用完句柄后调用 RegCloseKey 函数。</param>
        /// <returns>
        /// 如果函数成功，则返回值为 ERROR_SUCCESS。
        /// 如果函数失败，则返回值为 Winerror.h 中定义的非零错误代码。 可以将 FormatMessage 函数与
        /// </returns>
        [Obsolete("请使用net自带的注册表函数")]
        internal static WIN32_ERROR RegOpenKey(SafeRegistryHandle hKey, string lpSubKey,
            out SafeRegistryHandle phkResult)
            => PInvoke.RegOpenKey(hKey, lpSubKey, out phkResult);

        /// <summary>
        /// 枚举指定打开的注册表项的值。 每次调用该函数时，该函数都会为键复制一个索引值名称和数据块。
        /// </summary>
        /// <param name="hKey">打开的注册表项的句柄。 密钥必须已使用KEY_QUERY_VALUE访问权限打开。</param>
        /// <param name="dwIndex">要检索的值的索引。 对于第一次调用 RegEnumValue 函数，此参数应为零，然后在后续调用中递增。</param>
        /// <param name="lpValueName">指向缓冲区的指针，该缓冲区接收以 null 结尾的字符串形式的值名称。</param>
        /// <param name="lpcbValueName">指向变量的指针，该变量指定 lpValueName 参数指向的缓冲区的大小（以字符为单位）。 当函数返回时，变量接收存储在缓冲区中的字符数，不包括终止 null 字符。</param>
        /// <param name="lpType">指向变量的指针，该变量接收指示存储在指定值中的数据类型的代码。 有关可能的类型代码的列表，请参阅 <see cref="https://learn.microsoft.com/zh-cn/windows/desktop/SysInfo/registry-value-types">注册表值类型</see>。 如果不需要类型代码， 则 lpType 参数可以为 NULL 。</param>
        /// <param name="lpData">指向接收值条目数据的缓冲区的指针。 如果不需要数据，此参数可以为 NULL 。</param>
        /// <param name="lpcbData">指向变量的指针，该变量指定 lpData 参数指向的缓冲区的大小（以字节为单位）。 当函数返回时，变量接收存储在缓冲区中的字节数。仅lpData为null时可以为null</param>
        /// <returns>
        /// 如果函数成功，则返回值为 ERROR_SUCCESS。
        /// 如果函数失败，则返回值为 系统错误代码。 如果没有其他可用值，该函数将返回ERROR_NO_MORE_ITEMS。
        /// 如果 lpValueName 或 lpData 指定的缓冲区太小而无法接收值，则函数将返回ERROR_MORE_DATA。
        /// </returns>
        //<param name="lpReserved">此参数是保留的，必须为 NULL。</param>
        [Obsolete("请使用net自带的注册表函数")]
        internal static WIN32_ERROR RegEnumValue(SafeRegistryHandle hKey, uint dwIndex, out string lpValueName, ref uint lpcbValueName,
            IntPtr? lpType = null, byte[]? lpData = null, IntPtr? lpcbData = null)
        {
            unsafe
            {
                fixed (byte* d=lpData)
                {
                    PWSTR str = ((int)lpcbValueName).GetStrBuffer();
                    var resu = PInvoke.RegEnumValue(hKey, dwIndex, str, ref lpcbValueName,
                        lpType.HasValue ? (uint*)lpType.Value : null,
                        lpData != null ? d : null,
                        lpcbData.HasValue ? (uint*)lpcbData.Value : null);
                    lpValueName = str.ToString();
                    return resu;
                }
            }
        }

        /// <summary>
        /// 打开指定的注册表项。 请注意，键名称不区分大小写。
        /// </summary>
        [Obsolete("请使用net自带的注册表函数")]
        internal static WIN32_ERROR RegOpenKeyEx(SafeRegistryHandle hkey, string lpSubKey, uint ulOptions,
            REG_SAM_FLAGS samDesired, out SafeRegistryHandle phkResult)
            => PInvoke.RegOpenKeyEx(hkey, lpSubKey, ulOptions, samDesired, out phkResult);

        /// <summary>
        /// 以标准格式将指定的键及其所有子项和值保存到新文件中。
        /// </summary>
        [Obsolete("请使用net自带的注册表函数")]
        internal static WIN32_ERROR RegSaveKey(SafeRegistryHandle hkey, string lpFile,SECURITY_ATTRIBUTES? lpSecurityAttributes) 
            => PInvoke.RegSaveKey(hkey, lpFile, lpSecurityAttributes);

        /// <summary>
        /// 读取指定文件中的注册表信息，并将其复制到指定的键上。 此注册表信息可能采用一个键和多个级别的子项的形式。
        /// </summary>
        /// <param name="hkey"></param>
        /// <param name="lpFile"></param>
        /// <param name="dwFlags"></param>
        /// <returns></returns>
        [Obsolete("请使用net自带的注册表函数")]
        internal static WIN32_ERROR RegRestoreKey(SafeRegistryHandle hkey, string lpFile, REG_RESTORE_KEY_FLAGS dwFlags)
            => PInvoke.RegRestoreKey(hkey, lpFile, dwFlags);

        /// <summary>
        /// 打开与进程关联的访问令牌。
        /// </summary>
        [Obsolete("请使用net自带的注册表函数")]
        internal static bool OpenProcessToken(SafeProcessHandle processHandle, TOKEN_ACCESS_MASK desiredAccess,
            out SafeFileHandle tokenHandle)
            => PInvoke.OpenProcessToken(processHandle, desiredAccess, out tokenHandle);

        /// <summary>
        /// 检索当前进程的伪句柄。
        /// </summary>
        [Obsolete("请使用net自带的注册表函数")]
        internal static SafeProcessHandle GetCurrentProcess()
            => new(PInvoke.GetCurrentProcess(), ownsHandle: false);

        /// <summary>
        /// 检索指定系统上使用的本地唯一标识符(LUID)，以在本地表示指定的特权名称。(Unicode)
        /// </summary>
        [Obsolete("请使用net自带的注册表函数")]
        internal static bool LookupPrivilegeValue(string lpSystemName, string lpName, out LUID lpLuid)
            => PInvoke.LookupPrivilegeValue(lpSystemName, lpName, out lpLuid);

        /// <summary>
        /// 启用或禁用指定访问令牌中的特权。 在访问令牌中启用或禁用权限需要TOKEN_ADJUST_PRIVILEGES访问权限。
        /// </summary>
        /// <param name="tokenHandle">访问令牌的句柄，其中包含要修改的权限。</param>
        /// <param name="disableAllPriv">指定函数是否禁用令牌的所有特权。 如果此值为 TRUE，则函数将禁用所有特权并忽略 NewState 参数。 如果为 FALSE，则函数根据 NewState 参数指向的信息修改权限。</param>
        /// <param name="previousState">指向函数用 TOKEN_PRIVILEGES 结构填充的缓冲区的指针，该结构包含函数修改的任何特权的先前状态。 </param>
        /// <param name="returnLength">指向变量的指针，该变量接收 PreviousState 参数指向的缓冲区的所需大小（以字节为单位）。 如果 PreviousState 为 NULL，此参数可以为 NULL。</param>
        /// <param name="newState">指向 TOKEN_PRIVILEGES 结构的指针，该结构指定特权数组及其属性。</param>
        /// <param name="bufferLength">指定 PreviousState 参数指向的缓冲区的大小（以字节为单位）。 如果 PreviousState 参数为 NULL，则此参数可以为 零。</param>
        /// <returns>是否成功</returns>
        [Obsolete("请使用net自带的注册表函数")]
        internal static bool AdjustTokenPrivileges(SafeFileHandle tokenHandle, bool disableAllPriv, TOKEN_PRIVILEGES? newState, uint bufferLength ,out TOKEN_PRIVILEGES? previousState,out uint returnLength )
        {
            TOKEN_PRIVILEGES tp = default;
            uint len= 0;
            unsafe
            {
                var p1 = &tp;
                    var p2 = &len;
                    var resu = PInvoke.AdjustTokenPrivileges(tokenHandle, disableAllPriv, 
                        newState is { } ns ? &ns : (TOKEN_PRIVILEGES*)IntPtr.Zero, 
                        bufferLength, p1, p2);
                    if (bufferLength == 0)
                    {
                        previousState = null;
                        returnLength = 0;
                    }
                    else
                    {
                        previousState = Marshal.PtrToStructure<TOKEN_PRIVILEGES>((IntPtr)p1);
                        returnLength = Marshal.PtrToStructure<uint>((IntPtr)p2);
                    }
                    return resu;
            }
        }

        //private static partial class NativeMethods
        //{
        //    [Obsolete("请使用net自带的注册表函数")]
        //    [DllImport("advapi32.dll", CharSet = CharSet.Auto)]
        //    private static extern int RegCloseKey(IntPtr hKey);
        //    [Obsolete("请使用net自带的注册表函数")]
        //    [DllImport("advapi32.dll", CharSet = CharSet.Auto)]
        //    private static extern int RegOpenKey(IntPtr hKey, string lpSubKey, out IntPtr phkResult);
        //    [Obsolete("请使用net自带的注册表函数")]
        //    [DllImport("advapi32.dll", CharSet = CharSet.Auto)]
        //    private static extern int RegEnumValue(IntPtr hKey, uint dwIndex, StringBuilder lpValueName, ref uint lpcbValueName, IntPtr lpReserved, [Out, Optional] IntPtr lpType, [Out, Optional] byte[] lpData, [Optional] ref uint lpcbData);
        //}
    }
}
