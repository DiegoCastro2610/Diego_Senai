using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Exercicio_MVC_10_11_25.Data;
using Exercicio_MVC_10_11_25.Models;

namespace Exercicio_MVC_10_11_25.Controllers
{
    public class VeiculoController : Controller
    {
        private readonly APPDbContext _context;

        public VeiculoController(APPDbContext CContext)
        {
            _context = CContext;
        }

        //listar
        //async ele quando atribuido a um comando faz que o codigo seja execultado por completo msm que esse comando nao seja finalizado
        public async Task<IActionResult> Index()
        {
            // ToList - lista as informacoes dentro da tabela funcionario
            var lista = await _context.ExibiçãoVeiculo.ToListAsync();

            //retorna a view com a lista de funcionarios no index
            return View(lista);
        }

        //Formulario de criacao - retorna a lista de formulario vazia
        [HttpGet] // GET - Listar(como se fosse um select no banco)
        public IActionResult Criar() => View();

        // Cadastrar as informacoes do formulario no banco de dados
        [HttpPost] 
        public async Task<IActionResult> Criar(string CModelo, double CAno, string QVeiculo)
        {
            Veiculo? NovoVeiculo = null;

            if(QVeiculo == "Carro")
            {
                NovoVeiculo = new Carro(CModelo, CAno);
            }
            else if (QVeiculo == "Moto")
            {
                NovoVeiculo = new Moto(CModelo, CAno);
            }
            else
            {
                return BadRequest("Veiculo invalido Invalido.");
            }

            _context.ExibiçãoVeiculo.Add(NovoVeiculo);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        //Excluir
        public async Task<IActionResult> Deletar(int id)
        {
            //variavel que vai armazenar o registro de funcionario encontrado pelo id.
            //Find(id) -> busca o registro por id
            var veiculo = await _context.ExibiçãoVeiculo.FindAsync(id);

            //
            if(veiculo == null) return NotFound();
            
            //
            _context.ExibiçãoVeiculo.Remove(veiculo);

            // Salva as alteracoes
            await _context.SaveChangesAsync();

            //Retorna para a Action: Index -> Mostra a lista atualizada de funciomarios.
            return RedirectToAction("Index");
        }
    }
}
        
