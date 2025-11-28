using Microsoft.AspNetCore.Mvc;
using AurumLab.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using AurumLab.Service;


namespace AurumLab.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Entrar(string email, string senha)
        {
            if(string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
            {
                ViewBag.Error = "Preencha todos os acampos";
                return View("Index");
            }

            byte[] senhaDigitadaHash = HashService.GerarHashBytes(senha);

            var usuario = _context.Usuarios.FirstOrDefault(usuario => usuario.Email == email);
            if(usuario == null)
            {
                ViewBag.Error = "E-mail ou senha incorreta";
                return View("Index");
            }

            if(!usuario.Senha.SequenceEqual(senhaDigitadaHash))
            {
                ViewBag.Error = "E-mail ou senha incorreta";
                return View("Index");
            }

            HttpContext.Session.SetString("UsuarioNome", usuario.NomeCompleto);
            HttpContext.Session.SetInt32("UsuarioId", usuario.IdUsuario);

            return RedirectToAction("Dashboard", "Dashboard");
        }

        public IActionResult Sair()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}