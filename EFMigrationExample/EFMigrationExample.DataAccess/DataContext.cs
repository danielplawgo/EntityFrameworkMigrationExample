using System.Data.Entity;
using EFMigrationExample.Models;

namespace EFMigrationExample.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("Name=DefaultConnection")
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}