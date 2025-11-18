using System.IO.Compression;
using Sys.Enum;

namespace Sys.Extensions.Compression
{
    public static class ZipFileExtensions
    {
        /// <summary>
        /// 解压zip文件
        /// </summary>
        /// <param name="zipPath">压缩包路径</param>
        /// <param name="extractPath">解压路径</param>
        /// <param name="codePage">解压编码</param>
        /// <param name="overwrite">是否覆盖文件</param>
        /// <param name="deleteZip">解压后是否删除zip文件</param>
        /// <returns>解压出的全部文件名</returns>
        public static string[] ExtractZip(this string zipPath, string extractPath, KnownCodePage codePage = KnownCodePage.CP_UNKNOWN,
            bool overwrite = false, bool deleteZip = false)
        {
            try
            {
                // 解压缩ZIP文件  
                var fa = zipPath.ExtractToDirectory(extractPath, codePage, overwrite);
                if (deleteZip && zipPath.FileExists())
                    File.Delete(zipPath);
                return fa;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"解压缩{zipPath}失败，错误信息：{ex.Message}");
                return [];
            }
        }
        /// <summary>
        /// 解压zip文件到文件夹
        /// </summary>
        /// <param name="sourceArchiveFileName">zip文件名</param>
        /// <param name="destinationDirectoryName">目标目录名</param>
        /// <param name="codePage">解压编码</param>
        /// <param name="overwrite">是否覆盖文件</param>
        /// <returns>解压出的全部文件名</returns>
        /// <exception cref="ArgumentNullException">zip文件名为空导致的</exception>
        public static string[] ExtractToDirectory(
            this string? sourceArchiveFileName,
            string? destinationDirectoryName,
            KnownCodePage codePage,
            bool overwrite = false)
        {
            if (sourceArchiveFileName == null)
                throw new ArgumentNullException(nameof(sourceArchiveFileName));
            using var source = ZipFile.Open(sourceArchiveFileName, ZipArchiveMode.Read, codePage == KnownCodePage.CP_UNKNOWN ? null : codePage.GetEncoding());
            return source.ExtractToDirectory(destinationDirectoryName, overwrite).ToArray();
        }
        /// <summary>
        /// 解压zip文件到文件夹
        /// </summary>
        /// <param name="source">来源的zip文件</param>
        /// <param name="destinationDirectoryName">目标目录名</param>
        /// <param name="overwrite">是否覆盖文件</param>
        /// <returns>解压出的全部文件名</returns>
        /// <exception cref="ArgumentNullException">参数不能为null</exception>
        /// <exception cref="IOException">压缩包有错误</exception>
        public static IEnumerable<string> ExtractToDirectory(this ZipArchive? source, string? destinationDirectoryName, bool overwrite = false)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            string destinationDirectory = destinationDirectoryName != null
                ? Directory.CreateDirectory(destinationDirectoryName).FullName
                : throw new ArgumentNullException(nameof(destinationDirectoryName));

            foreach (var entry in source.Entries)
            {
                string fullPath = Path.GetFullPath(Path.Combine(destinationDirectory, entry.FullName));
                if (!fullPath.StartsWith(destinationDirectory, StringComparison.OrdinalIgnoreCase))
                    throw new IOException("解压结果在目标目录之外");
                if (Path.GetFileName(fullPath).Length == 0)
                {
                    if (entry.Length != 0L)
                        throw new IOException("目录名称包含数据");
                    Directory.CreateDirectory(fullPath);
                }
                else
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(fullPath)!);
                    if (overwrite || fullPath.FileNotExists())
                        entry.ExtractToFile(fullPath, overwrite);
                    yield return fullPath;
                }
            }
        }
    }
}
