using ProjetoTicket.Models;
using System.Data.Entity.ModelConfiguration;

namespace ProjetoTicket.Config
{
    public class EstadoConfig : EntityTypeConfiguration<Estado>
    {
        public EstadoConfig()
        {
            HasKey(t => t.Id);

            Property(t => t.Nome).HasMaxLength(100).IsRequired();
            Property(t => t.Populacao).IsRequired();
            Property(t => t.CustoEstadoUS).IsRequired();



            ToTable("Estados");
        }
    }
}