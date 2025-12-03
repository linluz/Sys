namespace Sys.Com.WindowsControls
{
    /// <summary>
    /// SendMessage API 部分常数。
    /// </summary>
    public enum SendMsgValue:uint
    {

        #region 用于组合列表框常数

        /// <summary>
        /// 偏移值,0：获取组合框所包含编辑框子控件中选定字符串的起点和终点位置。
        /// </summary>
        CB_GETEDITSEL = 0x140,

        /// <summary>
        /// 设置起点,终点：设置组合框所包含编辑框子控件中选定字符串的起点和终点位置。
        /// </summary>
        CB_SETEDITSEL = 0x142,

        #endregion

        #region 用于文本框查找定位常数

        /// <summary>
        /// 获取起点,终点：获取编辑控件中文本选定内容范围（或光标位置）起点和终点均为字符值。
        /// </summary>
        EM_GETSEL = 0xB0,

        /// <summary>
        /// 起点,终点：设置编辑控件中文本选定内容范围（或设置光标位置）起点和终点均为字符值。
        /// 当指定的起点等于 0 和终点等于 -1 时，文本全部被选中；当指定的起点等于 -2 和终点等于 -1 时，全文均不选，光标移至文本未端。
        /// </summary>
        EM_SETSEL = 0xB1,

        /// <summary>
        /// 0,0：获取编辑控件的总行数。
        /// </summary>
        EM_GETLINECOUNT = 0xBA,

        /// <summary>
        /// 行号,0：获取指定行（或 -1,0 表示光标所在行）首字符在文本中的位置（以字符数表示）。
        /// </summary>
        EM_LINEINDEX = 0xBB,

        /// <summary>
        /// 偏移值,0：获取指定位置所在行（或 -1,0 表示光标所在行）的文本长度（以字符数表示）。
        /// </summary>
        EM_LINELENGTH = 0xC1,

        /// <summary>
        /// 偏移值,0：获取指定位置（或 -1,0 表示光标位置）所在的行号。
        /// </summary>
        EM_LINEFROMCHAR = 0xC9,

        /// <summary>
        /// 行号,ByVal 变量：获取编辑控件某一行的内容，变量须预先赋空格。
        /// </summary>
        EM_GETLINE = 0xC4,

        /// <summary>
        /// 0,0：把可见范围移至光标处。
        /// </summary>
        EM_SCROLLCARET = 0xB7,

        /// <summary>
        /// 0,0：撤消前一次编辑操作；当重复发送本消息，控件将在撤消和恢复中来回切换。
        /// </summary>
        EM_UNDO = 0xC7,

        /// <summary>
        /// 1(0),字符串：用指定字符串替换编辑控件中的当前选定内容。若 wParam 为 1，允许撤消；为 0 禁止撤消。
        /// 字符串可用传值或传址方式。
        /// </summary>
        EM_REPLACESEL = 0xC2,

        /// <summary>
        /// 0,0：判断编辑控件的内容是否已发生变化，返回 TRUE(1) 则控件文本已被修改，返回 FALSE(0) 则未变。
        /// </summary>
        EM_GETMODIFY = 0xB8,

        /// <summary>
        /// 编辑控件的内容发生改变。与 EN_UPDATE 不同，该消息是在编辑框显示的正文被刷新后才发出的。
        /// </summary>
        EN_CHANGE = 0x300,

        /// <summary>
        /// 控件准备显示改变了的正文时发送该消息，在更新文本显示之前发生，与 EN_CHANGE 相似。
        /// </summary>
        EN_UPDATE = 0x400,

        /// <summary>
        /// 0,0：获取一个编辑控件中文本的最大长度。
        /// </summary>
        EM_GETLIMITTEXT = 0xD5,

        /// <summary>
        /// 最大值,0：设置编辑控件中的最大文本长度。
        /// </summary>
        EM_LIMITTEXT = 0xC5,

        /// <summary>
        /// 0,0：获得文本控件中处于可见位置的最顶部的文本所在的行号。
        /// </summary>
        EM_GETFIRSTVISIBLEINE = 0xCE,

        /// <summary>
        /// 0,0：取得文本缓冲区句柄。
        /// </summary>
        EM_GETHANDLE = 0xBD,

        /// <summary>
        /// 颜色值,0：改变选定文本的颜色。
        /// </summary>
        EM_SETCHARFORMAT = 0x444,

        #endregion

        #region 用于列表框常数

        /// <summary>
        /// 0,文件名地址：增加文件名。
        /// </summary>
        LB_ADDFILE = 0x196,

        /// <summary>
        /// 0,字符串地址：追加一个列表项返回索引。若使用 LBS_SORT 风格，表项将重排序，否则追加在末尾。
        /// </summary>
        LB_ADDSTRING = 0x180,

        /// <summary>
        /// 列表项序号,0：删除指定的列表项，返回列表框剩余表项数。
        /// </summary>
        LB_DELETESTRING = 0x182,

        /// <summary>
        /// DDL_ARCHIVE,指向通配符地址：添加文件名列表，返回最后一个添加的文件名的索引。
        /// </summary>
        LB_DIR = 0x18D,

        /// <summary>
        /// 开始表项序号,字符串地址：查找前缀匹配字符串（忽略大小写），返回匹配的索引或 LB_ERR。
        /// </summary>
        LB_FINDSTRING = 0x18F,

        /// <summary>
        /// 开始表项序号,字符串地址：查找完全匹配字符串（忽略大小写），返回索引或 LB_ERR。
        /// </summary>
        LB_FINDSTRINGEXACT = 0x1A2,

        /// <summary>
        /// 0,0：返回鼠标最后选中的项的索引。
        /// </summary>
        LB_GETANCHORINDEX = 0x19D,

        /// <summary>
        /// 0,0：返回具有矩形焦点的项的索引。
        /// </summary>
        LB_GETCARETINDEX = 0x19F,

        /// <summary>
        /// 0,0：返回列表项的总项数，若出错则返回 LB_ERR。
        /// </summary>
        LB_GETCOUNT = 0x18B,

        /// <summary>
        /// 0,0：仅适用于单选列表框，返回当前被选择项的索引；无选择或错误返回 LB_ERR。
        /// </summary>
        LB_GETCURSEL = 0x188,

        /// <summary>
        /// 0,0：返回列表框的可滚动的宽度（像素）。
        /// </summary>
        LB_GETHORIZONTALEXTENT = 0x193,

        /// <summary>
        /// 索引,0：返回指定列表项的附加数据；出错返回 LB_ERR。
        /// </summary>
        LB_GETITEMDATA = 0x199,

        /// <summary>
        /// 索引,0：返回列表框中某一项的高度（像素）。
        /// </summary>
        LB_GETITEMHEIGHT = 0x1A1,

        /// <summary>
        /// 索引,RECT 结构地址：获得列表项的客户区 RECT。
        /// </summary>
        LB_GETITEMRECT = 0x198,

        /// <summary>
        /// 0,0：取列表项当前用于排序的语言代码。返回值高 16 位为国家代码。
        /// </summary>
        LB_GETLOCALE = 0x1A6,

        /// <summary>
        /// 索引,0：返回指定列表项的选中状态。选中返回正值，否则返回 0；出错返回 LB_ERR。
        /// </summary>
        LB_GETSEL = 0x187,

        /// <summary>
        /// 0,0：仅用于多选列表框，返回选择项的数目；出错返回 LB_ERR。
        /// </summary>
        LB_GETSELCOUNT = 0x190,

        /// <summary>
        /// 数组大小,缓冲区：仅用于多选列表框，获得选中项的索引集合并返回实际数量；出错返回 LB_ERR。
        /// </summary>
        LB_GETSELITEMS = 0x191,

        /// <summary>
        /// 索引,缓冲区：获取指定项的字符串，返回长度；出错返回 LB_ERR。
        /// </summary>
        LB_GETTEXT = 0x189,

        /// <summary>
        /// 索引,0：返回指定项的字符串长度（字符数）；出错返回 LB_ERR。
        /// </summary>
        LB_GETTEXTLEN = 0x18A,

        /// <summary>
        /// 0,0：返回第一个可见项的索引；出错返回 LB_ERR。
        /// </summary>
        LB_GETTOPINDEX = 0x18E,

        /// <summary>
        /// 表项数,内存字节数：Windows 95 预分配列表框存储以优化大量项操作。
        /// </summary>
        LB_INITSTORAGE = 0x1A8,

        /// <summary>
        /// 索引,字符串地址：在指定位置插入字符串；返回实际插入位置或 LB_ERR/LB_ERRSPACE。
        /// </summary>
        LB_INSERTSTRING = 0x181,

        /// <summary>
        /// 0,位置：获得与指定点最近的项索引；lParam 为客户区坐标（低 16 位 X，高 16 位 Y）。
        /// </summary>
        LB_ITEMFROMPOINT = 0x1A9,

        /// <summary>
        /// 0,0：清除所有列表项。
        /// </summary>
        LB_RESETCONTENT = 0x184,

        /// <summary>
        /// 开始表项序号,字符串地址：设定与指定字符串相匹配的项为选中并滚动到可见；找不到返回 LB_ERR。
        /// </summary>
        LB_SELECTSTRING = 0x18C,

        /// <summary>
        /// TRUE 或 FALSE,范围：仅用于多选列表框，使指定范围项选中或落选；出错返回 LB_ERR。
        /// </summary>
        LB_SELITEMRANGE = 0x19B,

        /// <summary>
        /// 起点,终点：仅用于多选列表框，设定范围为选中或落选。
        /// </summary>
        LB_SELITEMRANGEEX = 0x183,

        /// <summary>
        /// 索引,0：设置鼠标最后选中的表项为指定表项。
        /// </summary>
        LB_SETANCHORINDEX = 0x19C,

        /// <summary>
        /// 索引,TRUE 或 FALSE：设置键盘输入焦点到指定项并控制滚动可见性。
        /// </summary>
        LB_SETCARETINDEX = 0x19E,

        /// <summary>
        /// 宽度(像素),0：设置列的宽度。
        /// </summary>
        LB_SETCOLUMNWIDTH = 0x195,

        /// <summary>
        /// 项数,0：设置表项数目。
        /// </summary>
        LB_SETCOUNT = 0x1A7,

        /// <summary>
        /// 索引,0：仅用于单选列表框，设置指定项为当前选择项；-1 清除选择。
        /// </summary>
        LB_SETCURSEL = 0x186,

        /// <summary>
        /// 宽度(像素),0：设置列表框的滚动宽度。
        /// </summary>
        LB_SETHORIZONTALEXTENT = 0x194,

        /// <summary>
        /// 索引,数据值：更新指定列表项的 32 位附加数据。
        /// </summary>
        LB_SETITEMDATA = 0x19A,

        /// <summary>
        /// 索引,高度(像素)：指定列表项显示高度。自绘变量高控件仅设置指定项，其它风格更新所有项高度。
        /// </summary>
        LB_SETITEMHIEGHT = 0x1A0,

        /// <summary>
        /// 语言代码,0：设置用于排序的语言代码。返回高 16 位为国家代码。
        /// </summary>
        LB_SETLOCALE = 0x1A5,

        /// <summary>
        /// TRUE 或 FALSE,索引：仅用于多选列表框，使指定项选中或落选并滚动到可见；-1 表示所有项；出错返回 LB_ERR。
        /// </summary>
        LB_SETSEL = 0x185,

        /// <summary>
        /// 站数,索引顺序表：设置列表框的制表位及索引顺序表。
        /// </summary>
        LB_SETTABSTOPS = 0x192,

        /// <summary>
        /// 索引,0：设置列表框的第一个可见项为指定索引；成功返回 0，否则返回 LB_ERR。
        /// </summary>
        LB_SETTOPINDEX = 0x197,

        /// <summary>
        /// 批量追加字符串到列表框。
        /// </summary>
        LB_MULTIPLEADDSTRING = 0x1B1,

        /// <summary>
        /// 获取列表框信息（如项目数、选择状态等）。
        /// </summary>
        LB_GETLISTBOXINFO = 0x1B2,

        /// <summary>
        /// 列表框消息最大值（Windows 5.01）。
        /// </summary>
        LB_MSGMAX_501 = 0x1B3,

        /// <summary>
        /// 列表框消息最大值（Windows CE 4）。
        /// </summary>
        LB_MSGMAX_WCE4 = 0x1B1,

        /// <summary>
        /// 列表框消息最大值（Windows 4）。
        /// </summary>
        LB_MSGMAX_4 = 0x1B0,

        /// <summary>
        /// 列表框消息最大值（Windows 4 之前）。
        /// </summary>
        LB_MSGMAX_PRE4 = 0x1A8,

        #endregion

        #region 用于文本控件常数

        /// <summary>
        /// 字节数,字符串地址：获取窗口文本控件的文本。
        /// </summary>
        WM_GETTEXT = 0x0D,

        /// <summary>
        /// 0,0：获取窗口文本控件的文本的长度（不包含空字符）。
        /// </summary>
        WM_GETTEXTLENGTH = 0x0E,

        /// <summary>
        /// 0,字符串地址：设置窗口文本控件的文本。
        /// </summary>
        WM_SETTEXT = 0x0C,

        #endregion

        #region 用于对话框字体

        /// <summary>
        /// 字体句柄,True：绘制文本时程序发送此消息获取控件要用的字体。
        /// </summary>
        WM_SETFONT = 0x30,

        /// <summary>
        /// 0,0：获取当前控件绘制文本的字体句柄。
        /// </summary>
        WM_GETFONT = 0x31,

        /// <summary>
        /// 0,0：当系统的字体资源库变化时发送此消息给所有顶级窗口。
        /// </summary>
        WM_FONTCHANGE = 0x1D,

        /// <summary>
        /// Boolean,0：设置窗口是否能重画，False 禁止重画，True 允许重画。
        /// </summary>
        WM_SETREDRAW = 0xB,

        /// <summary>
        /// 设备句柄,控件句柄：设置消息框颜色。
        /// </summary>
        WM_CTLCOLORMSGBOX = 0x132,

        /// <summary>
        /// 设备句柄,控件句柄：设置编辑框颜色。
        /// </summary>
        WM_CTLCOLOREDIT = 0x133,

        /// <summary>
        /// 设备句柄,控件句柄：设置列表框颜色。
        /// </summary>
        WM_CTLCOLORLISTBOX = 0x134,

        /// <summary>
        /// 设备句柄,控件句柄：设置按钮颜色。
        /// </summary>
        WM_CTLCOLORBTN = 0x135,

        /// <summary>
        /// 设备句柄,控件句柄：设置对话框颜色。
        /// </summary>
        WM_CTLCOLORDLG = 0x136,

        /// <summary>
        /// 设备句柄,控件句柄：设置滚动条颜色。
        /// </summary>
        WM_CTLCOLORSCROLLBAR = 0x137,

        /// <summary>
        /// 设备句柄,控件句柄：设置状态栏颜色。
        /// </summary>
        WM_CTLCOLORSTATIC = 0x138,

        /// <summary>
        /// 控件句柄,0,0：设置焦点。
        /// </summary>
        WM_SETFOCUS = 0x7,


        /// <summary>
        /// 控件句柄,虚拟键,0：模拟按下键盘按键。
        /// </summary>
        WM_KEYDOWN = 0x100,

        /// <summary>
        /// 控件句柄,虚拟键,0：模拟抬起键盘按键。
        /// </summary>
        WM_KEYUP = 0x101,

        /// <summary>
        /// 鼠标左键按下。
        /// </summary>
        WM_LBUTTONDOWN = 0x201,

        /// <summary>
        /// 鼠标左键释放。
        /// </summary>
        WM_LBUTTONUP = 0x202,

        /// <summary>
        /// 鼠标左键双击。
        /// </summary>
        WM_LBUTTONDBLCLK = 0x203,

        /// <summary>
        /// 鼠标右键按下。
        /// </summary>
        WM_RBUTTONDOWN = 0x204,

        /// <summary>
        /// 鼠标右键释放。
        /// </summary>
        WM_RBUTTONUP = 0x205,

        /// <summary>
        /// 鼠标右键双击。
        /// </summary>
        WM_RBUTTONDBLCLK = 0x206,

        /// <summary>
        /// 鼠标中键按下。
        /// </summary>
        WM_MBUTTONDOWN = 0x207,

        /// <summary>
        /// 鼠标中键释放。
        /// </summary>
        WM_MBUTTONUP = 0x208,

        /// <summary>
        /// 鼠标中键双击。
        /// </summary>
        WM_MBUTTONDBLCLK = 0x209,

        /// <summary>
        /// 鼠标滚轮滚动。
        /// </summary>
        WM_MOUSEWHEEL = 0x20A,


        /// <summary>
        /// 控件句柄,滚动条类型,滚动条位置：水平滚动条滚动或位置变化通知。
        /// </summary>
        WM_HSCROLL = 0x114,

        /// <summary>
        /// 控件句柄,滚动条类型,滚动条位置：垂直滚动条滚动或位置变化通知。
        /// </summary>
        WM_VSCROLL = 0x115,

        #region 滚动条

        /// <summary>
        /// 指示滚动消息来自滚动条控件（用于区分标准滚动条）。
        /// </summary>
        SB_CTL = 0,

        /// <summary>
        /// 标准水平滚动条。
        /// </summary>
        SB_HORZ = 0,

        /// <summary>
        /// 标准垂直滚动条。
        /// </summary>
        SB_VERT = 1,

        /// <summary>
        /// 滚动条位置：设置垂直滚动条到顶部。
        /// </summary>
        SB_TOP = 0x6,

        /// <summary>
        /// 滚动条位置：设置水平滚动条到左边。
        /// </summary>
        SB_LEFT = 0x6,

        /// <summary>
        /// 滚动条位置：设置垂直滚动条到底部。
        /// </summary>
        SB_BOTTOM = 0x7,

        /// <summary>
        /// 滚动条位置：设置水平滚动条到右边。
        /// </summary>
        SB_RIGHT = 0x7,

        #endregion


        #endregion

        #region 按钮事件

        /// <summary>
        /// 控件句柄,0,0：获取单选按钮或复选框的选定状态。
        /// </summary>
        BM_GETCHECK = 0xF0,

        /// <summary>
        /// 控件句柄,0,0：设置单选按钮或复选框的选定状态。
        /// </summary>
        BM_SETCHECK = 0xF1,

        /// <summary>
        /// 控件句柄,0,0：获取按钮是否被按下过。
        /// </summary>
        BM_GETSTATE = 0xF2,

        /// <summary>
        /// 控件句柄,按钮状态,0：设置按钮的状态，True 未按下，False 按下。
        /// </summary>
        BM_SETSTATE = 0xF3,

        /// <summary>
        /// 控件句柄,按钮样式,0：设置按钮的样式。
        /// </summary>
        BM_SETSTYLE = 0xF4,

        /// <summary>
        /// 控件句柄,0,0：模拟点击按钮。
        /// </summary>
        BM_CLICK = 0xF5,

        /// <summary>
        /// 获取按钮的图像句柄（若按钮支持图像）。
        /// </summary>
        BM_GETIMAGE = 0xF6,

        /// <summary>
        /// 设置按钮的图像句柄（若按钮支持图像）。
        /// </summary>
        BM_SETIMAGE = 0xF7,

        /// <summary>
        /// 控件句柄,0,0：用户单击了按钮通知。
        /// </summary>
        BN_CLICKED = 0x0,

        /// <summary>
        /// 设置单选框和复选框为未选中状态。
        /// </summary>
        BST_UNCHECKED = 0x0,

        /// <summary>
        /// 设置单选框和复选框为已选中状态。
        /// </summary>
        BST_CHECKED = 0x1,

        /// <summary>
        /// 设置复选框为不确定（三态）状态。
        /// </summary>
        BST_INDETERMINATE = 0x2,

        /// <summary>
        /// 设置按钮为按下状态。
        /// </summary>
        BST_PUSHED = 0x4,

        /// <summary>
        /// 设置按钮获得焦点。
        /// </summary>
        BST_FOCUS = 0x8,

        #endregion

    }
}
