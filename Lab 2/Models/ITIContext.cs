using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Lab_2.Models
{
    public class ITIContext:DbContext
    {
        public ITIContext() { }
        public DbSet<Department> Department { get; set; }
        public DbSet<Instructor> Instructor { get; set; }
        public DbSet<Trainee> Trainee { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<crsResult> CourseResult { get; set; }


        //inject ask ioc container 
        public ITIContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=DBITIMVC;Trusted_Connection=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
