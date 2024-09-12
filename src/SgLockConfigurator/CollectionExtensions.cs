namespace SgLockConfigurator;

/// <summary>
/// Extension methods for <see cref="ICollection{T}"/>.
/// </summary>
public static class CollectionExtensions
{
    /// <summary>
    /// Add multiple items to the <see cref="ICollection{T}"/>.
    /// </summary>
    /// <typeparam name="T">The stored type.</typeparam>
    /// <param name="collection">The source collection.</param>
    /// <param name="items">The items to add.</param>
    public static void AddMany<T>(this ICollection<T> collection, IEnumerable<T> items)
    {
        foreach (var item in items)
        {
            collection.Add(item);
        }
    }
}
