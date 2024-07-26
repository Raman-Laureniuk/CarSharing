namespace CarSharing.Infrastructure.Providers.Payment.Impl.Transaction
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    internal class TransactionEqualityComparer : IEqualityComparer<TransactionItem>
    {
        public bool Equals(TransactionItem x, TransactionItem y)
        {
            if (x == null && y == null)
            {
                return true;
            }

            if (x == null || y == null)
            {
                return false;
            }

            return x.TransactionId == y.TransactionId;
        }

        public int GetHashCode([DisallowNull] TransactionItem obj)
        {
            return obj?.TransactionId?.GetHashCode() ?? 0;
        }
    }
}
