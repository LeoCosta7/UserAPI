using Microsoft.EntityFrameworkCore;
using UserAPI.Entity;

namespace UserAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }  
    }
}
