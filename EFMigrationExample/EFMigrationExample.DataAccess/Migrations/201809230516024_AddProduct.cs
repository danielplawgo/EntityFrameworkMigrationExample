using System.Data.Entity.Migrations;

namespace EFMigrationExample.DataAccess.Migrations
{
    public partial class AddProduct : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            Sql("INSERT INTO dbo.Products VALUES ('Product 1.1', 'Category 1');");
            Sql("INSERT INTO dbo.Products VALUES ('Product 1.2', 'Category 1');");
            Sql("INSERT INTO dbo.Products VALUES ('Product 1.3', 'Category 1');");
            Sql("INSERT INTO dbo.Products VALUES ('Product 2.1', 'Category 2');");
            Sql("INSERT INTO dbo.Products VALUES ('Product 2.2', 'Category 2');");
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
        }
    }
}
