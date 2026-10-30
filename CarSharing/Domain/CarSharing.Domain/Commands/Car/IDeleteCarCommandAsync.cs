namespace CarSharing.Domain.Commands.Car
{
    using CarSharing.Domain.Commands.Base;
    using CarSharing.Domain.Dto.Car.Request;

    internal interface IDeleteCarCommandAsync : ICommandAsync<DeleteCarRequestDto>
    {
    }
}
