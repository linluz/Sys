namespace Sys.Com.WindowsControls
{
    /// <summary>
    /// SendMessage API 部分常数
    /// </summary>
    public enum SendMsgValue:uint
    {

        #region 用于组合列表框常数

        /// <summary>
        ///起点,终点		用于取得组合框所包含编辑框子控件中当前被选中的字符串的起止位置
        /// </summary>
        CB_GETEDITSEL = 0x140,

        /// <summary>
        ///0,0 or -1		用于选中组合框所包含编辑框子控件中的部分字符串,对应函数
        /// </summary>
        CB_SETEDITSEL = 0x142,

        #endregion

        #region 用于文本框查找定位常数

        /// <summary>
        ///0,变量			获取光标位置（以本机默认编码的字符数表示）
        /// </summary>
        EM_GETSEL = 0xB0,

        /// <summary>
        /// 起点,终点		设置编辑控件中文本选定内容范围（或设置光标位置）起点和终点均为字符值
        /// 当指定的起点等于0和终点等于-1时，文本全部被选中，此法常用在清空编辑控件
        /// 当指定的起点等于-2和终点等于-1时，全文均不选，光标移至文本未端
        /// </summary>
        EM_SETSEL = 0xB1,

        /// <summary>
        ///0,0			获取编辑控件的总行数
        /// </summary>
        EM_GETLINECOUNT = 0xBA,

        /// <summary>
        ///行号,0			获取指定行(或:-1,0 表示光标所在行)首字符在文本中的位置（以字符数表示）
        /// </summary>
        EM_LINEINDEX = 0xBB,

        /// <summary>
        ///偏移值,0		获取指定位置所在行(或:-1,0 表示光标所在行）的文本长度（以字符数表示）
        /// </summary>
        EM_LINELENGTH = 0xC1,

        /// <summary>
        ///偏移值,0		获取指定位置(或:-1,0 表示光标位置)所在的行号
        /// </summary>
        EM_LINEFROMCHAR = 0xC9,

        /// <summary>
        ///行号,ByVal变量	获取编辑控件某一行的内容，变量须预先赋空格
        /// </summary>
        EM_GETLINE = 0xC4,

        /// <summary>
        ///0,0 			把可见范围移至光标处
        /// </summary>
        EM_SCROLLCARET = 0xB7,

        /// <summary>
        ///0,0 			撤消前一次编辑操作，当重复发送本消息，控件将在撤消和恢复中来回切换
        /// </summary>
        EM_UNDO = 0xC7,

        /// <summary>
        ///1(0),字符串	用指定字符串替换编辑控件中的当前选定内容
        /// 如果第三个参数wParam为1，则本次操作允许撤消，0禁止撤消。字符串可用传值方式，也可用传址方式
        /// （例：SendMessage Text1.hwnd, EM_REPLACESEL, 0, Text2.Text ,//这是传值方式）
        /// </summary>
        EM_REPLACESEL = 0xC2,

        /// <summary>
        ///0,0			判断编辑控件的内容是否已发生变化，返回TRUE(1)则控件文本已被修改，返回FALSE(0)则未变
        /// </summary>
        EM_GETMODIFY = 0xB8,

        /// <summary>
        ///				编辑控件的内容发生改变。与EN_UPDATE不同，该消息是在编辑框显示的正文被刷新后才发出的
        /// </summary>
        EN_CHANGE = 0x300,

        /// <summary>
        ///				控件准备显示改变了的正文时发送该消息。它与EN_CHANGE通知消息相似，只是它发生于更新文本显示出来之前
        /// </summary>
        EN_UPDATE = 0x400,

        /// <summary>
        ///0,0			获取一个编辑控件中文本的最大长度
        /// </summary>
        EM_GETLIMITTEXT = 0xD5,

        /// <summary>
        ///最大值,0		设置编辑控件中的最大文本长度
        /// </summary>
        EM_LIMITTEXT = 0xC5,

        /// <summary>
        ///0,0			获得文本控件中处于可见位置的最顶部的文本所在的行号
        /// </summary>
        EM_GETFIRSTVISIBLEINE = 0xCE,

        /// <summary>
        ///0,0			取得文本缓冲区
        /// </summary>
        EM_GETHANDLE = 0xBD,

        /// <summary>
        ///颜色值,0		改变选定文本的颜色
        /// </summary>
        EM_SETCHARFORMAT = 0x444,

        #endregion

        #region 用于列表框常数

        /// <summary>
        ///0,文件名地址	增加文件名
        /// </summary>
        LB_ADDFILE = 0x196,

        /// <summary>
        ///0,字符串地址	追加一个列表项返回索引。如果指定了LBS_SORT风格，表项将被重排序，否则将被追加在列表框的最后一项
        /// </summary>
        LB_ADDSTRING = 0x180,

        /// <summary>
        ///列表项序号,0	删除指定的列表项返回列表框剩餘表項
        /// </summary>
        LB_DELETESTRING = 0x182,

        /// <summary>
        ///DDL_ARCHIVE,指向通配符地址	添加文件名列表，返回最後一個添加的文件名的索引
        /// </summary>
        LB_DIR = 0x18D,

        /// <summary>
        ///开始表项序号,字符串地址	查找匹配字符串，忽略大小写，从指定开始表项序号开始查找，当查到某表项的文本字符串的前面包括指定的字符串则结束，找不到则转到列表框第一项继续查找，直到查完所有表项，如果wParam为-1则从列表框第一项开始查找，如果找到则返回表项序号，否则返回LB_ERR。如：表项字符串为"abc123"和指定字串"ABC"就算匹配
        /// </summary>
        LB_FINDSTRING = 0x18F,

        /// <summary>
        ///开始表项序号,字符串地址	查找字符串，忽略大小写，与LB_FINDSTRING不同，本操作必须整个字符串相同。如果找到则返回表项序号，否则返回LB_ERR
        /// </summary>
        LB_FINDSTRINGEXACT = 0x1A2,

        /// <summary>
        ///0,0			返回鼠标最后选中的项的索引
        /// </summary>
        LB_GETANCHORINDEX = 0x19D,

        /// <summary>
        ///0,0			返回具有矩形焦点的项的索引
        /// </summary>
        LB_GETCARETINDEX = 0x19F,

        /// <summary>
        ///0,0			返回列表项的总项数，若出错则返回LB_ERR
        /// </summary>
        LB_GETCOUNT = 0x18B,

        /// <summary>
        ///0,0			本操作仅适用于单选择列表框，用来返回当前被选择项的索引，如果没有列表项被选择或有错误发生，则返回LB_ERR
        /// </summary>
        LB_GETCURSEL = 0x188,

        /// <summary>
        ///0,0		返回列表框的可滚动的宽度（象素）
        /// </summary>
        LB_GETHORIZONTALEXTENT = 0x193,

        /// <summary>
        ///索引,0			每个列表项都有一个32位的附加数据．该函数返回指定列表项的附加数据。若出错则函数返回LB_ERR
        /// </summary>
        LB_GETITEMDATA = 0x199,

        /// <summary>
        ///索引,0			返回列表框中某一项的高度（象素）
        /// </summary>
        LB_GETITEMHEIGHT = 0x1A1,

        /// <summary>
        ///索引,RECT结构地址	获得列表项的客户区的RECT
        /// </summary>
        LB_GETITEMRECT = 0x198,

        /// <summary>
        ///0,0			取列表项当前用于排序的语言代码，当用户使用LB_ADDSTRING向组合框中的列表框中添加记录并使用LBS_SORT风格进行重新排序时，必须使用该语言代码。返回值中高16位为国家代码
        /// </summary>
        LB_GETLOCALE = 0x1A6,

        /// <summary>
        ///索引,0			返回指定列表项的状态。如果查询的列表项被选择了，函数返回一个正值，否则返回0，若出错则返回LB_ERR
        /// </summary>
        LB_GETSEL = 0x187,

        /// <summary>
        ///0,0			本操作仅用于多重选择列表框，它返回选择项的数目，若出错函数返回LB_ERR
        /// </summary>
        LB_GETSELCOUNT = 0x190,

        /// <summary>
        ///数组的大小,缓冲区	本操作仅用于多重选择列表框，用来获得选中的项的数目及位置。参数lParam指向一个整型数数组缓冲区，用来存放选中的列表项的索引。wParam说明了数组缓冲区的大小。本操作返回放在缓冲区中的选择项的实际数目，若出错函数返回LB_ERR
        /// </summary>
        LB_GETSELITEMS = 0x191,

        /// <summary>
        ///索引,缓冲区 	用于获取指定列表项的字符串。参数lParam指向一个接收字符串的缓冲区．wParam则指定了接收字符串的列表项索引。返回获得的字符串的长度，若出错，则返回LB_ERR
        /// </summary>
        LB_GETTEXT = 0x189,

        /// <summary>
        ///索引,0 		返回指定列表项的字符串的字节长度。wParam指定了列表项的索引．若出错则返回LB_ERR返回和給定項相關聯的字符串長度（單位：字符）
        /// </summary>
        LB_GETTEXTLEN = 0x18A,

        /// <summary>
        ///0,0			返回列表框中第一个可见项的索引，若出错则返回LB_ERR
        /// </summary>
        LB_GETTOPINDEX = 0x18E,

        /// <summary>
        ///表项数,内存字节数	本操作只适用于Windows95版本，当你将要向列表框中加入很多表项或有很大的表项时，本操作将预先分配一块内存，以免在今后的操作中一次一次地分配内存，从而加快程序运行速度
        /// </summary>
        LB_INITSTORAGE = 0x1A8,

        /// <summary>
        ///索引,字符串地址	在列表框中的指定位置插入字符串。wParam指定了列表项的索引，如果为-1，则字符串将被添加到列表的末尾。lParam指向要插入的字符串。本操作返回实际的插入位置，若发生错误，会返回LB_ERR或LB_ERRSPACE。与LB_ADDSTRING不同，本操作不会导致LBS_SORT风格的列表框重新排序。建议不要在具有LBS_SORT风格的列表框中使用本操作，以免破坏列表项的次序
        /// </summary>
        LB_INSERTSTRING = 0x181,

        /// <summary>
        ///0,位置			获得与指定点最近的项的索引，lParam指定在列表框客户区，低16位为X坐标，高16位为Y坐标
        /// </summary>
        LB_ITEMFROMPOINT = 0x1A9,

        /// <summary>
        ///0,0			清除所有列表项
        /// </summary>
        LB_RESETCONTENT = 0x184,

        /// <summary>
        ///开始表项序号,字符串地址	本操作仅适用于单选择列表框，设定与指定字符串相匹配的列表项为选中项。本操作会滚动列表框以使选择项可见。参数的意义及搜索的方法与LB_FINDSTRING类似。如果找到了匹配的项，返回该项的索引，如果没有匹配的项，返回LB_ERR并且当前的选中项不被改变
        /// </summary>
        LB_SELECTSTRING = 0x18C,

        /// <summary>
        ///TRUE或FALSE,范围	本操作仅用于多重选择列表框，用来使指定范围内的列表项选中或落选．参数lParam指定了列表项索引的范围，低16位为开始项高16位为结束项。如果参数wParam为TRUE，那么就选择这些列表项，否则就使它们落选。若出错函数返回LB_ERR
        /// </summary>
        LB_SELITEMRANGE = 0x19B,

        /// <summary>
        ///起点,终点		仅用于多重选择列表框，若指定终点大于起点则设定该范围为选中，若指定起点大于终点则设定该范围为落选
        /// </summary>
        LB_SELITEMRANGEEX = 0x183,

        /// <summary>
        ///索引,0			设置鼠标最后选中的表项成指定表项
        /// </summary>
        LB_SETANCHORINDEX = 0x19C,

        /// <summary>
        ///索引,TRUE或FALSE	设置键盘输入焦点到指定表项，若lParam为TRUE则滚动到指定项部份可见，若lParam为FALSE则滚动到指定项全部可见
        /// </summary>
        LB_SETCARETINDEX = 0x19E,

        /// <summary>
        ///宽度(点),0		设置列的宽度（單位：象素）
        /// </summary>
        LB_SETCOLUMNWIDTH = 0x195,

        /// <summary>
        ///项数,0			设置表项数目
        /// </summary>
        LB_SETCOUNT = 0x1A7,

        /// <summary>
        ///索引,0			仅适用于单选择列表框，设置指定的列表项为当前选择项，并自动滚动到可见区域。参数wParam指定了列表项的索引，若为-1，那么将清除列表框中的选择。若出错函数返回LB_ERR
        /// </summary>
        LB_SETCURSEL = 0x186,

        /// <summary>
        ///宽度(点),0 设置列表框的滚动宽度（單位：象素）
        /// </summary>
        LB_SETHORIZONTALEXTENT = 0x194,

        /// <summary>
        ///索引,数据值	更新指定列表项的32位附加数据。
        /// </summary>
        LB_SETITEMDATA = 0x19A,

        /// <summary>
        ///索引,高度(点)	指定列表项显示高度，带有LBS_OWNERDRAWVARIABLE(自绘列表项)风格的控件，只设置由wParam指定项的高度，其它风格将更新所有的列表项的高度（單位：象素）
        /// </summary>
        LB_SETITEMHIEGHT = 0x1A0,

        /// <summary>
        ///语言代码,0		取列表项当前用于排序的语言代码，当用户使用LB_ADDSTRING向组合框中的列表框中添加记录并使用LBS_SORT风格进行重新排序时，必须使用该语言代码。返回值中高16位为国家代码
        /// </summary>
        LB_SETLOCALE = 0x1A5,

        /// <summary>
        ///TRUE或FALSE,索引	仅适用于多重选择列表框，它使指定的列表项选中或落选，并自动滚动到可见区域。参数lParam指定了列表项的索引，若为-1，则相当于指定了所有的项。参数wParam为TRUE时选中列表项，否则使之落选。若出错则返回LB_ERR
        /// </summary>
        LB_SETSEL = 0x185,

        /// <summary>
        ///站数,索引顺序表	设置列表框的光标(输入焦点)站数及索引顺序表
        /// </summary>
        LB_SETTABSTOPS = 0x192,

        /// <summary>
        ///索引,0			用来将指定的列表项设置为列表框的第一个可见项，该函数会将列表框滚动到合适的位置。wParam指定了列表项的索引．若操作成功，返回0值，否则返回LB_ERR
        /// </summary>
        LB_SETTOPINDEX = 0x197,
        LB_MULTIPLEADDSTRING = 0x1B1,
        LB_GETLISTBOXINFO = 0x1B2,
        LB_MSGMAX_501 = 0x1B3,
        LB_MSGMAX_WCE4 = 0x1B1,
        LB_MSGMAX_4 = 0x1B0,
        LB_MSGMAX_PRE4 = 0x1A8,

        #endregion

        #region 用于文本控件常数

        /// <summary>
        ///字节数,字符串地址	获取窗口文本控件的文本
        /// </summary>
        WM_GETTEXT = 0x0D,

        /// <summary>
        ///0,0				获取窗口文本控件的文本的长度（不包含空字符）(字符数)
        /// </summary>
        WM_GETTEXTLENGTH = 0x0E,

        /// <summary>
        ///0,字符串地址		设置窗口文本控件的文本
        /// </summary>
        WM_SETTEXT = 0x0C,

        #endregion

        #region 用于对话框字体

        /// <summary>
        ///字体句柄,True		绘制文本时程序发送此消息获取控件要用的字体
        /// </summary>
        WM_SETFONT = 0x30,

        /// <summary>
        ///0,0 				获取当前控件绘制文本的字体句柄
        /// </summary>
        WM_GETFONT = 0x31,

        /// <summary>
        ///0,0				当系统的字体资源库变化时发送此消息给所有顶级窗口
        /// </summary>
        WM_FONTCHANGE = 0x1D,

        /// <summary>
        ///Boolean,0		设置窗口是否能重画，False 禁止重画，True 允许重画
        /// </summary>
        WM_SETREDRAW = 0xB,

        /// <summary>
        ///设备句柄,控件句柄	设置消息框颜色
        /// </summary>
        WM_CTLCOLORMSGBOX = 0x132,

        /// <summary>
        ///设备句柄,控件句柄	设置编辑框颜色
        /// </summary>
        WM_CTLCOLOREDIT = 0x133,

        /// <summary>
        ///设备句柄,控件句柄	设置列表框颜色
        /// </summary>
        WM_CTLCOLORLISTBOX = 0x134,

        /// <summary>
        ///设备句柄,控件句柄	设置按钮颜色
        /// </summary>
        WM_CTLCOLORBTN = 0x135,

        /// <summary>
        ///设备句柄,控件句柄	设置对话框颜色
        /// </summary>
        WM_CTLCOLORDLG = 0x136,

        /// <summary>
        ///设备句柄,控件句柄	设置滚动条颜色
        /// </summary>
        WM_CTLCOLORSCROLLBAR = 0x137,

        /// <summary>
        ///设备句柄,控件句柄	设置状态栏颜色
        /// </summary>
        WM_CTLCOLORSTATIC = 0x138,

        /// <summary>
        ///控件句柄,0,0		设置焦点
        /// </summary>
        WM_SETFOCUS = 0x7,


        /// <summary>
        ///控件句柄,虚拟键,0	模拟按下按钮
        /// </summary>
        WM_KEYDOWN = 0x100,

        /// <summary>
        ///控件句柄,虚拟键,0	模拟抬起按钮
        /// </summary>
        WM_KEYUP = 0x101,

        /// <summary>
        ///移动鼠标
        /// </summary>
        WM_LBUTTONDOWN = 0x201,

        /// <summary>
        ///按下鼠标左键
        /// </summary>
        WM_LBUTTONUP = 0x202,

        /// <summary>
        ///释放鼠标左键
        /// </summary>
        WM_LBUTTONDBLCLK = 0x203,

        /// <summary>
        ///双击鼠标左键
        /// </summary>
        WM_RBUTTONDOWN = 0x204,

        /// <summary>
        ///按下鼠标右键
        /// </summary>
        WM_RBUTTONUP = 0x205,

        /// <summary>
        ///释放鼠标右键
        /// </summary>
        WM_RBUTTONDBLCLK = 0x206,

        /// <summary>
        ///双击鼠标右键
        /// </summary>
        WM_MBUTTONDOWN = 0x207,

        /// <summary>
        ///按下鼠标中键
        /// </summary>
        WM_MBUTTONUP = 0x208,

        /// <summary>
        ///释放鼠标中键
        /// </summary>
        WM_MBUTTONDBLCLK = 0x209,

        /// <summary>
        ///双击鼠标中键
        /// </summary>
        WM_MOUSEWHEEL = 0x20A,


        /// <summary>
        ///控件句柄,滚动条类型,滚动条位置	设置 SB_BOTTOM 指定的水平滚动条位置
        /// </summary>
        WM_HSCROLL = 0x114,

        /// <summary>
        ///控件句柄,滚动条类型,滚动条位置	设置 SB_BOTTOM 指定的垂直滚动条位置
        /// </summary>
        WM_VSCROLL = 0x115,

        #region 滚动条

        /// <summary>
        /// 检索滚动条控件中滚动框的位置。 hWnd 参数必须是滚动条控件的句柄。
        /// </summary>
        SB_CTL = 0,

        /// <summary>
        /// 检索滚动框在窗口的标准水平滚动条中的位置。
        /// </summary>
        SB_HORZ = 0,

        /// <summary>
        /// 检索滚动框在窗口的标准垂直滚动条中的位置。
        /// </summary>
        SB_VERT = 1,

        /// <summary>
        ///滚动条位置, 设置垂直滚动条到顶部
        /// </summary>
        SB_TOP = 0x6,

        /// <summary>
        ///滚动条位置, 设置水平滚动条到右边
        /// </summary>
        SB_LEFT = 0x6,

        /// <summary>
        ///滚动条位置, 设置垂直滚动条到底部
        /// </summary>
        SB_BOTTOM = 0x7,

        /// <summary>
        ///滚动条位置, 设置水平滚动条到右边
        /// </summary>
        SB_RIGHT = 0x7,

        #endregion


        #endregion

        #region 按钮事件

        /// <summary>
        ///控件句柄,0,0		获取单选按钮或复选框的选定状态
        /// </summary>
        BM_GETCHECK = 0xF0,

        /// <summary>
        ///控件句柄,0,0		设置单选按钮或复选框的选定状态
        /// </summary>
        BM_SETCHECK = 0xF1,

        /// <summary>
        ///控件句柄,0,0		获取按钮是否被按下过
        /// </summary>
        BM_GETSTATE = 0xF2,

        /// <summary>
        ///控件句柄,按钮状态,0	设置按钮的状态，True 未按下状态，False 按下状态
        /// </summary>
        BM_SETSTATE = 0xF3,

        /// <summary>
        ///控件句柄,按钮样式,0	设置按钮的样式
        /// </summary>
        BM_SETSTYLE = 0xF4,

        /// <summary>
        ///控件句柄,0,0		模拟点击按钮
        /// </summary>
        BM_CLICK = 0xF5,
        BM_GETIMAGE = 0xF6,
        BM_SETIMAGE = 0xF7,

        /// <summary>
        ///控件句柄,0,0		用户单击了按钮
        /// </summary>
        BN_CLICKED = 0x0,

        /// <summary>
        ///设置单选框和复选框复选框为未选中状态
        /// </summary>
        BST_UNCHECKED = 0x0,

        /// <summary>
        ///设置单选框和复选框复选框为已选中状态
        /// </summary>
        BST_CHECKED = 0x1,
        BST_INDETERMINATE = 0x2,

        /// <summary>
        ///设置按钮为按下状态
        /// </summary>
        BST_PUSHED = 0x4,

        /// <summary>
        ///设置焦点
        /// </summary>
        BST_FOCUS = 0x8,

        #endregion

    }
}
