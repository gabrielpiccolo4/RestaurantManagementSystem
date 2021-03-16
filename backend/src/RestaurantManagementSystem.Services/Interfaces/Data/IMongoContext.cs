using MongoDB.Driver;

namespace RestaurantManagementSystem.Services.Interfaces.Data
{
    public interface IMongoContext
    {
        public MongoClient MongoClient { get; set; }

        public IMongoDatabase Database { get; set; }

        public IClientSessionHandle Session { get; set; }
    }
}
