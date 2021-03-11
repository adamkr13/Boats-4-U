namespace Boats_4_U.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DriverRating",
                c => new
                    {
                        DriverRatingId = c.Int(nullable: false, identity: true),
                        ApplicationUser = c.Guid(nullable: false),
                        DriverId = c.Int(nullable: false),
                        DriverFunScore = c.Double(nullable: false),
                        DriverSafetyScore = c.Double(nullable: false),
                        DriverCleanlinessScore = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.DriverRatingId)
                .ForeignKey("dbo.Driver", t => t.DriverId, cascadeDelete: true)
                .Index(t => t.DriverId);
            
            CreateTable(
                "dbo.Driver",
                c => new
                    {
                        DriverId = c.Int(nullable: false, identity: true),
                        DriverFirstName = c.String(nullable: false),
                        DriverLastName = c.String(nullable: false),
                        HourlyRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Location = c.String(nullable: false),
                        TypeOfBoat = c.Int(nullable: false),
                        DaysAvailable = c.Int(nullable: false),
                        MaximumOccupants = c.Int(nullable: false),
                        ApplicationUser = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.DriverId);
            
            CreateTable(
                "dbo.Reservation",
                c => new
                    {
                        ReservationId = c.Int(nullable: false, identity: true),
                        DriverId = c.Int(),
                        RenterId = c.Int(),
                        NumberOfPassengers = c.Int(nullable: false),
                        DateReservedFor = c.DateTimeOffset(nullable: false, precision: 7),
                        ReservationDuration = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateReservationMade = c.DateTimeOffset(nullable: false, precision: 7),
                        ApplicationUser = c.Guid(nullable: false),
                        UserCreatedReservation = c.String(),
                        ReservationDetails = c.String(),
                        ModifiedDate = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.ReservationId)
                .ForeignKey("dbo.Driver", t => t.DriverId)
                .ForeignKey("dbo.Renter", t => t.RenterId)
                .Index(t => t.DriverId)
                .Index(t => t.RenterId);
            
            CreateTable(
                "dbo.Renter",
                c => new
                    {
                        RenterId = c.Int(nullable: false, identity: true),
                        ApplicationUser = c.Guid(nullable: false),
                        RenterFirstName = c.String(nullable: false),
                        RenterLastName = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        CreditCardNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RenterId);
            
            CreateTable(
                "dbo.RenterRating",
                c => new
                    {
                        RenterRatingId = c.Int(nullable: false, identity: true),
                        ApplicationUser = c.Guid(nullable: false),
                        RenterId = c.Int(nullable: false),
                        RenterCleanlinessScore = c.Double(nullable: false),
                        RenterSafetyScore = c.Double(nullable: false),
                        RenterPunctualityScore = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.RenterRatingId)
                .ForeignKey("dbo.Renter", t => t.RenterId, cascadeDelete: true)
                .Index(t => t.RenterId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.DriverRating", "DriverId", "dbo.Driver");
            DropForeignKey("dbo.Reservation", "RenterId", "dbo.Renter");
            DropForeignKey("dbo.RenterRating", "RenterId", "dbo.Renter");
            DropForeignKey("dbo.Reservation", "DriverId", "dbo.Driver");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.RenterRating", new[] { "RenterId" });
            DropIndex("dbo.Reservation", new[] { "RenterId" });
            DropIndex("dbo.Reservation", new[] { "DriverId" });
            DropIndex("dbo.DriverRating", new[] { "DriverId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.RenterRating");
            DropTable("dbo.Renter");
            DropTable("dbo.Reservation");
            DropTable("dbo.Driver");
            DropTable("dbo.DriverRating");
        }
    }
}
