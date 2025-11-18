namespace Sys.Com.Struct
{
    /// <summary>
    /// 浏览文件夹参数
    /// </summary>
    [Flags]
    public enum BrowseFolder:uint
    {
        BIF_RETURNONLYFSDIRS = 0x1,          // 仅返回文件系统的目录
        BIF_DONTGOBELOWDOMAIN = 0x2,         // 在树形视窗中，不包含域名底下的网络目录结构
        BIF_STATUSTEXT = 0x4,                // 包含一个状态区域。通过给对话框发送消息使回调函数设置状态文本
        BIF_RETURNFSANCESTORS = 0x8,          // 返回文件系统的一个节点
        BIF_EDITBOX = 0x10,                  // 包含一个编辑框，用户可以输入选中项的名字
        BIF_VALIDATE = 0x20,                  // 没有BIF_EDITBOX标志位时，该标志位被忽略。如果用户输入的名字非法，将发送BFFM_VALIDATEFAILED消息给回调函数
        BIF_NEWDIALOGSTYLE = 0x40,
        BIF_USENEWUI = BIF_EDITBOX | BIF_NEWDIALOGSTYLE,    // 对话框上有新建文件夹按钮 0x50
        BIF_BROWSEINCLUDEURLS = 0x80,
        BIF_UAHINT = 0x100,
        BIF_NONEWFOLDERBUTTON = 0x200,
        BIF_NOTRANSLATETARGETS = 0x400,
        BIF_BROWSEFORCOMPUTER = 0x1000,       // 返回计算机名
        BIF_BROWSEFORPRINTER = 0x2000,        // 返回打印机名
        BIF_BROWSEINCLUDEFILES = 0x4000,      // 浏览器将显示目录，同时也显示文件
        BIF_SHAREABLE = 0x8000,
        BIF_BROWSEFILEJUNCTIONS = 0x10000
    }
}
