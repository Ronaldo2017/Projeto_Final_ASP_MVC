namespace WEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TabelaMaquinas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Maquinas",
                c => new
                    {
                        MaquinaID = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false),
                        Descricao = c.String(),
                        Data = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MaquinaID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Maquinas");
        }
    }
}
