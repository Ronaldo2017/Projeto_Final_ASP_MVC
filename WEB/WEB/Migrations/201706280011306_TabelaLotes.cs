namespace WEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TabelaLotes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lotes",
                c => new
                    {
                        LoteID = c.Int(nullable: false, identity: true),
                        LoteFerramenta = c.String(nullable: false),
                        FerramentaID = c.Int(nullable: false),
                        CriarLoteID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LoteID)
                .ForeignKey("dbo.CriarLotes", t => t.CriarLoteID, cascadeDelete: true)
                .ForeignKey("dbo.Ferramentas", t => t.FerramentaID, cascadeDelete: true)
                .Index(t => t.FerramentaID)
                .Index(t => t.CriarLoteID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lotes", "FerramentaID", "dbo.Ferramentas");
            DropForeignKey("dbo.Lotes", "CriarLoteID", "dbo.CriarLotes");
            DropIndex("dbo.Lotes", new[] { "CriarLoteID" });
            DropIndex("dbo.Lotes", new[] { "FerramentaID" });
            DropTable("dbo.Lotes");
        }
    }
}
