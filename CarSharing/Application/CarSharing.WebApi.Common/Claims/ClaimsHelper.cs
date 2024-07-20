namespace CarSharing.WebApi.Common.Claims
{
    using System;
    using System.Security.Claims;

    public static class ClaimsHelper
    {
        public static Guid GetClientId(ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentNullException(nameof(principal));
            }

            string userId = principal.FindFirst(ClaimTypes.UserId)?.Value ?? throw new ArgumentException($"{ClaimTypes.UserId} claim not found.");

            return Guid.Parse(userId);
        }
    }
}
