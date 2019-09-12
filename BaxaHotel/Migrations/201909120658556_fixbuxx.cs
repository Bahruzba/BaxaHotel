namespace BaxaHotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixbuxx : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rooms", "IsDelete", c => c.Boolean());
            AlterColumn("dbo.Rooms", "SinglePersonBedroom", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rooms", "SinglePersonBedroom", c => c.Int());
            AlterColumn("dbo.Rooms", "IsDelete", c => c.Boolean(nullable: false));
        }
    }
}
