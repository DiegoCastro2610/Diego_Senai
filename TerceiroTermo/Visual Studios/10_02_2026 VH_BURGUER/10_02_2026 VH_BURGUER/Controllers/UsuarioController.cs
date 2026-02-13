using _10_02_2026_VH_BURGUER.Applications.Services;
using _10_02_2026_VH_BURGUER.DTOs.UsuarioDto;
using _10_02_2026_VH_BURGUER.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _10_02_2026_VH_BURGUER.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _service;

        public UsuarioController(UsuarioService service)
        {
            _service = service;
        }

        [HttpGet] //Lista informações
        public ActionResult<List<LerUsuarioDto>> List()
        {
            List<LerUsuarioDto> usuarios = _service.Listar();
            return Ok(usuarios); //OK - 200: Deu certo
        }

        [HttpGet("{id}")]

        public ActionResult<LerUsuarioDto> ObterPorId(int id)
        {
            LerUsuarioDto usuario = _service.ObterPorId(id);

            if (usuario == null)
            {
                return NotFound(); // Nao encontrado Erro 404
            }

            return Ok(usuario);

        }

        [HttpGet("email/{email}")]
        public ActionResult<LerUsuarioDto> ObterPorEmail(string email)
        {
            LerUsuarioDto usuario = _service.ObterPorEmail(email);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        //enviar dados
        [HttpPost]

        public ActionResult<LerUsuarioDto> Adicionar(CriarUsuarioDto usuarioDto)
        {
            try
            {
                LerUsuarioDto usuarioCriado = _service.Adicionar(usuarioDto);
                return StatusCode(201, usuarioCriado);
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public ActionResult<LerUsuarioDto> Atualizar(int id, CriarUsuarioDto usuarioDto)
        {
            try
            {
                LerUsuarioDto usuarioAtualizado = _service.Atualizar(id, usuarioDto);

                return StatusCode(200, usuarioAtualizado);
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Remover os dados
        [HttpDelete("{id}")]
        public ActionResult Remover(int id)
        {
            try
            {
                _service.Remover(id);
                return NoContent();
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
