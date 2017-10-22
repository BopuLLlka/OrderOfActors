namespace OrderOfStars.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPriceAndTimeToStars : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stars", "Time", c => c.String());
            AddColumn("dbo.Stars", "Price", c => c.Int());
        }

        public override void Down()
        {
            DropColumn("dbo.Stars", "Time");
            DropColumn("dbo.Stars", "Price");
        }
    }
}
