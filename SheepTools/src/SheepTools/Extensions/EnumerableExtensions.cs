namespace SheepTools.Extensions;

public static class EnumerableExtensions
{
    public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
    {
        if (enumerable is List<T> list)
        {
            list.ForEach(action);
        }
        else
        {
            foreach (T item in enumerable)
            {
                action(item);
            }
        }
    }

    public static bool IsNullOrEmpty<T>(this IEnumerable<T>? enumerable)
    {
        return enumerable?.Any() != true;
    }

    /// <summary>
    /// https://stackoverflow.com/a/1674779/5459321
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="enumerableOfEnumerable"></param>
    /// <returns></returns>
    public static HashSet<T> IntersectAll<T>(this IEnumerable<IEnumerable<T>> enumerableOfEnumerable)
    {
        HashSet<T>? hashSet = null;
        foreach (var enumerable in enumerableOfEnumerable)
        {
            if (hashSet == null)
            {
                hashSet = new HashSet<T>(enumerable);
            }
            else
            {
                hashSet.IntersectWith(enumerable);
            }
        }
        return hashSet ?? new HashSet<T>();
    }

    public static HashSet<char> IntersectAll(this IEnumerable<string> enumerableOfStrings)
    {
        return IntersectAll(enumerableOfStrings.Select(str => str.AsEnumerable()));
    }
}
