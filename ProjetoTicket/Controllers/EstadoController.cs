using System.Linq;
using System.Web.Http;

namespace ProjetoWeb.Controllers
{
    public class EstadoController : ApiController
    {
        private ProjetoTicket.Contexto.Context contexto = new ProjetoTicket.Contexto.Context();
        [Route("api/estado")]
        [HttpGet]
        public IHttpActionResult getAll(string search)
        {
            if (string.IsNullOrEmpty(search))
                search = "";

            var list = contexto.Estados.Where(x => x.Nome.Contains(search));

            return Ok(list);

        }


    }
}