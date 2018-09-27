using System.Data.Entity.Migrations;

namespace EFMigrationExample.DataAccess.Migrations
{
    public partial class AddCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "CategoryId", c => c.Int(nullable: false));

            Sql("INSERT INTO dbo.Categories SELECT DISTINCT Category FROM dbo.Products;");
            Sql("UPDATE p SET p.CategoryId = (SELECT c.Id FROM dbo.Categories c WHERE c.Name = p.Category) FROM dbo.Products p;");

            CreateIndex("dbo.Products", "CategoryId");
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            DropColumn("dbo.Products", "Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Category", c => c.String());

            Sql("UPDATE p SET p.Category = (SELECT c.Name FROM dbo.Categories c WHERE c.Id = p.CategoryId) FROM dbo.Products p;");

            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropColumn("dbo.Products", "CategoryId");
            DropTable("dbo.Categories");
        }
    }
}
