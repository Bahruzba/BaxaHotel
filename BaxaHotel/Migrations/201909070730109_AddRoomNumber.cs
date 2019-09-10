namespace BaxaHotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRoomNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rooms", "Number", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Users", "Token", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Token", c => c.String());
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false));
            DropColumn("dbo.Rooms", "Number");
        }
    }
}
