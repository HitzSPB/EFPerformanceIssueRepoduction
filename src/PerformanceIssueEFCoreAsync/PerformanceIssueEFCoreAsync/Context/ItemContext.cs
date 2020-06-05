using Microsoft.EntityFrameworkCore;

namespace PerformanceIssueEFCoreAsync.Context
{
  public class ItemContext : DbContext
  {
    public DbSet<Item> Items { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(
@"Data Source=localhost;Initial Catalog=ItemDb;Integrated Security=true;");
    }
  }

}
