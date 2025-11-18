using System.Runtime.Versioning;
using Windows.Win32.Storage.FileSystem;

namespace Sys.Com.IO
{
    [SupportedOSPlatform("windows6.0")]
    public static class IoFileMethod
    {
        // SetFilePointer
        // ReadFile
        // GetFileSize
        // SetEndOfFile
        // WriteFile

        /// <summary>
        /// 创建或打开一个文件
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="desiredAccess"></param>
        /// <param name="shareMode"></param>
        /// <param name="creationDisposition"></param>
        /// <param name="flagsAndAttributes"></param>
        /// <returns></returns>
        public static int CreateFile(string filename,FileMapping desiredAccess, FileMapping shareMode, FileMapping creationDisposition, FileMapping flagsAndAttributes)
        =>(int)PInvoke.CreateFile(filename,(uint)desiredAccess,(FILE_SHARE_MODE)(uint)shareMode,null,(FILE_CREATION_DISPOSITION)(uint)creationDisposition,(FILE_FLAGS_AND_ATTRIBUTES)(uint)flagsAndAttributes,new SafeFileHandle((IntPtr)0,true)).DangerousGetHandle();

        public static bool CloseHandle(int handle) => PInvoke.CloseHandle((HANDLE)(IntPtr)handle);

        public static int GetFileSize(int handle)
        {
            unsafe
            {
                return (int)PInvoke.GetFileSize((HANDLE)(IntPtr)handle);
            }
        }

        public static int SetFilePointer(int handle,int lpDistanceToMoveHigh)
        {
            unsafe
            {
                 return (int)PInvoke.SetFilePointer(new SafeFileHandle((IntPtr)handle, true),  lpDistanceToMoveHigh, (int*)0, 0);
            }
        }

        public static bool SetEndOfFile(int handle)=> PInvoke.SetEndOfFile((HANDLE)(IntPtr)handle);
    }
}
