namespace ViBANManager.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addApiBaseUrlColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BankConfigurations", "ApiBaseUrl", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BankConfigurations", "ApiBaseUrl");
        }
    }
}
