using ApiStudy.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiStudy.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; } = default!;
    }
}
