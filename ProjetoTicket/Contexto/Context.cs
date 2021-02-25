using ProjetoTicket.Config;
using ProjetoTicket.Models;
using System.Data.Entity;

namespace ProjetoTicket.Contexto
{
    public class Context : DbContext
    {
        public Context()
            :base("name=contexto")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Cidade> Cidades { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<ParametroCusto> Paramentros { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CidadeConfig());
            modelBuilder.Configurations.Add(new EstadoConfig());
            modelBuilder.Configurations.Add(new ParametroCustoConfig());
            base.OnModelCreating(modelBuilder);
        }


    }
    
}