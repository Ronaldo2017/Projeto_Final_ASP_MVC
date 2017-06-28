namespace WEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TabelaProducaos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Producaos",
                c => new
                    {
                        ProducaoID = c.Int(nullable: false, identity: true),
                        DataEntrada = c.DateTime(nullable: false),
                        LoteID = c.Int(nullable: false),
                        MaquinaID = c.Int(nullable: false),
                        ProdutoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProducaoID)
                .ForeignKey("dbo.Lotes", t => t.LoteID, cascadeDelete: true)
                .ForeignKey("dbo.Maquinas", t => t.MaquinaID, cascadeDelete: true)
                .ForeignKey("dbo.Produtoes", t => t.ProdutoID, cascadeDelete: true)
                .Index(t => t.LoteID)
                .Index(t => t.MaquinaID)
                .Index(t => t.ProdutoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Producaos", "ProdutoID", "dbo.Produtoes");
            DropForeignKey("dbo.Producaos", "MaquinaID", "dbo.Maquinas");
            DropForeignKey("dbo.Producaos", "LoteID", "dbo.Lotes");
            DropIndex("dbo.Producaos", new[] { "ProdutoID" });
            DropIndex("dbo.Producaos", new[] { "MaquinaID" });
            DropIndex("dbo.Producaos", new[] { "LoteID" });
            DropTable("dbo.Producaos");
        }
    }
}
