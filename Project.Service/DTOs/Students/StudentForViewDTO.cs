using Project.Domain.Entities.Courses;
using System.ComponentModel.DataAnnotations;

namespace Project.Service.DTOs.Students
{
    public class StudentForViewDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public int CourseId { get; set; }
    }
}
