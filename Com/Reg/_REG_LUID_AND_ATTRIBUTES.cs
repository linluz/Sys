using System.Runtime.InteropServices;

namespace Sys.Com.Reg
{
    [StructLayout(LayoutKind.Sequential)]
    public struct REG_LUID_AND_ATTRIBUTES
    {
        public REG_LUID pLuid;
        public long Attributes;
    }
}
