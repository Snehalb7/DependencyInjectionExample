using DependencyInjectionExample.Model;
using Microsoft.EntityFrameworkCore;
namespace DependencyInjectionExample.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
