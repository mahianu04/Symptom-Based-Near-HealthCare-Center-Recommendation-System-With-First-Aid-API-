using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace SBNHCRSWFAA.Models{
    public class HealthProfile
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public  ObjectId Id { get; set; }  
        [BsonElement("userId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; }  
        [BsonElement("bloodType")]
        public string BloodType { get; set; }  
        [BsonElement("allergies")]
        public List<string> Allergies { get; set; }  
        [BsonElement("chronicConditions")]
        public List<string> ChronicConditions { get; set; }  
        [BsonElement("medications")]
        public List<string> Medications { get; set; }  
        [BsonElement("emergencyContact")]
        public string EmergencyContact { get; set; } 

        [BsonElement("lastUpdated")]
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow; 
    }
}