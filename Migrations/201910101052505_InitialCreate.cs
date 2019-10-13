namespace AutoFocus_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        BranchId = c.Int(nullable: false, identity: true),
                        BrName = c.String(),
                        BrDesc = c.String(),
                        BrAddress = c.String(),
                        BrSuburb = c.String(),
                        City = c.String(),
                        ZipCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BranchId);
            
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        CarId = c.Int(nullable: false, identity: true),
                        BranchId = c.Int(nullable: false),
                        CarName = c.String(),
                        CarDesc = c.String(),
                        PricePerDay = c.Int(nullable: false),
                        NoOfSeats = c.Int(nullable: false),
                        Transmission = c.String(),
                    })
                .PrimaryKey(t => t.CarId)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.Rents",
                c => new
                    {
                        RentId = c.Int(nullable: false, identity: true),
                        CustomerId = c.String(maxLength: 128),
                        CarId = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                        RatingDesc = c.String(),
                        DateOfBooking = c.DateTime(nullable: false),
                        EndOfBooking = c.DateTime(nullable: false),
                        TotalRate = c.Double(nullable: false),
                        Rents_RentId = c.Int(),
                    })
                .PrimaryKey(t => t.RentId)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.Rents", t => t.Rents_RentId)
                .ForeignKey("dbo.Cars", t => t.CarId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.CarId)
                .Index(t => t.Rents_RentId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Surname = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        RegistrationDate = c.DateTime(nullable: false),
                        PhoneNum = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rents", "CarId", "dbo.Cars");
            DropForeignKey("dbo.Rents", "Rents_RentId", "dbo.Rents");
            DropForeignKey("dbo.Rents", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Cars", "BranchId", "dbo.Branches");
            DropIndex("dbo.Rents", new[] { "Rents_RentId" });
            DropIndex("dbo.Rents", new[] { "CarId" });
            DropIndex("dbo.Rents", new[] { "CustomerId" });
            DropIndex("dbo.Cars", new[] { "BranchId" });
            DropTable("dbo.Customers");
            DropTable("dbo.Rents");
            DropTable("dbo.Cars");
            DropTable("dbo.Branches");
        }
    }
}
