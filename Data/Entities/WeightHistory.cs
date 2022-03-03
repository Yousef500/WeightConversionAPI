using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WeightConversion.Data.Entities
{
    [BsonIgnoreExtraElements]
    public class WeightHistory
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public double WeightinKgs { get; set; }
        public double WeightinPounds { get; set; }
        public double WeightinOunces { get; set; }
    }
}