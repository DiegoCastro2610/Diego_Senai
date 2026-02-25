using _10_02_2026_VH_BURGUER.Domains;

namespace _10_02_2026_VH_BURGUER.Interfaces
{
    public interface ICategoriaRepository
    {
        List<Categoria> Listar();
        Categoria ObterPorId(int id);

        bool NomeExiste(string nome, int? categoriaIdAtual = null);

        void Adicionar(Categoria categoria);

        void Atualizar(Categoria categoria);

        void Remover(int  id);
    }
}
