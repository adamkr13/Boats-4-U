namespace Boats_4_U.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserNameFix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DriverRating", "UserCreatedDriverRating", c => c.String());
            AddColumn("dbo.Driver", "UserCreatedDriver", c => c.String());
            AddColumn("dbo.Renter", "UserCreatedRenter", c => c.String());
            AddColumn("dbo.RenterRating", "UserCreatedRenterRating", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RenterRating", "UserCreatedRenterRating");
            DropColumn("dbo.Renter", "UserCreatedRenter");
            DropColumn("dbo.Driver", "UserCreatedDriver");
            DropColumn("dbo.DriverRating", "UserCreatedDriverRating");
        }
    }
}
