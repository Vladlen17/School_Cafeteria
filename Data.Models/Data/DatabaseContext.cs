using Data.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Models.Data
{
    public class DatabaseContext : DbContext
    {
        private readonly string _connectionString;
        public DbSet<User> Users { get; set; }

        public DatabaseContext(string connectionString)
        {
            _connectionString = connectionString;
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
