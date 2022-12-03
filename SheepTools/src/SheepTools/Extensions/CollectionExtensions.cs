namespace SheepTools.Extensions;

public static class CollectionExtensions
{
    public static void AddRange<T>(this ICollection<T> destination, IEnumerable<T> source)
    {
        if (destination is List<T> list)
        {
            list.AddRange(source);
        }
        else
        {
            foreach (T item in source)
            {
                destination.Add(item);
            }
        }
    }

    public static int RemoveAll<T>(this ICollection<T> collection, Predicate<T> match)
    {
        if (collection is List<T> list)
        {
            return list.RemoveAll(match);
        }
        else
        {
            int oldCount = collection.Count;

            collection.Where(entity => match(entity))
              .ToList()
              .ForEach(entity => collection.Remove(entity));

            return oldCount - collection.Count;
        }
    }
}
