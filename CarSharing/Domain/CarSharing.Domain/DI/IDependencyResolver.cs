namespace CarSharing.Domain.DI
{
    public interface IDependencyResolver
    {
        T Resolve<T>();
    }
}
