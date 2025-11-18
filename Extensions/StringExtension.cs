using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO.Compression;
using System.Text;
using Sys.Enum;

namespace Sys.Extensions
{
    /// <summary>
    /// 扩展方法
    /// </summary>
    public static class StringExtension
    {
        public static bool IsNullOrEmpty([NotNullWhen(false)] this string? s)
            => string.IsNullOrEmpty(s);
        public static bool NotNullOrEmpty([NotNullWhen(true)] this string? s)
            => !string.IsNullOrEmpty(s);
        public static bool IsNullOrWhiteSpace([NotNullWhen(false)] this string? s)
            => string.IsNullOrWhiteSpace(s);
        public static bool NotNullOrWhiteSpace([NotNullWhen(true)] this string? s)
            => !string.IsNullOrWhiteSpace(s);

        /// <summary>
        /// 将字符串转换为指定长度的ASCII字节数组
        /// </summary>
        /// <param name="s">字符串</param>
        /// <param name="len">指定的长度</param>
        /// <returns>生成的字节数组</returns>
        public static byte[] ToLimitAsciiBytes(this string s, int len)
        {
            var a = new byte[len];
            Encoding.ASCII.GetBytes(s, 0, Math.Min(len, s.Length), a, 0);
            return a;
        }

        public static bool FileExists(this string? s)
            => File.Exists(s);
        public static bool FileNotExists(this string? s)
            => !File.Exists(s);
        public static bool DirExists(this string? s)
            => Directory.Exists(s);
        public static bool DirNotExists(this string? s)
            => !Directory.Exists(s);

        public static string[] ExtractZip(this string zipPath,string extractPath) 
        {
            foreach (var file in Directory.GetFiles(extractPath, "*", SearchOption.AllDirectories))
                File.Delete(file);

            try  
            {  
                // 解压缩ZIP文件  
                ZipFile.ExtractToDirectory(zipPath, extractPath);
                return Directory.GetFiles(extractPath, "*", SearchOption.AllDirectories);
            }  
            catch (Exception ex)  
            {  
                Console.WriteLine($"解压缩失败，错误信息：{ex.Message}");
                return [];
            }  
        }

        public static string RemoveInvalidCharsInPath(this string path)
            => Path.GetInvalidPathChars()
                .Aggregate(path, (current, c) => current.Replace(c.ToString(),""));


        public static string Format(this string format, params object[] args)
            => string.Format(format, args);

        public static string ConvStr(this IEnumerable<char> ca) => new(ca.ToArray());

        public static IEnumerable<byte> ConvEncoder(this IEnumerable<byte> ba, KnownCodePage scp, KnownCodePage tcp)
            => Encoding.Convert(Encoding.GetEncoding((int)scp), Encoding.GetEncoding((int)tcp), ba.ToArray());

        /// <summary>
        /// 将一组字符串合并成一个文本
        /// </summary>
        /// <param name="strArray"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string Join(this IEnumerable<string> strArray, string separator = "")
            => string.Join(separator, strArray);
        /// <summary>
        /// 字符转码
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static byte[] ToUtf8Byte(this string s)
            => Encoding.UTF8.GetBytes(s);
        /// <summary>
        /// 字串转整数
        /// </summary>
        /// <param name="s">字串</param>
        /// <param name="ns">数字样式，默认为Integer</param>
        /// <param name="fi">数值格式,默认为null，表示CurrentInfo</param>
        /// <returns></returns>
        public static int ToInt(this string s, NumberStyles ns = NumberStyles.Integer, NumberFormatInfo? fi = null)
            => int.Parse(s, ns, fi ?? NumberFormatInfo.CurrentInfo);
        /// <summary>
        /// 指定进制的字串转整数
        /// </summary>
        /// <param name="s"></param>
        /// <param name="frombase">进制，只能为2 8 10 16</param>
        /// <returns></returns>
        public static int ToInt(this string s, int frombase)
            => Convert.ToInt32(s, frombase);

        /// <summary>
        /// 尝试字串转整数
        /// </summary>
        /// <param name="s">字串</param>
        /// <param name="i">获得的数值</param>
        /// <param name="ns">数字样式，默认为Integer</param>
        /// <param name="fi">数值格式,默认为null，表示CurrentInfo</param>
        /// <returns></returns>
        public static bool TryToInt(this string s,out int i, NumberStyles ns = NumberStyles.Integer, NumberFormatInfo? fi = null)
            => int.TryParse(s, ns, fi ?? NumberFormatInfo.CurrentInfo,out i);

        /// <summary>
        /// 码转字符
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static string ToUtf8String(this byte[] b)
            => Encoding.UTF8.GetString(b);

        /// <summary>
        /// 按代码页将字节转字符
        /// </summary>
        /// <param name="b"></param>
        /// <param name="codePage"></param>
        /// <returns></returns>
        public static string ToString(this byte[] b,KnownCodePage? codePage=null)
            => (codePage is {} cp1 
                ? cp1.GetEncoding()  
                : Encoding.Default)
                .GetString(b);
        /// <summary>
        /// 给输入的本机路径或者远程路径增加长路径前缀
        /// </summary>
        /// <param name="path"></param>
        /// <param name="limit">是否判断长度，True则判断长度，超过250才加前缀,否则一定加前缀，默认为True</param>
        /// <returns></returns>
        public static string ToLongPath(this string path, bool limit = true) => path.IsNullOrEmpty() || path.StartsWith(@"\\?\")
            ? path
            : limit && path.Length < 255
                ? path
                : path.StartsWith(@"\\")
                    ? @"\\?\UNC\" + path.Substring(2)
                    : @"\\?\" + path;

        public static Encoding GetEncoding(this KnownCodePage codePage)
            => Encoding.GetEncoding((int)codePage);

        public static byte[] GetBytes(this string text, KnownCodePage codePage)
            => Encoding.GetEncoding((int)codePage).GetBytes(text);

        /// <summary>
        /// 计算字串中含有多少个指定字串
        /// </summary>
        /// <param name="source">被计算的字串</param>
        /// <param name="substring">计算个数的字串</param>
        /// <param name="comparison">比较方式，默认二进制</param>
        /// <returns></returns>
        public static int ContainCount(this string source, string substring, StringComparison comparison= StringComparison.Ordinal)
        {
            if (source.IsNullOrEmpty() || substring.IsNullOrEmpty())
                return 0;

            int count = 0;
            int index = 0;

            while ((index = source.IndexOf(substring, index, comparison)) != -1)
            {
                count++;
                index += substring.Length; // 移动索引到下一个潜在匹配的开始位置  
            }

            return count;
        }
    }
}
