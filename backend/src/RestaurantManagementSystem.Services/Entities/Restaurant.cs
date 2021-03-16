using RestaurantManagementSystem.Services.Interfaces.Repositories;
using System.ComponentModel.DataAnnotations;

namespace RestaurantManagementSystem.Services.Entities
{
    /// <summary>
    /// Restaurant entity
    /// </summary>
    public class Restaurant : BaseEntity, IAggregateRoot
    {
        /// <summary>
        /// Company name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Rating
        /// </summary>
        [Range(0, 5)]
        public double Rating { get; set; }
    }
}
