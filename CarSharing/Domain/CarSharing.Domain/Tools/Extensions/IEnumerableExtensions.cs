namespace CarSharing.Domain.Tools.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    internal static class IEnumerableExtensions
    {
        public static IEnumerable<T> OrEmptyIfNull<T>(this IEnumerable<T> values)
        {
            return values ?? Enumerable.Empty<T>();
        }
    }
}
