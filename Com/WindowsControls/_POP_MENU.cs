namespace Sys.Com.WindowsControls
{
    /// <summary>
    /// 自定义弹出菜单
    /// </summary>
    /// 被TRACK_POPUP_MENU_FLAGS和MENU_ITEM_FLAGS取代
    public enum POP_MENU
    {
        MF_ENABLED = 0x0,
        MF_BYCOMMAND = 0x0,
        MF_STRING = 0x0,
        MF_GRAYED = 0x1,
        MF_DISABLED = 0x2,
        MF_CHECKED = 0x8,
        MF_POPUP = 0x10,
        MF_BYPOSITION = 0x400,
        MF_SEPARATOR = 0x800,

        TPM_LEFTALIGN = 0x0,
        TPM_RIGHTBUTTON = 0x2,
        TPM_NONOTIFY = 0x80,
        TPM_RETURNCMD = 0x100
    }
}
