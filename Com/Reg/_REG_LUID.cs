using System.Runtime.InteropServices;

namespace Sys.Com.Reg
{
    [StructLayout(LayoutKind.Sequential)]
    public struct REG_LUID
    {
        public int lowpart;
        public int highpart;
    }
}
