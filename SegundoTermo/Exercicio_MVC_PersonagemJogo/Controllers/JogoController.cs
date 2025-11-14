using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Exercicio_MVC_PersonagemJogo.Data;
using Exercicio_MVC_PersonagemJogo.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercicio_MVC_PersonagemJogo.Controllers
{
    public class JogoController : Controller
    {
        private readonly AppDbContext _context;

        public JogoController(AppDbContext C_context)
        {
            _context = C_context;
        }

        public async Task<IActionResult> Index()
        {
            var lista = await _context.TabelaPersonagem.ToListAsync();

            return View(lista);
        }

        [HttpGet]
        public IActionResult Criar() => View();

        [HttpPost]
        public async Task<IActionResult> Criar(string CNome, uint CNivel, string QClasse)
        {
            Personagem? NovoPersonagem = null;

            if (QClasse == "Mago")
            {
                NovoPersonagem = new Mago(CNome, CNivel);
            }
            else if (QClasse == "Guerreiro")
            {
                NovoPersonagem = new Guerreiro(CNome, CNivel);
            }
            else
            {
                return BadRequest("Classe invalido Invalido.");
            }

            _context.TabelaPersonagem.Add(NovoPersonagem);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        //Excluir
        public async Task<IActionResult> Deletar(int id)
        {
            //variavel que vai armazenar o registro de funcionario encontrado pelo id.
            //Find(id) -> busca o registro por id
            var personagem = await _context.TabelaPersonagem.FindAsync(id);

            //
            if (personagem == null) return NotFound();

            //
            _context.TabelaPersonagem.Remove(personagem);

            // Salva as alteracoes
            await _context.SaveChangesAsync();

            //Retorna para a Action: Index -> Mostra a lista atualizada de funciomarios.
            return RedirectToAction("Index");
        }
    }
}