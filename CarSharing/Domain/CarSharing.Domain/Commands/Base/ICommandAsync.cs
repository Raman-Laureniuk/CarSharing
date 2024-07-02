namespace CarSharing.Domain.Commands.Base
{
    using System.Threading.Tasks;

    internal interface ICommandAsync<TRequest, TResponse>
    {
        Task<TResponse> ExecuteAsync(TRequest request);
    }
}
