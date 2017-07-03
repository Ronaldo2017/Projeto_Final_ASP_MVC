namespace WEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionandoLote : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Estoques", "CriarLoteID", "dbo.CriarLotes");
            DropIndex("dbo.Estoques", new[] { "CriarLoteID" });
            AddColumn("dbo.Estoques", "LoteID", c => c.Int(nullable: false));
            CreateIndex("dbo.Estoques", "LoteID");
            AddForeignKey("dbo.Estoques", "LoteID", "dbo.Lotes", "LoteID", cascadeDelete: true);
            DropColumn("dbo.Estoques", "CriarLoteID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Estoques", "CriarLoteID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Estoques", "LoteID", "dbo.Lotes");
            DropIndex("dbo.Estoques", new[] { "LoteID" });
            DropColumn("dbo.Estoques", "LoteID");
            CreateIndex("dbo.Estoques", "CriarLoteID");
            AddForeignKey("dbo.Estoques", "CriarLoteID", "dbo.CriarLotes", "CriarLoteID", cascadeDelete: true);
        }
    }
}
