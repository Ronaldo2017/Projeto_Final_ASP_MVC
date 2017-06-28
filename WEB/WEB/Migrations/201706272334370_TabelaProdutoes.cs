namespace WEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TabelaProdutoes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        ProdutoID = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false),
                        Data = c.DateTime(nullable: false),
                        MaquinaID = c.Int(),
                    })
                .PrimaryKey(t => t.ProdutoID)
                .ForeignKey("dbo.Maquinas", t => t.MaquinaID)
                .Index(t => t.MaquinaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtoes", "MaquinaID", "dbo.Maquinas");
            DropIndex("dbo.Produtoes", new[] { "MaquinaID" });
            DropTable("dbo.Produtoes");
        }
    }
}
