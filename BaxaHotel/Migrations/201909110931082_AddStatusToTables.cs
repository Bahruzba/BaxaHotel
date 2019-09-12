namespace BaxaHotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStatusToTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Status");
            DropColumn("dbo.Customers", "Status");
        }
    }
}
