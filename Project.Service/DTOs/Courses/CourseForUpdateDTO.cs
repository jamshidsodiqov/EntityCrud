using Project.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Project.Service.DTOs.Courses
{
    public class CourseForUpdateDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public int Cost { get; set; }

        [Required]
        public CourseType CourseType { get; set; }

        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
