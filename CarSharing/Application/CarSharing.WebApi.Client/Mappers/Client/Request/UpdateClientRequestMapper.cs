namespace CarSharing.WebApi.Client.Mappers.Client.Request
{
    using System;
    using System.Security.Claims;
    using CarSharing.Domain.Dto.Client.Request;
    using CarSharingClaimTypes = CarSharing.WebApi.Common.Claims.ClaimTypes;

    internal static class UpdateClientRequestMapper
    {
        public static UpdateClientRequestDto ToUpdateClientRequestDto(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                return null;
            }

            return new UpdateClientRequestDto()
            {
                ClientId = Guid.Parse(principal.FindFirst(CarSharingClaimTypes.UserId)?.Value),
                Name = principal.FindFirst(ClaimTypes.Name)?.Value,
                Surname = principal.FindFirst(ClaimTypes.Surname)?.Value,
                LicenseNumber = principal.FindFirst(CarSharingClaimTypes.LicenseNumber)?.Value,
                PhoneNumber = principal.FindFirst(ClaimTypes.MobilePhone)?.Value,
                Email = principal.FindFirst(ClaimTypes.Email)?.Value
            };
        }
    }
}
