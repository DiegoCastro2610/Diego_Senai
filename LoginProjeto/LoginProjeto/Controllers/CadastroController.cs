using LoginProjeto.Data;
using LoginProjeto.Models;
using LoginProjeto.Services;


using Microsoft.AspNetCore.Mvc;

namespace LoginProjeto.Controllers
{
    public class CadastroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}