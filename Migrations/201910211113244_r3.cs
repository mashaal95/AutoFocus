namespace AutoFocus_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class r3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rents", "CustomerIdFK", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rents", "CustomerIdFK");
        }
    }
}
