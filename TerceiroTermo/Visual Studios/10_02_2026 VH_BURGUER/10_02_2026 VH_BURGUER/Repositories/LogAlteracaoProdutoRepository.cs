using _10_02_2026_VH_BURGUER.Contexts;
using _10_02_2026_VH_BURGUER.Domains;
using _10_02_2026_VH_BURGUER.Interfaces;

namespace _10_02_2026_VH_BURGUER.Repositories
{
    public class LogAlteracaoProdutoRepository : ILogAlteracaoProdutoRepository
    {
        private readonly VH_BurguerContext _context;

        public LogAlteracaoProdutoRepository(VH_BurguerContext context)
        {
            _context = context;
        }

        public List<Log_AlteracaoProduto> Listar()
        {
            List<Log_AlteracaoProduto> log = _context.Log_AlteracaoProduto.OrderByDescending(l => l.DataAlteracao).ToList();
            return log;
        }

    public List<Log_AlteracaoProduto> ListarPorProduto(int produtoId)
        {
            List<Log_AlteracaoProduto> alteracaoProdutos = _context.Log_AlteracaoProduto.Where(log => log.ProdutoID == produtoId).OrderByDescending(log => log.DataAlteracao).ToList();
            return alteracaoProdutos;
        }

    }
}
