using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Sistema_Login.Data;
using Sistema_Login.Services;
using Sistema_Login.Models;

namespace Sistema_Login.Controllers
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
                ViewBag.Erro = "Prencha todos os dados corretamente";
                return View("Index");
            }

            // Hash da senha digitada
            byte[] senhaDigitadaHash = HashService.GerarHashBytes(senha);

            //busca usuario pelo email
            //FirstOrDefalt -> procura o usuario peloc email, se não encontrar retornar null 
            var usuario = _context.Usuarios.FirstOrDefault(usuario => usuario.Email == email);

            if(usuario == null)
            {
                ViewBag.Erro = "E-mail ou senha incorreto.";
                return View("Index");
            }

            // comparar byte a byte da senha
            //sequenceEqual -> retorna false se qualquer byte não estiver correto
            if(!usuario.SenhaHash.SequenceEqual(senhaDigitadaHash))
            {
                ViewBag.Erro = "E-mail ou senha incorreta.";
                return View("Index");
            }

            //Login estiver OK -> salvar na sessão
            HttpContext.Session.SetString("UsuarioNome", usuario.NomeCompleto);
            HttpContext.Session.SetInt32("UsuarioId", usuario.Id);

            //retorna para a index da home, não da login
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Sair()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}