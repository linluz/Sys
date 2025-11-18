namespace Sys.Com.Key
{
    /// <summary>
    /// 键鼠虚拟键值定义，用于 GetAsyncKeyState 函数
    /// </summary>
    public enum VirtualKey
    {
        #region 鼠标

        VK_LBUTTON = 0x01,  //鼠标左键
        VK_RBUTTON = 0x02,    //鼠标右键
        VK_CANCEL = 0x03,   //控制中断处理
        VK_MBUTTON = 0x04,  //鼠标中键
        VK_XBUTTON1 = 0x05,//X1 鼠标按钮
        VK_XBUTTON2 = 0x06,//X2 鼠标按钮

        #endregion

        #region 控制

        VK_BACK = 0x08,//BACKSPACE 键
        VK_TAB = 0x09,//Tab 键
        VK_CLEAR = 0x0C,//CLEAR 键
        VK_RETURN = 0x0D,//Enter 键
        VK_SHIFT = 0x10,//SHIFT 键
        VK_CONTROL = 0x11,//CTRL 键
        VK_MENU = 0x12,//Alt 键
        VK_PAUSE = 0x13,//PAUSE 键
        VK_CAPITAL = 0x14,//CAPS LOCK 键
        VK_KANA = 0x15,//IME Kana 模式
        VK_HANGUL = 0x15,//IME Hanguel 模式
        VK_IME_ON = 0x16,//IME 打开
        VK_JUNJA = 0x17,//IME Junja 模式
        VK_FINAL = 0x18,//IME 最终模式
        VK_HANJA = 0x19,//IME Hanja 模式
        VK_KANJI = 0x19,//IME Kanji 模式
        VK_IME_OFF = 0x1A,//IME 关闭
        VK_ESCAPE = 0x1B,//ESC 键
        VK_CONVERT = 0x1C,//IME 转换
        VK_NONCONVERT = 0x1D,//IME 不转换
        VK_HOME = 0x24,//键盘 Home 键
        VK_LEFT = 0x25,//键盘向左键
        VK_UP = 0x26,//键盘向上键
        VK_RIGHT = 0x27, //键盘向右键
        VK_DOWN = 0x28,      //键盘向下键
        VK_SELECT = 0x29,//	SELECT 键
        VK_PRINT = 0x2A,//PRINT 键
        VK_EXECUTE = 0x2B,//EXECUTE 键
        VK_SNAPSHOT = 0x2C,//PRINT SCREEN 键
        VK_INSERT = 0x2D,//INS 键
        VK_DELETE = 0x2E,//DEL 键
        VK_HELP = 0x2F,//HELP 键
        VK_ACCEPT = 0x1E,//IME 接受
        VK_MODECHANGE = 0x1F,//	IME 模式更改请求
        VK_SPACE = 0x20,//空格键
        VK_PRIOR = 0x21,//PAGE UP 键
        VK_NEXT = 0x22,//PAGE DOWN 键
        VK_END = 0x23,//键盘 End 键

        #endregion

        #region 数字键

        kEY0 = 0x30,//0 键
        kEY1 = 0x31,//1 键
        kEY2 = 0x32,//2 键
        kEY3 = 0x33,//3 键
        kEY4 = 0x34,//4 键
        kEY5 = 0x35,//5 键
        kEY6 = 0x36,//6 键
        kEY7 = 0x37,//7 键
        kEY8 = 0x38,//8 键
        kEY9 = 0x39,//9 键

        #endregion

        #region 字母键

        A = 0x41,//A 键
        B = 0x42,//B 键
        C = 0x43,//C 键
        D = 0x44,//D 键
        E = 0x45,//E 键
        F = 0x46,//F 键
        G = 0x47,//G 键
        H = 0x48,//H 键
        I = 0x49,//I 键
        J = 0x4A,//J 键
        K = 0x4B,//K 键
        L = 0x4C,//L 键
        M = 0x4D,//M 键
        N = 0x4E,//N 键
        O = 0x4F,//O 键
        P = 0x50,//P 键
        W = 0x57,//W 键
        X = 0x58,//X 键
        Y = 0x59,//Y 键
        Q = 0x51,//Q 键
        R = 0x52,//R 键
        S = 0x53,//S 键
        T = 0x54,//T 键
        U = 0x55,//U 键
        V = 0x56,//V 键
        Z = 0x5A,//Z 键

        #endregion

        VK_LWIN = 0x5B,//左 Windows 键
        VK_RWIN = 0x5C,//	右侧 Windows 键
        VK_APPS = 0x5D,//	应用程序密钥
        VK_SLEEP = 0x5F,//	计算机休眠键

        #region 数字键盘

        VK_NUMPAD0 = 0x60,//	数字键盘 0 键
        VK_NUMPAD1 = 0x61,//	数字键盘 1 键
        VK_NUMPAD2 = 0x62,//	数字键盘 2 键
        VK_NUMPAD3 = 0x63,//	数字键盘 3 键
        VK_NUMPAD4 = 0x64,//	数字键盘 4 键
        VK_NUMPAD5 = 0x65,//	数字键盘 5 键
        VK_NUMPAD6 = 0x66,//	数字键盘 6 键
        VK_NUMPAD7 = 0x67,//	数字键盘 7 键
        VK_NUMPAD8 = 0x68,//	数字键盘 8 键
        VK_NUMPAD9 = 0x69,//	数字键盘 9 键
        VK_MULTIPLY = 0x6A,//	乘号键
        VK_ADD = 0x6B,//	加号键
        VK_SEPARATOR = 0x6C,//	分隔符键
        VK_SUBTRACT = 0x6D,//	减号键
        VK_DECIMAL = 0x6E,//	句点键
        VK_DIVIDE = 0x6F,//	除号键

        #endregion

        #region F1-F24

        VK_F1 = 0x70,//F1 键
        VK_F2 = 0x71,//F2 键
        VK_F3 = 0x72,//F3 键
        VK_F4 = 0x73,//F4 键
        VK_F5 = 0x74,//F5 键
        VK_F6 = 0x75,//F6 键
        VK_F7 = 0x76,//F7 键
        VK_F8 = 0x77,//F8 键
        VK_F9 = 0x78,//F9 键
        VK_F10 = 0x79,//F10 键
        VK_F11 = 0x7A,//F11 键
        VK_F12 = 0x7B,//F12 键
        VK_F13 = 0x7C,//F13 键
        VK_F14 = 0x7D,//F14 键
        VK_F15 = 0x7E,//F15 键
        VK_F16 = 0x7F,//F16 键
        VK_F17 = 0x80,//F17 键
        VK_F18 = 0x81,//F18 键
        VK_F19 = 0x82,//F19 键
        VK_F20 = 0x83,//F20 键
        VK_F21 = 0x84,//F21 键
        VK_F22 = 0x85,//F22 键
        VK_F23 = 0x86,//F23 键
        VK_F24 = 0x87,//F24 键

        #endregion

        VK_NUMLOCK = 0x90,//NUM LOCK 键
        VK_SCROLL = 0x91,//SCROLL LOCK 键

        VK_LSHIFT = 0xA0,//左 SHIFT 键
        VK_RSHIFT = 0xA1,//右 SHIFT 键
        VK_LCONTROL = 0xA2,//左 Ctrl 键
        VK_RCONTROL = 0xA3,//右 Ctrl 键
        VK_LMENU = 0xA4,//左 ALT 键
        VK_RMENU = 0xA5,//右 ALT 键

        #region 浏览器及多媒体

        VK_BROWSER_BACK = 0xA6,//浏览器后退键
        VK_BROWSER_FORWARD = 0xA7,//浏览器前进键
        VK_BROWSER_REFRESH = 0xA8,//浏览器刷新键
        VK_BROWSER_STOP = 0xA9,//浏览器停止键
        VK_BROWSER_SEARCH = 0xAA,//浏览器搜索键
        VK_BROWSER_FAVORITES = 0xAB,//	浏览器收藏键
        VK_BROWSER_HOME = 0xAC,//	浏览器“开始”和“主页”键
        VK_VOLUME_MUTE = 0xAD,//	静音键
        VK_VOLUME_DOWN = 0xAE,//	音量减小键
        VK_VOLUME_UP = 0xAF,//	音量增加键
        VK_MEDIA_NEXT_TRACK = 0xB0,//	下一曲目键
        VK_MEDIA_PREV_TRACK = 0xB1,//	上一曲目键
        VK_MEDIA_STOP = 0xB2,//	停止媒体键
        VK_MEDIA_PLAY_PAUSE = 0xB3,//	播放/暂停媒体键
        VK_LAUNCH_MAIL = 0xB4,//	启动邮件键
        VK_LAUNCH_MEDIA_SELECT = 0xB5,//	选择媒体键
        VK_LAUNCH_APP1 = 0xB6,//	启动应用程序 1 键
        VK_LAUNCH_APP2 = 0xB7,//启动应用程序 2 键

        #endregion

        VK_OEM_1 = 0xBA,//	用于杂项字符；它可能因键盘而异。 对于美国标准键盘，键;:
        VK_OEM_PLUS = 0xBB,//	对于任何国家/地区，键+
        VK_OEM_COMMA = 0xBC,//	对于任何国家/地区，键,
        VK_OEM_MINUS = 0xBD,//	对于任何国家/地区，键-
        VK_OEM_PERIOD = 0xBE,//	对于任何国家/地区，键.
        VK_OEM_2 = 0xBF,//	用于杂项字符；它可能因键盘而异。 对于美国标准键盘，键/?
        VK_OEM_3 = 0xC0,//	用于杂项字符；它可能因键盘而异。 对于美国标准键盘，键`~
        VK_OEM_4 = 0xDB,//	用于杂项字符；它可能因键盘而异。 对于美国标准键盘，键[{
        VK_OEM_5 = 0xDC,//	用于杂项字符；它可能因键盘而异。 对于美国标准键盘，键\\|
        VK_OEM_6 = 0xDD,//	用于杂项字符；它可能因键盘而异。 对于美国标准键盘，键]}
        VK_OEM_7 = 0xDE,//	用于杂项字符；它可能因键盘而异。 对于美国标准键盘，键'"
        VK_OEM_8 = 0xDF,//	用于杂项字符；它可能因键盘而异。
        VK_OEM_102 = 0xE2,//	美国标准键盘上的<> 键，或非美国 102 键键盘上的 \\| 键
        VK_PROCESSKEY = 0xE5,//	IME PROCESS 键
        VK_PACKET = 0xE7,//	用于将 Unicode 字符当作键击传递。 VK_PACKET 键是用于非键盘输入法的 32 位虚拟键值的低位字。 有关更多信息，请参阅 KEYBDINPUT、SendInput、WM_KEYDOWN 和 WM_KEYUP 中的注释
        VK_ATTN = 0xF6,//	Attn 键
        VK_CRSEL = 0xF7,//	CrSel 键
        VK_EXSEL = 0xF8,//	ExSel 键
        VK_EREOF = 0xF9,//	Erase EOF 键
        VK_PLAY = 0xFA,//	Play 键
        VK_ZOOM = 0xFB,//	Zoom 键
        VK_PA1 = 0xFD,//	PA1 键
        VK_OEM_CLEAR = 0xFE,//	Clear 键
    }
}
