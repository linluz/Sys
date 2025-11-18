using System.Collections;
using System.Text.RegularExpressions;
using Sys.Enum;
using System.Diagnostics.CodeAnalysis;

namespace Sys.Extensions
{
    public static class ArrayExtension
    {
        public static bool IsNullOrEmpty<T>([NotNullWhen(false)] this IEnumerable<T>? s)
            => !s.NotNullOrEmpty();

        public static bool NotNullOrEmpty<T>([NotNullWhen(true)] this IEnumerable<T>? s)
            => s != null && s.Any();

        public static IEnumerable<TSource> Flatten<TSource>(this IEnumerable<IEnumerable<TSource>>? source)
            => source == null
                ? throw new ArgumentNullException(nameof(source))
                : source.SelectMany(t => t);

        public static IEnumerable<TTarget> Invoke<TSource, TTarget>(this IEnumerable<TSource>? source,
            Func<IEnumerable<TSource>, IEnumerable<TTarget>>? func)
            => source == null
                ? throw new ArgumentNullException(nameof(source))
                : func == null
                    ? throw new ArgumentNullException(nameof(func))
                    : func.Invoke(source);

        /// <summary>
        /// 将集合中的元素替换为指定的集合
        /// </summary>
        /// <typeparam name="T">项类型</typeparam>
        /// <param name="dest">原始集合</param>
        /// <param name="source">含有新项目的集合</param>
        /// <param name="shrink">当真时，若<paramref name="source"/>的容量小于<paramref name="dest"/>时会收缩目标数组的容量</param>
        /// <returns>替换后的原始集合</returns>
        public static T[] Replace<T>(this T[] dest, T[] source, bool shrink = false)
        {
            if (dest.Length < source.Length
                || (shrink
                    && source.Length < dest.Length))
                Array.Resize(ref dest, source.Length);

            Array.Copy(source, dest, source.Length);
            return source;
        }

        public static IEnumerable<T?> ToEnumerable<T>(this IEnumerable source, ToEnumerableFailMode mode = ToEnumerableFailMode.Exception) where T : class
        {
#if NET6_0_OR_GREATER
            ArgumentNullException.ThrowIfNull(source);
#else
            if (source == null)
                throw new ArgumentNullException(nameof(source));
#endif

            foreach (var item in source)
            {
                if (item is T t)
                    yield return t;

                switch (mode)
                {
                    case ToEnumerableFailMode.Exception:
                        throw new InvalidCastException($"不能将元素转换为类型 {typeof(T)}");
                    case ToEnumerableFailMode.AsDefault:
                        yield return null;
                        break;
                    case ToEnumerableFailMode.Skip:
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
                }
            }
        }
#if NET48_OR_GREATER
       
        /// <summary>
        /// 将来源数组分成指定长度的段
        /// </summary>
        /// <typeparam name="TSource">来源数组的类型</typeparam>
        /// <param name="source">来源数组</param>
        /// <param name="count">分段长度</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static IEnumerable<TSource[]> Chunk<TSource>(this IEnumerable<TSource>? source, int count)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (count <= 0) throw new ArgumentOutOfRangeException(nameof(count), "Chunk size must be greater than zero.");

            var chunk = new TSource[count];
            int i = 0;

            foreach (var item in source)
            {
                chunk[i] = item;
                i++;

                // 检查是否达到每个 chunk 的大小  
                if (i != count) continue;
                yield return chunk; // 封装为一个 List<T> 使用yield返回  
                chunk = new TSource[count]; // 重新初始化 chunk  
                i = 0; // 重置计数器  
            }

            // 返回剩余的元素  
            if (i > 0)
            {
                yield return chunk;
            }
        } 
#endif

        /// <summary>
        /// 将两个数组轮流交错成一个新的数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first">第一个数组，第一个成员会成为新数组的第一个成员</param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static IEnumerable<T> Interleave<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            // 使用 IEnumerator 来遍历两个集合  
            using var enumerator1 = first.GetEnumerator();
            using var enumerator2 = second.GetEnumerator();
            bool hasMoreElements1 = enumerator1.MoveNext();
            bool hasMoreElements2 = enumerator2.MoveNext();

