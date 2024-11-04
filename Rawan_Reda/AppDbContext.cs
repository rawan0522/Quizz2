using Microsoft.EntityFrameworkCore;
using Rawan_Reda.Models;

namespace Rawan_Reda
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Auther> Authers { get; set; }
        public DbSet<Gener> Geners { get; set; }
    }
}
