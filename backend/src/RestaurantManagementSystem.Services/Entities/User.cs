using RestaurantManagementSystem.Common.Enums;
using RestaurantManagementSystem.Services.Interfaces.Repositories;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RestaurantManagementSystem.Services.Entities
{
    /// <summary>
    /// User entity
    /// </summary>
    public class User : BaseEntity, IAggregateRoot
    {
        public User() { }

        public User(string username, string password, string name, string email)
        {
            Username = username;
            Password = password;
            Name = name;
            Email = email;
            Roles = new List<Roles>() { Common.Enums.Roles.User };
        }

        /// <summary>
        /// Username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [JsonIgnore]
        public string Password { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// E-mail
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Roles <see cref="Roles"/>
        /// </summary>
        public IEnumerable<Roles> Roles { get; set; }
    }
}
