using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.GeoJsonObjectModel;

namespace SBNHCRSWFAA.Models
{
    public class Users {  
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; } 
        
        [BsonElement("name")]
        public string Name {get;set;} = string.Empty;


        [BsonElement("phoneNumber")]
        public string PhoneNumber { get; set; }= string.Empty;
 
        [BsonElement("password")]
        public string Password { get; set; } = string.Empty;
 

        [BsonElement("email")]
        public string Email { get; set; } = string.Empty;

        [BsonElement("gender")]
        public string Gender {get; set;} = string.Empty;

       // [BsonElement("age")]
       

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;  // Account creation timestamp
    }
}