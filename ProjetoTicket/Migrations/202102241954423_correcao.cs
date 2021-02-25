namespace ProjetoTicket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correcao : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cidade", "CustoCidadeUS", c => c.Double(nullable: false));
            AlterColumn("dbo.Estados", "CustoEstadoUS", c => c.Double(nullable: false));
            AlterColumn("dbo.Parametro", "PorPessoa", c => c.Double(nullable: false));
            AlterColumn("dbo.Parametro", "Desconto", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Parametro", "Desconto", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Parametro", "PorPessoa", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Estados", "CustoEstadoUS", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Cidade", "CustoCidadeUS", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
