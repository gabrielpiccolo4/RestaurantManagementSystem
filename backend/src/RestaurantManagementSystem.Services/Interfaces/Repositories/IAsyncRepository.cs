using MongoDB.Driver;
using RestaurantManagementSystem.Services.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Services.Interfaces.Repositories
{
    public interface IAsyncRepository<TEntity> where TEntity : BaseEntity, IAggregateRoot
    {
        Task InsertAsync(IClientSessionHandle session, TEntity entity);
        Task UpdateAsync(IClientSessionHandle session, TEntity entity);
        Task DeleteAsync(IClientSessionHandle session, TEntity entity);
        Task<List<TEntity>> AllAsync();
        Task<TEntity> FindAsync(string id);
    }
}
