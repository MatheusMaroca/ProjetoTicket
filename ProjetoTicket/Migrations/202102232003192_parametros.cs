namespace ProjetoTicket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class parametros : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Parametro",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PorPessoa = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ValorCorte = c.Int(nullable: false),
                        Desconto = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Parametro");
        }
    }
}
