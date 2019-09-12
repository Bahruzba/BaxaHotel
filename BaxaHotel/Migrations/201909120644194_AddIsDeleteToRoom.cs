namespace BaxaHotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsDeleteToRoom : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rooms", "IsDelete", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Rooms", "SinglePersonBedroom", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rooms", "SinglePersonBedroom", c => c.Int(nullable: false));
            DropColumn("dbo.Rooms", "IsDelete");
        }
    }
}
