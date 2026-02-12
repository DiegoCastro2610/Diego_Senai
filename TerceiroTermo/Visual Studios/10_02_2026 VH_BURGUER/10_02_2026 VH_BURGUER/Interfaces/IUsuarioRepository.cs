using _10_02_2026_VH_BURGUER.Domains;

namespace _10_02_2026_VH_BURGUER.Interfaces
{
    public interface IUsuarioRepository
    {
        List<Usuario> Listar();

        //pode ser que nao venha usuario na busca,
        //entao colocamos "?"
        Usuario? ObterPorId(int id);

        Usuario? ObterPorEmail(string name);

        bool EmailExiste(string email);

        void Adicionar(Usuario usuario);

        void Atualizar(Usuario usuario);

        void Remover(int id);
    }
}
