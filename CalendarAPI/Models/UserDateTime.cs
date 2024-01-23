using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CalendarAPI.Models
{
    [Serializable, BsonIgnoreExtraElements]
    public class UserDateTime
    {
        [BsonElement("user_id"), BsonRepresentation(BsonType.Int32)]
        public int UserId { get; set; }
        [BsonElement("date"), BsonRepresentation(BsonType.DateTime)]
        public DateTime Date { get; set; }
        [BsonElement("hour_from"), BsonRepresentation(BsonType.DateTime)]
        public DateTime HourFrom { get; set; }
        [BsonElement("hour_to"), BsonRepresentation(BsonType.DateTime)]
        public DateTime HourTo { get; set; }
    }
}
