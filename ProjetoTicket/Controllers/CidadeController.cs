using ProjetoTicket.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class CidadeController : ApiController
    {
        /*List<Person> item = new List<Person>();*/
        private ProjetoTicket.Contexto.Context contexto = new ProjetoTicket.Contexto.Context();

        [Route("api/cidade")]
        [HttpGet]
        public IHttpActionResult getAll(string search)
        {
            if (string.IsNullOrEmpty(search))
                search = "";


            var list = contexto.Cidades.Include("Estado").Where(x => x.Nome.Contains(search)).ToList();

            return Ok(list);

        }

        [Route("api/cidade")]
        [HttpGet]
        public IHttpActionResult getById(int id)
        {
            var retortno = contexto.Cidades.FirstOrDefault(x => x.Id == id);

            return Ok(retortno);

        }

        [Route("api/cidade")]
        [HttpPost]
        public IHttpActionResult Add([FromBody] Cidade cidade)
        {
            if (contexto.Cidades.Any(x => x.Nome == cidade.Nome))
                return BadRequest("Cidade já cadastrada");

            if (cidade.Populacao == 0)
                return BadRequest("População obrigatório");

            try
            {
                var estado = new Estado();
                estado = contexto.Estados.Find(cidade.EstadoId);
                estado.Populacao += cidade.Populacao;

                var parametros = new ParametroCusto();
                parametros = contexto.Paramentros.Find(1);
                                
                if (cidade.Populacao > parametros.ValorCorte)
                {
                    cidade.CustoCidadeUS = (parametros.ValorCorte * parametros.PorPessoa) + ((cidade.Populacao - parametros.ValorCorte) * (parametros.PorPessoa - (parametros.PorPessoa * (parametros.Desconto * 100))));      } 
                else
                {
                    cidade.CustoCidadeUS = cidade.Populacao * parametros.PorPessoa;
                }
                estado.CustoEstadoUS += cidade.CustoCidadeUS;
                                  

                contexto.Cidades.Add(cidade);
                contexto.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok("Adicionado com sucesso!!");
        }

        [Route("api/cidade/{id}")]
        [HttpPut]
        public IHttpActionResult update(int id, [FromBody] Cidade cidade)
        {
            var result = contexto.Cidades.Find(id);
            if (result != null)
            {
                try
                {
                    contexto.Entry(result).CurrentValues.SetValues(cidade);
                    contexto.SaveChanges();
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            else
            {
                return BadRequest("cidade nao encontrada");
            }
            return Ok("Cidade atualizada com sucesso");

        }

        [Route("api/cidade/{id}")]
        [HttpDelete]
        
        public IHttpActionResult delete(int id)
        {
            var result = contexto.Cidades.Find(id);
            if (result != null)
            {
                
                try
                {
                    if(result.EstadoId == 1)
                    {
                        return BadRequest("Não é permitido excluir cidades do Rio Grande do Sul");
                    }
                    var estado = new Estado();
                    estado = contexto.Estados.Find(result.EstadoId);
                    estado.Populacao -= result.Populacao;

                    contexto.Cidades.Remove(result);
                    contexto.SaveChanges();
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            else
            {
                return BadRequest("Cidade não encontrada");
            }

            return Ok("Cidade removida com sucesso!");
        }
    }
}
