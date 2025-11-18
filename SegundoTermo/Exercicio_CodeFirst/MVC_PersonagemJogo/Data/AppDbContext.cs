using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Common;
using System.Threading.Tasks;
using Exercicio_MVC_PersonagemJogo.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercicio_MVC_PersonagemJogo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        // recebe as opcoes de configuracao do banco

        public DbSet<Personagem> TabelaPersonagem {get;set;}
        // direciona a classe (Funcionario) para a tabela (TabelaFuncionario)

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personagem>()/*comeca a configurar a entidade base Funcionario*/.HasDiscriminator<string>("QClasse")/*cria uma unica tabela, diferenciando gerente e vendedor por cargo*/.HasValue<Mago>("Mago")/**/.HasValue<Guerreiro>("Guerreiro")/**/;
        }
        // sobrescreve o mapeamento do modelo (uma unica tabela para funcionarios)
    }
}