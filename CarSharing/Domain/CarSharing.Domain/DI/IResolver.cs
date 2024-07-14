namespace CarSharing.Domain.DI
{
    public interface IResolver
    {
        T Resolve<T>();
    }
}
