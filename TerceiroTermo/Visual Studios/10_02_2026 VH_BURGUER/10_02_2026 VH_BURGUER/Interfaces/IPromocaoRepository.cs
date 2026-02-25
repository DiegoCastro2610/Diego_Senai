using _10_02_2026_VH_BURGUER.Domains;

namespace _10_02_2026_VH_BURGUER.Interfaces
{
    public interface IPromocaoRepository
    {
        List<Promocao> Listar();

        Promocao ObterPorId(int id);

        bool NomeExiste(string nome, int? promocaIdAtual = null);

        void Adicionar(Promocao promocao);

        void Atualizar(Promocao promocao);

        void Remover(int  id);
    }
}
