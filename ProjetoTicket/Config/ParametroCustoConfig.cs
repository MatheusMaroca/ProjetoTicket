using ProjetoTicket.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ProjetoTicket.Config
{
    public class ParametroCustoConfig : EntityTypeConfiguration <ParametroCusto>
    {
        public ParametroCustoConfig()
        {
            HasKey(t => t.Id);

            Property(t => t.PorPessoa).IsRequired();
            Property(t => t.ValorCorte).IsRequired();
            Property(t => t.Desconto).IsRequired();



            ToTable("Parametro");
        }
    }
}