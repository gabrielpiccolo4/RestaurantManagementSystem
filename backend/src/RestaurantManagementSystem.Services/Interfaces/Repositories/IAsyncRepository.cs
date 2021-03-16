using RestaurantManagementSystem.Services.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Services.Interfaces.Repositories
{
    public interface IAsyncRepository<TEntity> where TEntity : BaseEntity, IAggregateRoot
    {
        Task InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<List<TEntity>> AllAsync();
        Task<TEntity> FindAsync(string id);
    }
}
