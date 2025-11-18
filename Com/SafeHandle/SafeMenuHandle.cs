using System.Runtime.Versioning;
using System.Security;
using Sys.Com.WindowsControls;

namespace Sys.Com.SafeHandle
{
    [SecurityCritical]
    [SupportedOSPlatform("windows6.0.6000")]
    internal sealed class SafeMenuHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        public SafeMenuHandle() : base(true)
        { }

        private SafeMenuHandle(IntPtr preexistingHandle, bool ownsHandle)
            : base(ownsHandle)
        {
            SetHandle(preexistingHandle);
        }

        public static explicit operator HMENU(SafeMenuHandle s)
            => (HMENU)s.handle;

        public static implicit operator SafeMenuHandle(HMENU s)
            => new(s,true);

        [SecurityCritical]
        protected override bool ReleaseHandle()
            => MenuMethod.DestroyMenu(this);

    }
}
