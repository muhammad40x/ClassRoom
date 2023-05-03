using System.ComponentModel.DataAnnotations;

namespace _3lessonproject.Models
{
    public class CreateUserDto
    {
        [StringLength(50, MinimumLength = 3)]
        public string FirstName { get; set; }
        public string? LastName { get; set; }

        [RegularExpression("^[0-9]{9}$",ErrorMessage ="Phone number is not valid !!")]
        public string PhoneNumber { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string UserName { get; set; }

        [StringLength(50,MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        public IFormFile Photo { get; set; }

    }
}
