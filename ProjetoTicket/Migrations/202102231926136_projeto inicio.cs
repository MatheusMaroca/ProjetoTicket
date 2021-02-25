namespace ProjetoTicket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class projetoinicio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cidade",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Populacao = c.Int(nullable: false),
                        CustoCidadeUS = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EstadoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Estados", t => t.EstadoId, cascadeDelete: false)
                .Index(t => t.EstadoId);
            
            CreateTable(
                "dbo.Estados",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Populacao = c.Int(nullable: false),
                        CustoEstadoUS = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cidade", "EstadoId", "dbo.Estados");
            DropIndex("dbo.Cidade", new[] { "EstadoId" });
            DropTable("dbo.Estados");
            DropTable("dbo.Cidade");
        }
    }
}
