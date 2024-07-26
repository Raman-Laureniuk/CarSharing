namespace CarSharing.Domain.Commands.Base
{
    internal interface ICommand<TRequest, TResponse>
    {
        TResponse Execute(TRequest request);
    }
}
