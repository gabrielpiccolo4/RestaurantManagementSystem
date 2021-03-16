using MongoDB.Driver;
using RestaurantManagementSystem.Services.Interfaces.Data;
using RestaurantManagementSystem.Services.Interfaces.Models;

namespace RestaurantManagementSystem.Infrastructure.Data
{
    public class MongoContext : IMongoContext
    {
        public MongoContext(IDatabaseSettings databaseSettings)
        {
            MongoClient = new MongoClient($"mongodb+srv://{databaseSettings.Login}:{databaseSettings.Password}@{databaseSettings.ClusterName}.bk3mm.mongodb.net/" +
                $"{databaseSettings.DatabaseName}?retryWrites=true&w=majority");

            Database = MongoClient.GetDatabase(databaseSettings.DatabaseName);
        }

        public MongoClient MongoClient { get; set; }

        public IMongoDatabase Database { get; set; }

        public IClientSessionHandle Session { get; set; }
    }
}
