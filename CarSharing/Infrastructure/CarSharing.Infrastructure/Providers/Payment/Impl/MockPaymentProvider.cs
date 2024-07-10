namespace CarSharing.Infrastructure.Providers.Payment.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CarSharing.Domain.Dto.Payment.Request;
    using CarSharing.Domain.Dto.Payment.Response;
    using CarSharing.Domain.Providers.Payment;
    using CarSharing.Infrastructure.Providers.Payment.Impl.Transaction;

    public class MockPaymentProvider : IPaymentProvider
    {
        private readonly HashSet<TransactionItem> _transactions = new HashSet<TransactionItem>(new TransactionEqualityComparer());

        public Task<AuthorizeResponseDto> AuthorizeAsync(AuthorizeRequestDto request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            
            string transactionId = Guid.NewGuid().ToString();

            TransactionItem transaction = new TransactionItem()
            {
                TransactionId = transactionId,
                AuthorizeAmount = request.AuthorizeAmount,
                FinalizeAmount = null,
                EncryptedWalletData = request.EncryptedWalletData
            };

            bool added = _transactions.Add(transaction);

            if (!added)
            {
                throw new Exception("Couldn't add transaction.");
            }

            return Task.FromResult(new AuthorizeResponseDto()
            {
                Success = true,
                TransactionId = transactionId
            });
        }

        public Task<CancelResponseDto> CancelAsync(CancelRequestDto request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            TransactionItem transaction = _transactions.Single(x => x.TransactionId == request.TransactionId);
            
            _transactions.Remove(transaction);

            return Task.FromResult(new CancelResponseDto()
            {
                Success = true
            });
        }

        public Task<FinalizeResponseDto> FinalizeAsync(FinalizeRequestDto request)
        {
            TransactionItem transaction = _transactions.Single(x => x.TransactionId == request.TransactionId);

            if (request.FinalizeAmount > transaction.AuthorizeAmount)
            {
                throw new ArgumentException("Can't finalize with greater amount.");
            }
            
            transaction.FinalizeAmount = request.FinalizeAmount;

            return Task.FromResult(new FinalizeResponseDto()
            {
                Success = true
            });
        }
    }
}
