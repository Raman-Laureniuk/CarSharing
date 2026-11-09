namespace CarSharing.Domain.Commands.Base
{
    using CarSharing.Domain.Tools.Result;

    internal interface ICommand<TRequest>
    {
        Result Execute(TRequest request);
    }
    
    internal interface ICommand<TRequest, TResponse>
    {
        Result<TResponse> Execute(TRequest request);
    }
}
