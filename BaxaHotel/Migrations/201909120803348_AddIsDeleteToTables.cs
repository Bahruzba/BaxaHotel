namespace BaxaHotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsDeleteToTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsDelete", c => c.Boolean());
            AddColumn("dbo.Users", "IsDelete", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "IsDelete");
            DropColumn("dbo.Customers", "IsDelete");
        }
    }
}
