using Microsoft.EntityFrameworkCore;

namespace Entity_framework.Models
{
    public class StudentDbContext:DbContext
    {
        public StudentDbContext(DbContextOptions options):base(options)
        {
            
        }

        // The below line set the name of the table as Students 
        public DbSet<Student> Students_Details { get; set; }
    }
}
