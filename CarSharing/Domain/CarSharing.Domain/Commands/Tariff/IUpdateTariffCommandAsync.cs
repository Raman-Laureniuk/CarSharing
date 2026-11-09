namespace CarSharing.Domain.Commands.Tariff
{
    using CarSharing.Domain.Commands.Base;
    using CarSharing.Domain.Dto.Tariff.Request;

    internal interface IUpdateTariffCommandAsync : ICommandAsync<UpdateTariffRequestDto>
    {
    }
}
