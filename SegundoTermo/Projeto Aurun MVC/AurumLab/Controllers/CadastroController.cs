using AurumLab.Data;
using AurumLab.Models;
using AurumLab.Service;
using Microsoft.AspNetCore.Mvc;

namespace AurumLab.Controllers
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
        public IActionResult Criar(string nome, string email, string senha, string confirmar)
        {
            if(string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha) || string.IsNullOrWhiteSpace(confirmar))
            {
                ViewBag.Erro = "Preencha todos os Dados";
                return View("Index");
            }

            if(senha != confirmar)
            {
                ViewBag.Erro = "As senha e a confirmacao nao sao iguais";
                return View("Index");
            }

            // Verifica se o email esta cadastrado
            //Any() e parecido com o FirstOrDefalt()
            //Diferenca: FirstOrDefalt traz o objeto por completo Exemplo: nome, foto
            //Any() serve so para avaliar se esse email existe

            if(_context.Usuarios.Any(usuario => usuario.Email == email))
            {
                ViewBag.Erro = "email ja esta cadastrado";
                return View("Index");
            }

            byte[] hash = HashService.GerarHashBytes(senha);

            Usuario usuario = new Usuario
            {
                NomeCompleto = nome,
                Email = email,
                Senha = hash,
                Foto = null,
                RegraId = 1 //aluno por padrao
            };

            // salvar no banco
            // add e igual ao insert do banco de dados
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            // redireciona para o login
            return RedirectToAction("Index", "Login");
        }
    }
}