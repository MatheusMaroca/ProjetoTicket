namespace ProjetoTicket.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProjetoTicket.Contexto.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProjetoTicket.Contexto.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Estados.Add(new Models.Estado {Id = 1, Nome = "Rio Grande do Sul", Populacao = 0, CustoEstadoUS = 0});
            context.Estados.Add(new Models.Estado { Id = 2, Nome = "Santa Catarina", Populacao = 0, CustoEstadoUS = 0 });
            context.Estados.Add(new Models.Estado { Id = 3, Nome = "Paraná", Populacao = 0, CustoEstadoUS = 0 });

            context.Paramentros.Add(new Models.ParametroCusto { PorPessoa = (double)123.45, ValorCorte = 50000, Desconto = (double)12.3 });
            
        }
    }
}
