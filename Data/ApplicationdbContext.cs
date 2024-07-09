using GlobalSearchInAspNetCoreMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace GlobalSearchInAspNetCoreMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }

}
