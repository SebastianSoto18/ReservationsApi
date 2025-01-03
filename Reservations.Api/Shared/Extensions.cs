using System.Security.Claims;

namespace Reservations.Api.Shared;

public static class Extensions
{
    public static long GetUserIdHttpContext(this IHttpContextAccessor httpContextAccessor)
        => long.Parse(httpContextAccessor.HttpContext?.User.GetClaimValue(ClaimTypes.NameIdentifier));
    
    public static string GetClaimValue(this ClaimsPrincipal userClaimsPrincipal, string claimType)
        => userClaimsPrincipal.Claims
            .Where(claim => claim.Type.Equals(claimType, StringComparison.InvariantCultureIgnoreCase))
            .Select(claim => claim.Value)
            .FirstOrDefault();
}