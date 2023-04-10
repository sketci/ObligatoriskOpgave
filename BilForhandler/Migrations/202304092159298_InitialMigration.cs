namespace BilForhandler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bil",
                c => new
                    {
                        BilId = c.Guid(nullable: false),
                        Navn = c.String(),
                        Mærke = c.String(),
                        Model = c.String(),
                        År = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BilId);
            
            CreateTable(
                "dbo.Bruger",
                c => new
                    {
                        BrugerId = c.Guid(nullable: false),
                        Navn = c.String(),
                        Mail = c.String(),
                        Medarbejder = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BrugerId);
            
            CreateTable(
                "dbo.Pris",
                c => new
                    {
                        PrisId = c.Guid(nullable: false),
                        Navn = c.String(),
                        Beløb = c.Double(nullable: false),
                        IndkøbsPris = c.Boolean(nullable: false),
                        SalgsPris = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PrisId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pris");
            DropTable("dbo.Bruger");
            DropTable("dbo.Bil");
        }
    }
}
