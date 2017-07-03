namespace WEB.Migrations
{
   
    using System.Data.Entity.Migrations;
    
    public partial class AdicionandoSituacaoFerramenta : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Estoques", "_Situacao", c => c.Int(nullable: false));
            DropColumn("dbo.Estoques", "FerramentaNova");
            DropColumn("dbo.Estoques", "FerramentaRemanufaturada");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.Estoques", "FerramentaRemanufaturada", c => c.Boolean(nullable: false));
            //AddColumn("dbo.Estoques", "FerramentaNova", c => c.Boolean(nullable: false));
            DropColumn("dbo.Estoques", "_Situacao");
        }
    }
}
