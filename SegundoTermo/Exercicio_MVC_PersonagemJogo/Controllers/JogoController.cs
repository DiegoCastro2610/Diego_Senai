using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Exercicio_MVC_PersonagemJogo.Controllers
{
    [Route("[controller]")]
    public class JogoController : Controller
    {
        private readonly AppContext _context;

        public JogoController(AppContext C_context)
        {
            _context = C_context;
        }

        public async Task<IActionResult> Index()
        {
            var lista = await _context.

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}