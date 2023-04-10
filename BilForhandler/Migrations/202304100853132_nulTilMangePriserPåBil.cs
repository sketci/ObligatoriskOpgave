namespace BilForhandler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nulTilMangePriserPåBil : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pris", "BilId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Pris", "BilId");
            AddForeignKey("dbo.Pris", "BilId", "dbo.Bil", "BilId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pris", "BilId", "dbo.Bil");
            DropIndex("dbo.Pris", new[] { "BilId" });
            DropColumn("dbo.Pris", "BilId");
        }
    }
}
