namespace CarSharing.Domain.Commands.Car
{
    using CarSharing.Domain.Commands.Base;
    using CarSharing.Domain.Dto.Car.Request;
    using CarSharing.Domain.Dto.Car.Response;

    internal interface IUpdateCarCommandAsync : ICommandAsync<UpdateCarRequestDto, UpdateCarResponseDto>
    {
    }
}
