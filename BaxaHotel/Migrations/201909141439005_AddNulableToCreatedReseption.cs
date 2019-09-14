namespace BaxaHotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNulableToCreatedReseption : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reservations", "Closed", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reservations", "Closed", c => c.DateTime(nullable: false));
        }
    }
}
