namespace WEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TabelaCriarLotes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CriarLotes",
                c => new
                    {
                        CriarLoteID = c.Int(nullable: false, identity: true),
                        Lote = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CriarLoteID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CriarLotes");
        }
    }
}
