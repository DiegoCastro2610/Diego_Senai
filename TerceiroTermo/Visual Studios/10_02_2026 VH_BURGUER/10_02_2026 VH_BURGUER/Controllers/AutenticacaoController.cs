using _10_02_2026_VH_BURGUER.Applications.Services;
using _10_02_2026_VH_BURGUER.DTOs.AutenticacaoDto;
using _10_02_2026_VH_BURGUER.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _10_02_2026_VH_BURGUER.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private readonly AuteticacaoService _service;

        public AutenticacaoController(AuteticacaoService service)
        {
            _service = service;
        }

        [HttpPost("login")]

        public ActionResult<TokenDto> Login(LoginDto loginDto)
        {
            try
            {
                var token = _service.Login(loginDto);
                    return Ok(token);
            }
            catch (DomainException ex)
            {
                return BadRequest(ex.Message); 
            }
        }
    }
}
