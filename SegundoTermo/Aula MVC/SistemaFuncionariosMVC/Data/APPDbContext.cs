using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaFuncionariosMVC.Models;

namespace SistemaFuncionariosMVC.Data
{
    public class APPDbContext : DbContext
    {
        public APPDbContext(DbContextOptions<APPDbContext> options) : base(options)
        { }
        // recebe as opcoes de configuracao do banco

        public DbSet<Funcionario> TabelaFuncionario {get;set;}
        // direciona a classe (Funcionario) para a tabela (TabelaFuncionario)

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funcionario>()/*comeca a configurar a entidade base Funcionario*/.HasDiscriminator<string>("Cargo")/*cria uma unica tabela, diferenciando gerente e vendedor por cargo*/.HasValue<Gerente>("Gerente")/**/.HasValue<Vendedor>("Vendedor")/**/;
        }
        // sobrescreve o mapeamento do modelo (uma unica tabela para funcionarios)
    }
}