using System.ComponentModel.DataAnnotations;

namespace Project.Service.DTOs.Teachers
{
    public class TeacherForViewDTO
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Field { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }
    }
}
