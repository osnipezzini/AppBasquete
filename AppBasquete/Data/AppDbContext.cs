using AppBasquete.Models;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;

namespace AppBasquete.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Item> Items { get; set; }
        public AppDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = DependencyService.Get<IDBPath>().GetDbPath();
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }
    }
}
