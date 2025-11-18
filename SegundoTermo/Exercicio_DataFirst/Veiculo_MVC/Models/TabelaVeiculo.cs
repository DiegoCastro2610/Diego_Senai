using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Veiculo_MVC.Models;

[Table("TabelaVeiculo")]
public partial class TabelaVeiculo
{
    [Key]
    public int Id { get; set; }

    [StringLength(25)]
    [Unicode(false)]
    public string Modelo { get; set; } = null!;

    public int Ano { get; set; }

    [StringLength(25)]
    [Unicode(false)]
    public string Classe { get; set; } = null!;
}
