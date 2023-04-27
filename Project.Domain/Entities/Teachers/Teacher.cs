using Project.Domain.Commons;

namespace Project.Domain.Entities.Teachers
{
    public class Teacher : Auditable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Field { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
