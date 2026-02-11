using System;
using System.Collections.Generic;

namespace _10_02_2026_VH_BURGUER.Domains;

public partial class Promocao
{
    public int PromocaoID { get; set; }

    public string Nome { get; set; } = null!;

    public DateTime DataExpiracao { get; set; }

    public bool StatusPromocao { get; set; }

    public virtual ICollection<ProdutoPromocao> ProdutoPromocao { get; set; } = new List<ProdutoPromocao>();
}
