namespace AutoFocus_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedValidationstoModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Branches", "BrName", c => c.String(nullable: false));
            AlterColumn("dbo.Branches", "BrDesc", c => c.String(nullable: false));
            AlterColumn("dbo.Branches", "BrAddress", c => c.String(nullable: false));
            AlterColumn("dbo.Branches", "BrSuburb", c => c.String(nullable: false));
            AlterColumn("dbo.Branches", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Cars", "CarName", c => c.String(nullable: false));
            AlterColumn("dbo.Cars", "CarDesc", c => c.String(nullable: false));
            AlterColumn("dbo.Cars", "Transmission", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Surname", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Surname", c => c.String());
            AlterColumn("dbo.Customers", "Name", c => c.String());
            AlterColumn("dbo.Cars", "Transmission", c => c.String());
            AlterColumn("dbo.Cars", "CarDesc", c => c.String());
            AlterColumn("dbo.Cars", "CarName", c => c.String());
            AlterColumn("dbo.Branches", "City", c => c.String());
            AlterColumn("dbo.Branches", "BrSuburb", c => c.String());
            AlterColumn("dbo.Branches", "BrAddress", c => c.String());
            AlterColumn("dbo.Branches", "BrDesc", c => c.String());
            AlterColumn("dbo.Branches", "BrName", c => c.String());
        }
    }
}
