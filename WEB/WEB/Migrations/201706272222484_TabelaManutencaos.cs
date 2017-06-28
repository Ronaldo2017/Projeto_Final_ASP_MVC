namespace WEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TabelaManutencaos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Manutencaos",
                c => new
                    {
                        ManutencaoID = c.Int(nullable: false, identity: true),
                        CustoManutencao = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FerramentaID = c.Int(nullable: false),
                        DataEntrada = c.DateTime(nullable: false),
                        DataSaida = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ManutencaoID)
                .ForeignKey("dbo.Ferramentas", t => t.FerramentaID, cascadeDelete: true)
                .Index(t => t.FerramentaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Manutencaos", "FerramentaID", "dbo.Ferramentas");
            DropIndex("dbo.Manutencaos", new[] { "FerramentaID" });
            DropTable("dbo.Manutencaos");
        }
    }
}
