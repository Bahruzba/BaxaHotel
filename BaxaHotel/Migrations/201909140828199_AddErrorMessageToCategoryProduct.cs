namespace BaxaHotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddErrorMessageToCategoryProduct : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Price = c.Double(nullable: false),
                        Count = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        CategryProductId = c.Int(nullable: false),
                        CategoryProduct_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategoryProducts", t => t.CategoryProduct_Id, cascadeDelete: true)
                .Index(t => t.CategoryProduct_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CategoryProduct_Id", "dbo.CategoryProducts");
            DropIndex("dbo.Products", new[] { "CategoryProduct_Id" });
            DropTable("dbo.Products");
            DropTable("dbo.CategoryProducts");
        }
    }
}
