namespace CarSharing.WebApi.Client.Mappers.Client.Request
{
    using System.Security.Claims;
    using CarSharing.Domain.Dto.Client.Request;
    using CarSharing.WebApi.Common.Claims;
    using CarSharingClaimTypes = CarSharing.WebApi.Common.Claims.ClaimTypes;
    using ClaimTypes = System.Security.Claims.ClaimTypes;

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
                ClientId = ClaimsHelper.GetClientId(principal),
                Name = principal.FindFirst(ClaimTypes.Name)?.Value,
                Surname = principal.FindFirst(ClaimTypes.Surname)?.Value,
                LicenseNumber = principal.FindFirst(CarSharingClaimTypes.LicenseNumber)?.Value,
                PhoneNumber = principal.FindFirst(ClaimTypes.MobilePhone)?.Value,
                Email = principal.FindFirst(ClaimTypes.Email)?.Value
            };
        }
    }
}
