using LoginProjeto.Data;
using LoginProjeto.Models;
using LoginProjeto.Services;


using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LoginProjeto.Controllers
{
    public class CadastroController : Controller
    {
        private readonly AppDbContext _context;

        public CadastroController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        //Realiza Uma resposta a uma acao do usuario no cshtml
        public IActionResult Criar(string usuario, string email, string senha, string confirma)
        {
            if(string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha) || string.IsNullOrWhiteSpace(confirma))
            {
                ViewBag.Erro = "Preencha todos os Dados";
                return View("Index");
            }

            if(senha != confirma)
            {
                ViewBag.Erro = "As senha e a confirmacao nao sao iguais";
                return View("Index");
            }

             if(_context.Usuarios.Any(usuario => usuario.Email == email))
            {
                ViewBag.Erro = "email ja esta cadastrado";
                return View("Index");
            }

            byte[] hash = HashService.GerarHashBytes(senha);

            Usuario Usuario = new Usuario
            {
                NomeCompleto = usuario,
                Email = email,
                SenhaHash = hash,
                Foto = null,
                RegraId = 1 
            };

            
            _context.Usuarios.Add(Usuario);
            _context.SaveChanges();

            return RedirectToAction("Index", "Login");
        }
    }
}