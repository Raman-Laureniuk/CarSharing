namespace CarSharing.Domain.Commands.Base
{
    using System.Threading.Tasks;
    using CarSharing.Domain.Tools.Result;

    internal interface ICommandAsync<TRequest>
    {
        Task<Result> ExecuteAsync(TRequest request);
    }

    internal interface ICommandAsync<TRequest, TResponse>
    {
        Task<Result<TResponse>> ExecuteAsync(TRequest request);
    }
}
