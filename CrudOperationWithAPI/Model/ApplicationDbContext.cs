using CrudOperationWithAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace CrudOperationWithAPI.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
                
        }
        public DbSet<Brand> Brands { get; set; }    
    }
}
