using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace api_mongo.Models
{
    public class Game
    {
        // indicates that is a mongo id
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("gameId")] // set db name
        public string? Id { get; set; }

        [BsonElement("title")] // set db name
        public string Title { get; set; }

        [BsonElement("developers")] // set db name
        public List<string> Developers { get; set; }

        [BsonElement("release")] // set db name
        public string Release { get; set; }

        [BsonElement("genres")] // set db name
        public List<string> Genres { get; set; }

    }
}
