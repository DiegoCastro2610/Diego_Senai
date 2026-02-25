using _10_02_2026_VH_BURGUER.Domains;
using _10_02_2026_VH_BURGUER.DTOs.LogProdutoDto;
using _10_02_2026_VH_BURGUER.Interfaces;

namespace _10_02_2026_VH_BURGUER.Applications.Services
{
    public class LogAlteracaoProdutoService
    {
        private readonly ILogAlteracaoProdutoRepository _repository;

        public LogAlteracaoProdutoService(ILogAlteracaoProdutoRepository repository)
        {
            _repository = repository;
        }

        public List<LerLogProdutoDto> Listar()
        {
            List<Log_AlteracaoProduto> logs = _repository.Listar();

            List<LerLogProdutoDto> listaLogProduto = logs.Select(log => new LerLogProdutoDto { LogID = log.Log_AlteracaoProdutoID, ProdutoID = log.ProdutoID, NomeAnterior = log.NomeAnterior, PrecoAnterior = log.PrecoAnterior, DataAlteracao = log.DataAlteracao }).ToList();
            return listaLogProduto;
        }

        public List<LerLogProdutoDto> ListarPorProduto(int produtoId)
        {
            List<Log_AlteracaoProduto> logs = _repository.ListarPorProduto(produtoId);

            List<LerLogProdutoDto> listaLogProduto = logs.Select(log => new LerLogProdutoDto { LogID = log.Log_AlteracaoProdutoID, ProdutoID = log.ProdutoID, NomeAnterior = log.NomeAnterior, PrecoAnterior = log.PrecoAnterior, DataAlteracao = log.DataAlteracao }).ToList();
            return listaLogProduto;
        }
    }
}
