using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LoginProjeto.Models;

[Table("Usuario")]
[Index("Email", Name = "UQ__Usuario__A9D10534CF2733C5", IsUnique = true)]
public partial class Usuario
{
    [Key]
    public int Id { get; set; }

    [StringLength(120)]
    [Unicode(false)]
    public string NomeCompleto { get; set; } = null!;

    [StringLength(120)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [MaxLength(32)]
    public byte[] SenhaHash { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? CriadoEm { get; set; }
}