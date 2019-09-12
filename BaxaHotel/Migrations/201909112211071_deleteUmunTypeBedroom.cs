namespace BaxaHotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteUmunTypeBedroom : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rooms", "SinglePersonBedroom", c => c.Int(nullable: false));
            AddColumn("dbo.Rooms", "PairPersonBedroom", c => c.Int(nullable: false));
            AddColumn("dbo.Rooms", "ChildBedrim", c => c.Int(nullable: false));
            DropColumn("dbo.Rooms", "PersonCapacity");
            DropColumn("dbo.Rooms", "ChildCapacity");
            DropColumn("dbo.Rooms", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rooms", "Type", c => c.Int(nullable: false));
            AddColumn("dbo.Rooms", "ChildCapacity", c => c.Int(nullable: false));
            AddColumn("dbo.Rooms", "PersonCapacity", c => c.Int(nullable: false));
            DropColumn("dbo.Rooms", "ChildBedrim");
            DropColumn("dbo.Rooms", "PairPersonBedroom");
            DropColumn("dbo.Rooms", "SinglePersonBedroom");
        }
    }
}
