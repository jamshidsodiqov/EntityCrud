using Project.Domain.Commons;
using Project.Domain.Entities.Students;
using Project.Domain.Enums;

namespace Project.Domain.Entities.Courses
{
    public class Course : Auditable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public int Cost { get; set; }
        public CourseType CourseType { get; set; }
        public virtual ICollection<Student> Students { get; set; } // include qilsak Course ga tegishli studentlarni olib keladi
    }
}
