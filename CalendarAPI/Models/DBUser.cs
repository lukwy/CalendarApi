using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CalendarAPI.Models
{
    [Serializable, BsonIgnoreExtraElements]
    public class DBUser : User
    {
        [BsonId, BsonElement("id"), BsonRepresentation(BsonType.Int32)]
        public int Id { get; set; }
    }
}
