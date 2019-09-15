namespace BaxaHotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFileUploadToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Photo", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Photo");
        }
    }
}
