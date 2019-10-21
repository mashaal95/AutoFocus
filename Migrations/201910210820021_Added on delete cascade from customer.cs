namespace AutoFocus_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedondeletecascadefromcustomer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rents", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Rents", new[] { "CustomerId" });
            AddColumn("dbo.Rents", "Customer_CustomerId", c => c.String(maxLength: 128));
            AddColumn("dbo.Rents", "Customer_CustomerId1", c => c.String(maxLength: 128));
            AlterColumn("dbo.Rents", "CustomerId", c => c.String());
            CreateIndex("dbo.Rents", "Customer_CustomerId");
            CreateIndex("dbo.Rents", "Customer_CustomerId1");
            AddForeignKey("dbo.Rents", "Customer_CustomerId1", "dbo.Customers", "CustomerId", cascadeDelete: true);
            AddForeignKey("dbo.Rents", "Customer_CustomerId", "dbo.Customers", "CustomerId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rents", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Rents", "Customer_CustomerId1", "dbo.Customers");
            DropIndex("dbo.Rents", new[] { "Customer_CustomerId1" });
            DropIndex("dbo.Rents", new[] { "Customer_CustomerId" });
            AlterColumn("dbo.Rents", "CustomerId", c => c.String(maxLength: 128));
            DropColumn("dbo.Rents", "Customer_CustomerId1");
            DropColumn("dbo.Rents", "Customer_CustomerId");
            CreateIndex("dbo.Rents", "CustomerId");
            AddForeignKey("dbo.Rents", "CustomerId", "dbo.Customers", "CustomerId");
        }
    }
}
