using Microsoft.AspNetCore.Mvc;
using AurumLab.Data;
using AurumLab.Models;
using System.ComponentModel.DataAnnotations;
using AurumLab.Service;

namespace AurumLab.Controllers
{
    public class perfilController : Controller
    {
        private readonly AppDbContext _context;
        
        public perfilController(AppDbContext context)
        {
            _context = context;
        }

        //GET tela de perfil
        public IActionResult Index()
        {
            int? usuarioId = HttpContext.Session.GetInt32("UsuarioId");

            if (usuarioId == null)
            {
                return RedirectToAction("Index", "Login");
            }

            //pega os dados por completo do usuario logado na sessao pelo id
            var usuario = _context.Usuarios.FirstOrDefault(usuario => usuario.IdUsuario == usuarioId);

            var viewModel = new PerfilViewModel
            {
                IdUsuario = usuario.IdUsuario,
                NomeCompleto = usuario.NomeCompleto,
                //NomeUsuario = usuario.NomeUsuario,
                NomeUsuario = usuario?.NomeUsuario ?? "Usuario",
                Email = usuario.Email,
                RegraId = usuario.RegraId,
                Regras = _context.RegraPerfils.ToList(),


                FotoBase64 = usuario.Foto != null
            ?Convert.ToBase64String(usuario.Foto)
            : null
            };

            return View(viewModel);   
        }

        //POST - Salvar dados de texto do perfil
        [HttpPost]
        public IActionResult Index(PerfilViewModel model)
        {
            var usuario = _context.Usuarios.FirstOrDefault(usuario => usuario.IdUsuario == model.IdUsuario);

            if (usuario == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if(!string.IsNullOrWhiteSpace(model.NovaSenha))
            {
                if(model.NovaSenha != model.ConfirmarSenha)
                {
                    ViewBag.Erro = "As senhas nao sao iguais.";

                    model.Regras = _context.RegraPerfils.ToList();
                    return View(model);
                }

                usuario.Senha = HashService.GerarHashBytes(model.NovaSenha);
            }

            //Atualiza os restante dos dados
            usuario.NomeCompleto = model.NomeCompleto;
            usuario.NomeUsuario = model.NomeUsuario;
            usuario.Email = model.Email;
            usuario.RegraId = model.RegraId;

            _context.SaveChangesAsync();

            //ViewBag morre no redirect
            //TempData sobrevive a um redirect (uma vez)
            TempData["Sucesso"] = "Perfil atualizado com sucesso";
            return RedirectToAction("Index");
        }

        //POST - Atualizar a foto de perfil (MODAL)
        [HttpPost]

        public IActionResult AtualizarFoto(int IdUsuario, IFormFile foto)
        {
            if (foto == null || foto.Length == 0)
            {
                return RedirectToAction("Index");
            }

            var usuario = _context.Usuarios.FirstOrDefault(usuario => usuario.IdUsuario == IdUsuario);

            if(usuario == null)
            {
                return RedirectToAction("Index", "Login");
            }

            using (var ms = new MemoryStream())
            {
                foto.CopyTo(ms);
                usuario.Foto = ms.ToArray();
            }

            _context.SaveChangesAsync();
            TempData["Sucesso"]= "Foto atualizada com sucesso";
            return RedirectToAction("Index");
        }
    }
}