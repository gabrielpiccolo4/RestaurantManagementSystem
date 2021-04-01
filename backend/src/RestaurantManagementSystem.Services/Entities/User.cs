using RestaurantManagementSystem.Common.Enums;
using RestaurantManagementSystem.Services.Interfaces.Repositories;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RestaurantManagementSystem.Services.Entities
{
    /// <summary>
    /// User entity
    /// </summary>
    public class User : BaseEntity, IAggregateRoot
    {
        public User() { }

        public User(string email, string name, string password)
        {
            Email = email;
            Name = name;
            Password = password;
            Roles = new List<Roles>() { Common.Enums.Roles.User };
        }

        /// <summary>
        /// E-mail
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [JsonIgnore]
        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        /// <summary>
        /// Roles <see cref="Roles"/>
        /// </summary>
        public IEnumerable<Roles> Roles { get; set; }
    }
}
