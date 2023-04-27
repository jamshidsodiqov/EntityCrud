using System.ComponentModel.DataAnnotations;

namespace Project.Service.DTOs.Students
{
    public class StudentForCreationDTO
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public int CourseId { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
