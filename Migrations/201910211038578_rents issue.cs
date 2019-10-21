namespace AutoFocus_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rentsissue : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rents", "Rent_CustomerId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rents", "Rent_CustomerId");
        }
    }
}
