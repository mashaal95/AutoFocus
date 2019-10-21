namespace AutoFocus_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class r : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Rents", "Rent_CustomerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rents", "Rent_CustomerId", c => c.String());
        }
    }
}
