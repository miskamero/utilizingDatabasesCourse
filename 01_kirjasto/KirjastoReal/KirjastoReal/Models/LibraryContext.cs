using KirjastoReal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
namespace KirjastoReal.Models
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Loan> Loans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\MSSQLLocalDB;" +
                "Database=KirjastoRealDB;" +
                "Trusted_Connection=True;"
            );
        }
    }
}