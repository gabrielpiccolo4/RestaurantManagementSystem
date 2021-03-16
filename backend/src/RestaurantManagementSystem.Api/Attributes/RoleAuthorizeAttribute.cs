using Microsoft.AspNetCore.Mvc;
using RestaurantManagementSystem.Api.Attributes.Filters;
using RestaurantManagementSystem.Common.Enums;

namespace RestaurantManagementSystem.Api.Attributes
{
    /// <summary>
    /// RoleAuthorize Attribute
    /// </summary>
    public class RoleAuthorizeAttribute : TypeFilterAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoleAuthorizeAttribute"/> class
        /// </summary>
        /// <param name="roles">Roles</param>
        public RoleAuthorizeAttribute(params Roles[] roles) : base(typeof(AuthorizationRoleFilter))
        {
            Arguments = new object[] { roles };
        }
    }
}
