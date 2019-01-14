using Microsoft.EntityFrameworkCore;
using System.IO;
using Xamarin.Essentials;

namespace Tp1.Models
{
    public class KaamDBContext : DbContext
    {
        public DbSet<Sound> SoundTable { get; set; }

        public KaamDBContext()
        {
            Database.Migrate();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "Kaam.db3");
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }
    }
}
