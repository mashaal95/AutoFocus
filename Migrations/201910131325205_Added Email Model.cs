namespace AutoFocus_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEmailModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Suggestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.String(nullable: false, maxLength: 128),
                        FromName = c.String(nullable: false),
                        FromEmail = c.String(nullable: false),
                        EmailMessage = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Suggestions", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Suggestions", new[] { "CustomerId" });
            DropTable("dbo.Suggestions");
        }
    }
}
