namespace WEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TabelaEstoques : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Estoques",
                c => new
                    {
                        EstoqueID = c.Int(nullable: false, identity: true),
                        LoteID = c.Int(nullable: false),
                        FerramentaNova = c.Boolean(nullable: false),
                        FerramentaRemanufaturada = c.Boolean(nullable: false),
                        DataEntrada = c.DateTime(nullable: false),
                        DataSaida = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EstoqueID)
                .ForeignKey("dbo.Lotes", t => t.LoteID, cascadeDelete: true)
                .Index(t => t.LoteID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Estoques", "LoteID", "dbo.Lotes");
            DropIndex("dbo.Estoques", new[] { "LoteID" });
            DropTable("dbo.Estoques");
        }
    }
}
