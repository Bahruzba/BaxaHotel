namespace BaxaHotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAuto : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "Photo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Photo", c => c.String(maxLength: 100));
        }
    }
}
