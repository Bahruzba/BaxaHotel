namespace BaxaHotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClosedTimeReservation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "Closed", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservations", "Closed");
        }
    }
}
