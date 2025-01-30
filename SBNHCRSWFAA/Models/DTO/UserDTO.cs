using System.ComponentModel.DataAnnotations;
namespace SBNHCRSWFAA.Models.DTOs{

    public class CreateUser{
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password{ get; set; } = string.Empty;
        [RegularExpression("^(Male|Female)$", ErrorMessage = "Gender must be either 'Male' or 'Female'.")]
        public string Gender { get; set; } = string.Empty;

        [Range(19, 38, ErrorMessage = "Age must be greater than 18.")]
        public int Age { get; set; } = 18;
    }
    public class GetUser{
         public string Name { get; set; }
         public string PhoneNumber { get; set; }
         public string Gender { get; set; }
    }
}