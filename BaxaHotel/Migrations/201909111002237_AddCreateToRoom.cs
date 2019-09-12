namespace BaxaHotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreateToRoom : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Rooms", "Created", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Reservations", "UserId");
            AddForeignKey("dbo.Reservations", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "UserId", "dbo.Users");
            DropIndex("dbo.Reservations", new[] { "UserId" });
            DropColumn("dbo.Rooms", "Created");
            DropColumn("dbo.Reservations", "UserId");
        }
    }
}
