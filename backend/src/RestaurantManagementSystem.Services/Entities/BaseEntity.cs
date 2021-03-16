using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RestaurantManagementSystem.Services.Entities
{
    /// <summary>
    /// Abstract class for the Entities
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Entity ID
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; protected set; }
    }
}
