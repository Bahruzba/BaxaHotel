namespace BaxaHotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCreateReservation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reservations", "Create", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reservations", "Create", c => c.DateTime(nullable: false));
        }
    }
}
