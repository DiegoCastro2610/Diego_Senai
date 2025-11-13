using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Exercicio_MVC_10_11_25.Models;

namespace Exercicio_MVC_10_11_25.Data
{
    public class APPDbContext : DbContext
    {
        public APPDbContext(DbContextOptions<APPDbContext> options) : base(options)
        { }
        // recebe as opcoes de configuracao do banco

        public DbSet<Veiculo> ExibiçãoVeiculo {get;set;}
        // direciona a classe (Funcionario) para a tabela (TabelaFuncionario)

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Veiculo>()/*comeca a configurar a entidade base Funcionario*/.HasDiscriminator<string>("QVeiculo")/*cria uma unica tabela, diferenciando gerente e vendedor por cargo*/.HasValue<Carro>("Carro")/**/.HasValue<Moto>("Moto")/**/;
        }
        // sobrescreve o mapeamento do modelo (uma unica tabela para funcionarios)
    }
}