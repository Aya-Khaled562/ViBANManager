namespace ViBANManager.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankConfigurations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        BankName = c.String(nullable: false),
                        ApiKey = c.String(nullable: false),
                        ApiSecret = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BankConfigurations");
        }
    }
}
