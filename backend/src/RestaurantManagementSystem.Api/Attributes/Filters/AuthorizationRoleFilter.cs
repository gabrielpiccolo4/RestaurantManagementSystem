using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RestaurantManagementSystem.Common.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace RestaurantManagementSystem.Api.Attributes.Filters
{
    /// <summary>
    /// Filter for the RoleAuthorize Attribute
    /// </summary>
    public class AuthorizationRoleFilter : IAuthorizationFilter
    {
        private readonly Roles[] _roles;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationRoleFilter"/> class
        /// </summary>
        /// <param name="roles">Roles</param>
        public AuthorizationRoleFilter(Roles[] roles)
        {
            _roles = roles;
        }

        /// <summary>
        /// Checks if the request is authorized
        /// </summary>
        /// <param name="context">Context for authorization filters</param>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
                return;
            }

            if (!ValidateClaimRole(context.HttpContext.User.Claims, _roles))
            {
                context.Result = new StatusCodeResult(StatusCodes.Status403Forbidden);
            }
        }

        private bool ValidateClaimRole(IEnumerable<Claim> claims, Roles[] roles)
        {
            return claims.Where(c => c.Type == ClaimTypes.Role).Any(c => roles.Any(r => r.ToString() == c.Value));
        }
    }
}
