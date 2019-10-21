namespace AutoFocus_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refreshingthemodel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rents", "Customer_CustomerId1", "dbo.Customers");
            DropIndex("dbo.Rents", new[] { "Customer_CustomerId" });
            DropIndex("dbo.Rents", new[] { "Customer_CustomerId1" });
            DropColumn("dbo.Rents", "CustomerId");
            RenameColumn(table: "dbo.Rents", name: "Customer_CustomerId", newName: "CustomerId");
            AlterColumn("dbo.Rents", "CustomerId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Rents", "CustomerId");
            DropColumn("dbo.Rents", "Customer_CustomerId1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rents", "Customer_CustomerId1", c => c.String(maxLength: 128));
            DropIndex("dbo.Rents", new[] { "CustomerId" });
            AlterColumn("dbo.Rents", "CustomerId", c => c.String());
            RenameColumn(table: "dbo.Rents", name: "CustomerId", newName: "Customer_CustomerId");
            AddColumn("dbo.Rents", "CustomerId", c => c.String());
            CreateIndex("dbo.Rents", "Customer_CustomerId1");
            CreateIndex("dbo.Rents", "Customer_CustomerId");
            AddForeignKey("dbo.Rents", "Customer_CustomerId1", "dbo.Customers", "CustomerId", cascadeDelete: true);
        }
    }
}
