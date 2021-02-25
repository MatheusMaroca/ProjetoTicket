using ProjetoTicket.Models;
using System.Data.Entity.ModelConfiguration;

namespace ProjetoTicket.Config
{
    public class CidadeConfig : EntityTypeConfiguration<Cidade>

    {
        public CidadeConfig()
        {
            HasKey(t => t.Id);

            Property(t => t.Nome).HasMaxLength(100).IsRequired();
            Property(t => t.Populacao).IsRequired();
            Property(t => t.CustoCidadeUS).IsRequired();

            HasRequired<Estado>(m => m.Estado)
        
                .WithMany(m => m.Cidades)
        
                .HasForeignKey(s => s.EstadoId);


            ToTable("Cidade");



        }
    }
}