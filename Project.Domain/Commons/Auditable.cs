namespace Project.Domain.Commons
{
    public class Auditable
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
