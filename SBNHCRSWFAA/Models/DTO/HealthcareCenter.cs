using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace SBNHCRSWFAA.Models.DTOs{
    public class CreateHealthcareCenterDTO
    {
        [Required]
        [MinLength(3, ErrorMessage = "Healthcare center name must be at least 3 characters long.")]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required(ErrorMessage = "Latitude is required.")]
        [Range(-90, 90, ErrorMessage = "Latitude must be between -90 and 90.")]
        public double Latitude { get; set; }

        [Required(ErrorMessage = "Longitude is required.")]
        [Range(-180, 180, ErrorMessage = "Longitude must be between -180 and 180.")]
        public double Longitude { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "At least one specialty must be provided.")]
        public List<string> Specialties { get; set; }

        [Required]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string ContactNumber { get; set; }
    }

    public class GetHealthcareCenterDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public List<string> Specialties { get; set; }
        public string ContactNumber { get; set; }
        public double Rating { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}