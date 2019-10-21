namespace AutoFocus_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Branches", "BrLatitude", c => c.Double(nullable: false));
            AddColumn("dbo.Branches", "BrLongitude", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Branches", "BrLongitude");
            DropColumn("dbo.Branches", "BrLatitude");
        }
    }
}
