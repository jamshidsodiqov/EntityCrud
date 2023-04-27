using Project.Domain.Commons;
using Project.Domain.Entities.Courses;

namespace Project.Domain.Entities.Students
{
    public class Student : Auditable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
