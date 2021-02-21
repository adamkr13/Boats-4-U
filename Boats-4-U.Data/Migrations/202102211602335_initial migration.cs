namespace Boats_4_U.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Renter", "CreditCardNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Renter", "CreditCardNumber", c => c.Long(nullable: false));
        }
    }
}
