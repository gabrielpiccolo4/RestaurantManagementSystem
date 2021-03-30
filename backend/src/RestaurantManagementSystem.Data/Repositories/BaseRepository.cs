using MongoDB.Driver;
using RestaurantManagementSystem.Services.Entities;
using RestaurantManagementSystem.Services.Interfaces.Data;
using RestaurantManagementSystem.Services.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.Infrastructure.Repositories
{
    public abstract class BaseRepository<TEntity> : IAsyncRepository<TEntity> where TEntity : BaseEntity, IAggregateRoot
    {
        protected readonly IMongoContext Context;
        protected readonly IMongoCollection<TEntity> Collection;

        public BaseRepository(IMongoContext context)
        {
            Context = context;
            Collection = Context.Database.GetCollection<TEntity>($"{typeof(TEntity).Name}s");
        }

        public virtual async Task InsertAsync(TEntity entity)
        {
            // WIP - Session & Transaction should not be here!
            using (var session = await Context.MongoClient.StartSessionAsync())
            {
                session.StartTransaction();
                await Collection.InsertOneAsync(session, entity);
                await session.CommitTransactionAsync();
            }
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            FilterDefinition<TEntity> filter = FilterEntityByID(entity);

            if (entity != null)
                await Collection.ReplaceOneAsync(Context.Session, filter, entity);
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            FilterDefinition<TEntity> filter = FilterEntityByID(entity);

            if (entity != null)
                await Collection.DeleteOneAsync(Context.Session, filter);
        }

        public virtual async Task<List<TEntity>> AllAsync() {
            var find = await Collection.FindAsync(entity => true);
            return find.ToList();
        }

        public virtual async Task<TEntity> FindAsync(string id)
        {
            var find = await Collection.FindAsync(entity => entity.Id == id);
            return find.FirstOrDefault();
        }

        protected FilterDefinition<TEntity> FilterEntityByID(TEntity entity)
        {
            Expression<Func<TEntity, string>> func = e => e.Id;
            var value = (string)entity.GetType().GetProperty(func.Body.ToString().Split(".")[1]).GetValue(entity, null);
            return Builders<TEntity>.Filter.Eq(func, value);
        }
    }
}
