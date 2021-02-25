using ProjetoTicket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoTicket.Models
{
    public class Estado
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Populacao { get; set; }
        public double CustoEstadoUS { get; set; }
        public ICollection<Cidade> Cidades{ get; set; }


    }
}