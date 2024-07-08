﻿namespace CarSharing.Domain.Commands.Tariff
{
    using CarSharing.Domain.Commands.Base;
    using CarSharing.Domain.Dto.Tariff.Request;
    using CarSharing.Domain.Dto.Tariff.Response;

    internal interface ICalculatePriceCommand : ICommand<CalculatePriceRequestDto, CalculatePriceResponseDto>
    {
    }
}