using Microsoft.EntityFrameworkCore;
using Net_Core_10_Domain.Data;

namespace Net_Core_10_Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
    }
}
