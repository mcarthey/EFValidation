using Microsoft.EntityFrameworkCore;

namespace EFValidation;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=EFTutorial;Trusted_Connection=True;");
    }
}
