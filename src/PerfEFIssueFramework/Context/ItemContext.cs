using System.Data.Entity;

namespace PerfEFIssueFramework.Context
{
	public class ItemContext : DbContext
	{
		public DbSet<Item> Items { get; set; }

		public ItemContext() : base(@"Data Source=localhost;Initial Catalog=ItemDb;Integrated Security=true;")
		{ }
	}
}
