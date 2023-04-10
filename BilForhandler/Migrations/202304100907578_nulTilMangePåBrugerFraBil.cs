namespace BilForhandler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nulTilMangePåBrugerFraBil : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bil", "BrugerId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Bil", "BrugerId");
            AddForeignKey("dbo.Bil", "BrugerId", "dbo.Bruger", "BrugerId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bil", "BrugerId", "dbo.Bruger");
            DropIndex("dbo.Bil", new[] { "BrugerId" });
            DropColumn("dbo.Bil", "BrugerId");
        }
    }
}
