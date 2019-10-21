namespace AutoFocus_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class r4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rents", "Customer_CustomerId", "dbo.Customers");
            DropIndex("dbo.Rents", new[] { "Customer_CustomerId" });
            DropColumn("dbo.Rents", "CustomerIdFK");
            RenameColumn(table: "dbo.Rents", name: "CustomerId", newName: "CustomerIdFK");
            AlterColumn("dbo.Rents", "CustomerIdFK", c => c.String(nullable: true, maxLength: 128));
            AlterColumn("dbo.Rents", "CustomerIdFK", c => c.String(nullable: true, maxLength: 128));
            CreateIndex("dbo.Rents", "CustomerIdFK");
            AddForeignKey("dbo.Rents", "CustomerIdFK", "dbo.Customers", "CustomerId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rents", "CustomerIdFK", "dbo.Customers");
            DropIndex("dbo.Rents", new[] { "CustomerIdFK" });
            AlterColumn("dbo.Rents", "CustomerIdFK", c => c.String(maxLength: 128));
            AlterColumn("dbo.Rents", "CustomerIdFK", c => c.String());
            RenameColumn(table: "dbo.Rents", name: "CustomerIdFK", newName: "Customer_CustomerId");
            AddColumn("dbo.Rents", "CustomerIdFK", c => c.String());
            CreateIndex("dbo.Rents", "Customer_CustomerId");
            AddForeignKey("dbo.Rents", "Customer_CustomerId", "dbo.Customers", "CustomerId");
        }
    }
}
