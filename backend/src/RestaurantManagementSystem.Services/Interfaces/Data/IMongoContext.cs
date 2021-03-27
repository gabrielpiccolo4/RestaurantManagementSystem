using MongoDB.Driver;

namespace RestaurantManagementSystem.Services.Interfaces.Data
{
    public interface IMongoContext
    {
        public MongoClient MongoClient { get; }

        public IMongoDatabase Database { get; }

        public IClientSessionHandle Session { get; }
    }
}
