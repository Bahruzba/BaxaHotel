namespace BaxaHotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNulableToBedroomCount : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rooms", "PairPersonBedroom", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rooms", "PairPersonBedroom", c => c.Int(nullable: false));
        }
    }
}
