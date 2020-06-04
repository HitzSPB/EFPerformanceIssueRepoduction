using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PerfEFIssueFramework
{
    public class Item
    {
        public int Id { get; set; }
        public byte[] Data { get; set; }
    }

    public class ItemContext : DbContext
    {
        public DbSet<Item> Items { get; set; }

        public ItemContext() : base(@"Data Source=localhost;Initial Catalog=ItemDb;Integrated Security=False;User ID=sa;Password=USD")
        { }
    }

    internal class Program
    {
        private static async Task Main(string[] args)
        {
            Console.WriteLine("Ready to consume a lot of memory with EF.");

            //using (var db = new ItemContext())
            //{
            //    db.Database.CreateIfNotExists();

            //    //insert dummy record
            //    if (db.Items.ToArray().Length == 0)
            //    {
            //        db.Items.Add(new Item { Data = new byte[20 * 1024 * 1024] });
            //        await db.SaveChangesAsync();
            //    }
            //}
            // Find
            for (int i = 1; i < 6; i++)
            {
                // Find sync - No performance issues
                using (var db = new ItemContext())
                {
                    var stopwatch = Stopwatch.StartNew();
                    Console.WriteLine("Find sync method doesn't have performance and memory issue");
                    var item = db.Items.Find(i);
                    Console.WriteLine($"Record with id '{item.Id}' was fetched in {stopwatch.ElapsedMilliseconds}ms. Press any key to read again...");
                }

                // Find async - performance issues
                using (var db = new ItemContext())
                {
                    var stopwatch = Stopwatch.StartNew();
                    Console.WriteLine("Reproduce FindAsync performance and memory issue:");
                    var item = await db.Items.FindAsync(i);
                    Console.WriteLine($"Record with id '{item.Id}' was fetched in {stopwatch.ElapsedMilliseconds}ms. Press any key to read again...");
                }
            }

            using (var db = new ItemContext())
            {
                db.Database.Delete();
            }
        }
    }
}