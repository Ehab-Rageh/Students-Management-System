using Microsoft.EntityFrameworkCore;

namespace Students_Management.Models
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Student_Course> Student_Courses { get; set; }
        public DbSet<Department_Instructor> Department_Instructors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            var constr = config.GetSection("constr").Value;

            optionsBuilder.UseSqlServer(constr);
        }
    }
}
