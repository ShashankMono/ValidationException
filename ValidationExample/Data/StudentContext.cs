using Microsoft.EntityFrameworkCore;
using ValidationExample.Models;

namespace ValidationExample.Data
{
    public class StudentContext:DbContext
    {
        public DbSet<Student> Students { get; set; }
        public StudentContext(DbContextOptions option):base(option)
        {
            
        }
    }
}
