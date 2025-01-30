using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace SBNHCRSWFAA.Models.DTOs{
        public class CreateHealthProfileDTO
    {
        [Required]
        public string UserId { get; set; } = null!;  // Links profile to a user

        [Required]
        [MinLength(1)]
        public string BloodType { get; set; } = null!;  

        public List<string> Allergies { get; set; } = new List<string>();  

        public List<string> ChronicConditions { get; set; } = new List<string>();  

        public List<string> Medications { get; set; } = new List<string>();  

        [Phone]
        public string EmergencyContact { get; set; }  // Emergency contact number
    }

    public class EditHealthProfileDTO
    {
        [Required]
        public string Id { get; set; }= null! ;// Profile ID

        [Required]
        public string BloodType { get; set; } = null! ;

        public List<string> Allergies { get; set; } = new List<string>();  

        public List<string> ChronicConditions { get; set; } = new List<string>();  

        public List<string> Medications { get; set; } = new List<string>();  

        [Phone]
        public string EmergencyContact { get; set; }  
    }

    public class GetHealthProfileDTO
    {
        public string Id { get; set; }  
        public string UserId { get; set; }  
        public string BloodType { get; set; }  
        public List<string> Allergies { get; set; }  
        public List<string> ChronicConditions { get; set; }  
        public List<string> Medications { get; set; }  
        public string EmergencyContact { get; set; }  
        public DateTime LastUpdated { get; set; }  
    }
}