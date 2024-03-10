using BookCollection.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BookCollection.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Ratings> Ratings { get; set; }


    }
}
