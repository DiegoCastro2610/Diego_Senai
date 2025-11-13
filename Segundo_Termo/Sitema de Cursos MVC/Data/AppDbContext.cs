
using Microsoft.EntityFrameworkCore;
using Sitema_de_Cursos_MVC.Models;

namespace Sitema_de_Cursos_MVC.Data
{
    public class AppDbContext : DbContext
    {
        // recebendo as opções de configuração do banco
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // direciona a clase Curso para a TabelaCurso no banco de dados.
        public DbSet<Curso> TabelaCurso { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curso>()
            .HasDiscriminator<string>("Tipo")
            .HasValue<Tecnico>("Tecnico")
            .HasValue<Superior>("Superior");
        }

    }
}