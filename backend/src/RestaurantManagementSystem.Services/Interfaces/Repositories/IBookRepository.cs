using RestaurantManagementSystem.Services.Entities;

namespace RestaurantManagementSystem.Services.Interfaces.Repositories
{
    /// <summary>
    /// Interface for the Restaurant Repository
    /// </summary>
    public interface IRestaurantRepository : IAsyncRepository<Restaurant>
    {
    }
}
