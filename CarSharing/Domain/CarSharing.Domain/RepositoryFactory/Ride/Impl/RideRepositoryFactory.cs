namespace CarSharing.Domain.RepositoryFactory.Ride.Impl
{
    using CarSharing.Domain.DI;
    using CarSharing.Domain.Repository.Ride;
    using CarSharing.Domain.RepositoryFactory.Base.Impl;

    public class RideRepositoryFactory : RepositoryFactory<IRideRepository>, IRideRepositoryFactory
    {
        public RideRepositoryFactory(IResolver resolver)
            : base(resolver)
        {
        }
    }
}
