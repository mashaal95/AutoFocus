namespace AutoFocus_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectedRentsClass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rents", "Rents_RentId", "dbo.Rents");
            DropIndex("dbo.Rents", new[] { "Rents_RentId" });
            DropColumn("dbo.Rents", "Rents_RentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rents", "Rents_RentId", c => c.Int());
            CreateIndex("dbo.Rents", "Rents_RentId");
            AddForeignKey("dbo.Rents", "Rents_RentId", "dbo.Rents", "RentId");
        }
    }
}
