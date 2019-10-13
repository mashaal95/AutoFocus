namespace AutoFocus_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedsomesmallerValidations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rents", "RatingDesc", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rents", "RatingDesc", c => c.String());
        }
    }
}
