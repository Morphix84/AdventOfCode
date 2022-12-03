namespace SheepTools.Extensions;

public static class DictionaryExtensions
{
    public static TValue AddOrUpdate<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue addValue, Func<TKey, TValue, TValue> updateValueFactory)
        where TKey : notnull
    {
        if (dictionary.TryGetValue(key, out var oldValue))
        {
            var newValue = updateValueFactory(key, oldValue);
            dictionary[key] = newValue;

            return newValue;
        }
        else
        {
            dictionary.Add(key, addValue);

            return addValue;
        }
    }

    public static TValue AddOrUpdate<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> addValueFactory, Func<TKey, TValue, TValue> updateValueFactory)
        where TKey : notnull
    {
        var newValue = dictionary.TryGetValue(key, out var oldValue)
            ? updateValueFactory(key, oldValue)
            : addValueFactory(key);

        dictionary[key] = newValue;

        return newValue;
    }

    public static TValue AddOrUpdate<TKey, TValue, TArg>(this Dictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TArg, TValue> addValueFactory, Func<TKey, TValue, TArg, TValue> updateValueFactory, TArg factoryArgument)
        where TKey : notnull
    {
        var newValue = dictionary.TryGetValue(key, out var oldValue)
            ? updateValueFactory(key, oldValue, factoryArgument)
            : addValueFactory(key, factoryArgument);

        dictionary[key] = newValue;

        return newValue;
    }
}
