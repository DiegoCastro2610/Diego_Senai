using Microsoft.AspNetCore.Mvc;
using LoginProjeto.Data;
using LoginProjeto.Models;
using LoginProjeto.Services;

namespace LoginProjeto.Controllers
{
    public class LoginController:Controller
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
            if(string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha)) //Verifica se existe espacos em branco ou se esta vazio
            {
                ViewBag.Erro = "Preencha todos os cantos corretamente";
                return View("Index");
            }

            // hash da senha digitada
            byte[] senhaDigitadaHash = HashService.GerarHashBytes(senha);

            // busca o usuario pelo email
            // firstordefault procura pelo se nao encontrar retorna nulo
            var usuario = _context.Usuarios.FirstOrDefault(usuario => usuario.Email == email);

            if(usuario == null)
            {
                ViewBag.Erro = "Email ou senha incorretos";
                return View("Index");
            }

            //comparar byte a byte da senha
            //SequenceEqual retorna false se estiver um byte incorreto
            if (!usuario.SenhaHash.SequenceEqual(senhaDigitadaHash))
            {
                ViewBag.Erro = "Email ou senha incorretos";
                return View("Index");
            }

            // login estiver ok ele salva na sessao 
            HttpContext.Session.SetString("UsuarioNome", usuario.NomeCompleto);
            HttpContext.Session.SetInt32("UsuarioId", usuario.Id);

            // retorna para index da home nao da de login
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Sair()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}