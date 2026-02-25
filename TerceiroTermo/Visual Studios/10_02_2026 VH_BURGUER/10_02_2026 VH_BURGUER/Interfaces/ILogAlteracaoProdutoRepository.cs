using _10_02_2026_VH_BURGUER.Domains;

namespace _10_02_2026_VH_BURGUER.Interfaces
{
    public interface ILogAlteracaoProdutoRepository
    {
        List<Log_AlteracaoProduto> Listar();
        List<Log_AlteracaoProduto> ListarPorProduto(int produtoId);
    }
}
