using _10_02_2026_VH_BURGUER.Applications.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _10_02_2026_VH_BURGUER.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogProdutoController : ControllerBase
    {
        private readonly LogAlteracaoProdutoService _service;

        public LogProdutoController(LogAlteracaoProdutoService service)
        {
            _service = service;
        }

        [HttpGet]

        public ActionResult Listar()
        {
            return Ok(_service.Listar());
        }

        [HttpGet("produto/{id}")]

        public ActionResult ListarProduto(int id)
        {
            return Ok(_service.ListarPorProduto(id));
        }
    }
}
