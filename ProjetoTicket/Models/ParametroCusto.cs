using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoTicket.Models
{
    public class ParametroCusto
    {
        public int Id { get; set; }
        public double PorPessoa { get; set; }
        public int ValorCorte { get; set; }
        public double Desconto { get; set; }
    }
}