namespace BaxaHotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveNulableFromCreatedReservation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "Created", c => c.DateTime(nullable: false));
            DropColumn("dbo.Reservations", "Create");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservations", "Create", c => c.DateTime());
            DropColumn("dbo.Reservations", "Created");
        }
    }
}
