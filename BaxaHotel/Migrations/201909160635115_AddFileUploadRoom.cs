namespace BaxaHotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFileUploadRoom : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rooms", "Photo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rooms", "Photo");
        }
    }
}
