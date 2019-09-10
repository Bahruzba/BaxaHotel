namespace BaxaHotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NotNulable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Created", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Created", c => c.DateTime());
        }
    }
}
