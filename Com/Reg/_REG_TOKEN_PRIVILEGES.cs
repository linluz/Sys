using System.Runtime.InteropServices;

namespace Sys.Com.Reg
{
    [StructLayout(LayoutKind.Sequential)]
    public struct REG_TOKEN_PRIVILEGES
    {
        public long PrivilegeCount;
        public REG_LUID_AND_ATTRIBUTES Privileges;
    }
}
