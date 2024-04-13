using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace MVCCoreApiMovie.Models
{
    [BsonIgnoreExtraElements]
    public class Movie
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("title")]
        public string Title { get; set; } = null!;

        [BsonElement("year")]
        public int Year { get; set; }

        [BsonElement("rated")]
        public string Rated { get; set; } = null!;

        [BsonElement("genres")]
        [BsonRepresentation(BsonType.Array)]
        [BsonIgnoreIfNull]
        public List<BsonValue> Genres { get; set; } = null!;

        [BsonElement("director")]
        public string Director { get; set; } = null!;






    }
}
