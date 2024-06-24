using Microsoft.EntityFrameworkCore;
using StudentPortal.Models;

namespace StudentPortal.Data
{
    public class StdentPortalDbContext : DbContext
    {
        public StdentPortalDbContext(DbContextOptions<StdentPortalDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
