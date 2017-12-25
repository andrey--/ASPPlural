using Microsoft.EntityFrameworkCore;
using Start.Models;

namespace Start.Data
{
    public class OdeToFoodDbContext : DbContext
    {
        public OdeToFoodDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
