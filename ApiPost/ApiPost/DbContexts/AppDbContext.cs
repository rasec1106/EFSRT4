using ApiPost.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPost.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Post> Posts { get; set; }

    }
}
