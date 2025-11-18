using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Veiculo_MVC.Models;

namespace Veiculo_MVC.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TabelaVeiculo> TabelaVeiculo { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
