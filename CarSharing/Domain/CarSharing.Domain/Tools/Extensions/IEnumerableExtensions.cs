namespace CarSharing.Domain.Tools.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> OrEmptyIfNull<T>(this IEnumerable<T> values)
        {
            return values ?? Enumerable.Empty<T>();
        }
    }
}
