namespace Students_Management.Models
{
    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Head { get; set; }
        public string? Title { get; set; }
        public ICollection<User>? Users { get; set; } = new List<User>();
    }
}
