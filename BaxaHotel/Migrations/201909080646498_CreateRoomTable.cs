namespace BaxaHotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateRoomTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rooms", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Rooms", "PersonCapacity", c => c.Int(nullable: false));
            AddColumn("dbo.Rooms", "ChildCapacity", c => c.Int(nullable: false));
            AddColumn("dbo.Rooms", "Type", c => c.Int(nullable: false));
            AddColumn("dbo.Rooms", "Desc", c => c.String(nullable: false, maxLength: 300));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rooms", "Desc");
            DropColumn("dbo.Rooms", "Type");
            DropColumn("dbo.Rooms", "ChildCapacity");
            DropColumn("dbo.Rooms", "PersonCapacity");
            DropColumn("dbo.Rooms", "Status");
        }
    }
}
