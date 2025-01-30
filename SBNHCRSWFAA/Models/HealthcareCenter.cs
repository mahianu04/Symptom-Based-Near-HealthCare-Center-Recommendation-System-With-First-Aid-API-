using MongoDB.Bson;
using MongoDB.Driver.GeoJsonObjectModel;
using MongoDB.Bson.Serialization.Attributes;
namespace SBNHCRSWFAA.Models
{
    public class HealthcareCenter
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }  // Unique identifier for MongoDB

        [BsonElement("name")]
        public string Name { get; set; }  // Name of the healthcare center

        [BsonElement("address")]
        public string Address { get; set; }  // Full address of the center

        [BsonElement("location")]
        public GeoJsonPoint<GeoJson2DCoordinates> Location { get; set; }  // Geospatial coordinates

        [BsonElement("specialties")]
        public List<string> Specialties { get; set; }  // List of medical services offered

        [BsonElement("rating")]
        public double Rating { get; set; } = 0.0;  // Average rating based on user reviews

        [BsonElement("contactNumber")]
        public string ContactNumber { get; set; }  // Phone number of the center

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;  
    }
}