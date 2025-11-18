using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaFuncionariosMVC.Data;
using SistemaFuncionariosMVC.Models;

namespace SistemaFuncionariosMVC.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly APPDbContext _context;

        public FuncionarioController(APPDbContext CContext)
        {
            _context = CContext;
        }

        //listar
        //async ele quando atribuido a um comando faz que o codigo seja execultado por completo msm que esse comando nao seja finalizado
        public async Task<IActionResult> Index()
        {
            // ToList - lista as informacoes dentro da tabela funcionario
            var lista = await _context.TabelaFuncionario.ToListAsync();

            //retorna a view com a lista de funcionarios no index
            return View(lista);
        }

        //Formulario de criacao - retorna a lista de formulario vazia
        [HttpGet] // GET - Listar(como se fosse um select no banco)
        public IActionResult Criar() => View();

        // Cadastrar as informacoes do formulario no banco de dados
        [HttpPost] 
        public async Task<IActionResult> Criar(string CNome, double CSalarioBase, string CCargo)
        {
            Funcionario? novoFuncionario = null;

            if(CCargo == "Gerente")
            {
                novoFuncionario = new Gerente(CNome, CSalarioBase);
            }
            else if (CCargo == "Vendedor")
            {
                novoFuncionario = new Vendedor(CNome, CSalarioBase);
            }
            else
            {
                return BadRequest("Cargo Invalido.");
            }

            _context.TabelaFuncionario.Add(novoFuncionario);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        //Excluir
        public async Task<IActionResult> Deletar(int id)
        {
            //variavel que vai armazenar o registro de funcionario encontrado pelo id.
            //Find(id) -> busca o registro por id
            var funcionario = await _context.TabelaFuncionario.FindAsync(id);

            //
            if(funcionario == null) return NotFound();
            
            //
            _context.TabelaFuncionario.Remove(funcionario);

            // Salva as alteracoes
            await _context.SaveChangesAsync();

            //Retorna para a Action: Index -> Mostra a lista atualizada de funciomarios.
            return RedirectToAction("Index");
        }
    }
}