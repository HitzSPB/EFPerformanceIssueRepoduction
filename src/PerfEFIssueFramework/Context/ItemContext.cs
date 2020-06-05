using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfEFIssueFramework.Context
{
	public class ItemContext : DbContext
	{
		public DbSet<Item> Items { get; set; }

		public ItemContext() : base(@"Data Source=localhost;Initial Catalog=ItemDb;Integrated Security=true;")
		{ }
	}
}
