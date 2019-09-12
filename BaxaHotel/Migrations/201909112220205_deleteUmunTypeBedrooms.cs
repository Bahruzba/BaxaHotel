namespace BaxaHotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteUmunTypeBedrooms : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rooms", "ChildBedroom", c => c.Int(nullable: false));
            DropColumn("dbo.Rooms", "ChildBedrim");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rooms", "ChildBedrim", c => c.Int(nullable: false));
            DropColumn("dbo.Rooms", "ChildBedroom");
        }
    }
}
