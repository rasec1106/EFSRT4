using ApiUser.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiUser.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() {}
        public AppDbContext(DbContextOptions options) : base(options) {}
        public DbSet<User> Users { get; set; }
    }
}
