namespace BaxaHotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSVnumToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "SVnum", c => c.String(nullable: false, maxLength: 8));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "SVnum");
        }
    }
}
