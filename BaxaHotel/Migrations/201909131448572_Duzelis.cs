namespace BaxaHotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Duzelis : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Rooms", "Desc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rooms", "Desc", c => c.String(nullable: false, maxLength: 300));
        }
    }
}
