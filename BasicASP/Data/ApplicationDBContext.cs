using BasicASP.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicASP.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) :base(options){
        
        }
        public DbSet<Student> Students { get; set; }
    }
}
