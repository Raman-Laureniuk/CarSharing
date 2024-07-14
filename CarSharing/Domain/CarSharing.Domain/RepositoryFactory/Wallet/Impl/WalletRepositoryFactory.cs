namespace CarSharing.Domain.RepositoryFactory.Wallet.Impl
{
    using CarSharing.Domain.DI;
    using CarSharing.Domain.Repository.Wallet;
    using CarSharing.Domain.RepositoryFactory.Base.Impl;

    public class WalletRepositoryFactory : RepositoryFactory<IWalletRepository>, IWalletRepositoryFactory
    {
        public WalletRepositoryFactory(IResolver resolver)
            : base(resolver)
        {
        }
    }
}