            // 轮流添加元素  
            while (hasMoreElements1 || hasMoreElements2)
            {
                if (hasMoreElements1)
                {
                    yield return enumerator1.Current; // 添加第一个集合的当前元素  
                    hasMoreElements1 = enumerator1.MoveNext(); // 移动到下一个元素  
                }

                if (hasMoreElements2)
                {
                    yield return enumerator2.Current; // 添加第二个集合的当前元素  
                    hasMoreElements2 = enumerator2.MoveNext(); // 移动到下一个元素  
                }
            }
        }

        public static IEnumerable<Match> AsEnumerable(this MatchCollection source)
        {
            for (int i = 0; i < source.Count; i++)
                yield return source[i];
        }

        public static IEnumerable<(T Item, int Index)> WithIndex<T>(this IEnumerable<T>? source)
        {
            if (source.IsNullOrEmpty())
                yield break ;
            int i = 0;
            using var enu = source.GetEnumerator();
            while (enu.MoveNext())
                yield return (enu.Current, i++);
        }

        /// <summary>
        /// 将来源数组的数值复制到目标数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">含有被复制的数据的数组</param>
        /// <param name="target">目标数组</param>
        /// <param name="sourceIndex">来源数组中要复制的数据的起始索引</param>
        /// <param name="targetIndex">目标数组中贴入位置的起始索引</param>
        /// <param name="length"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static T[] CopyArray<T>(this T[]? source, T[]? target, int sourceIndex, int targetIndex, int length)
        {
#if NET9_0_OR_GREATER
            ArgumentNullException.ThrowIfNull(source);
            ArgumentNullException.ThrowIfNull(target);
#else
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (target == null)
                throw new ArgumentNullException(nameof(target));
#endif
            if (sourceIndex < 0 || sourceIndex >= source.Length)
                throw new ArgumentOutOfRangeException(nameof(sourceIndex));
            if (targetIndex < 0 || targetIndex >= target.Length)
                throw new ArgumentOutOfRangeException(nameof(targetIndex));
            if (sourceIndex + length - source.Length >= 0)
                throw new ArgumentOutOfRangeException(nameof(length), $"{length}不能超出{source}的范围");
            if (targetIndex + length - target.Length >= 0)
                throw new ArgumentOutOfRangeException(nameof(length), $"{length}不能超出{target}的范围");
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length), $"{length}不能小于0");
            Array.Copy(source, sourceIndex, target, targetIndex, length);
            return target;
        }
        /// <summary>
        /// 查找第一个索引
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TItem"></typeparam>
        /// <param name="source"></param>
        /// <param name="item"></param>
        /// <param name="equalfsFunc"></param>
        /// <returns></returns>
        public static int FirstIndex<TSource, TItem>(this TSource[]? source, TItem item, Func<TSource?, TItem?, bool>? equalfsFunc = null)
        {
            if (source == null)
                return -1;
            equalfsFunc ??= (s, i) => s == null
                ? typeof(TSource) == typeof(TItem) && i == null
                : s.Equals(i);
            for (int i = 0; i < source.Length; i++)
                if (equalfsFunc.Invoke(source[i], item))
                    return i;
            return -1;
        }

        /// <summary>
        /// 尝试将元素添加到 HashSet 中，如果元素为 null 则自动忽略
        /// </summary>
        /// <typeparam name="T">HashSet 的元素类型</typeparam>
        /// <param name="hashSet">HashSet 集合</param>
        /// <param name="item">要添加的元素</param>
        /// <returns>如果元素成功添加到集合中，则为 true；如果元素已存在或为 null，则为 false</returns>
        public static bool AddIfNotNull<T>(this HashSet<T> hashSet, T? item) where T : class 
            => item != null && hashSet.Add(item);
    }
}