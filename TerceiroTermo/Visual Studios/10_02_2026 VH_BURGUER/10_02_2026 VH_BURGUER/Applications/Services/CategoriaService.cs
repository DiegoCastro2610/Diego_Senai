using _10_02_2026_VH_BURGUER.Domains;
using _10_02_2026_VH_BURGUER.DTOs.CategoriaDto;
using _10_02_2026_VH_BURGUER.Exceptions;
using _10_02_2026_VH_BURGUER.Interfaces;

namespace _10_02_2026_VH_BURGUER.Applications.Services
{
    public class CategoriaService
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaService(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        public List<LerCategoriaDto> Listar()
        {
            List<Categoria> categorias = _repository.Listar();

            List<LerCategoriaDto> categoriaDto = categorias.Select(categoria => new LerCategoriaDto { CategoriaID = categoria.CategoriaID, Nome = categoria.Nome }).ToList();

            return categoriaDto;
        }

        public LerCategoriaDto ObterPorId(int id)
        {
            Categoria categoria = _repository.ObterPorId(id);

            if(categoria == null)
            {
                throw new DomainException("categoria não encontrada");
            }

            LerCategoriaDto categoriaDto = new LerCategoriaDto
            {
                CategoriaID = categoria.CategoriaID,
                Nome = categoria.Nome
            };

            return categoriaDto;
        }

        private static void ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new DomainException("Nome é obrigatorio.");
            }
        }

        public void Adicionar(CriarCategoriaDto criarDto)
        {
            ValidarNome(criarDto.Nome);

            if(_repository.NomeExiste(criarDto.Nome))
            {
                throw new DomainException("Categoria ja existente");
            }

            Categoria categoria = new Categoria
            {
                Nome = criarDto.Nome
            };
            _repository.Adicionar(categoria);
        }

        public void Atualizar (int id, CriarCategoriaDto criarDto)
        {
            ValidarNome (criarDto.Nome);

            Categoria categoriaBamco = _repository.ObterPorId(id);

            if(categoriaBamco == null)
            {
                throw new DomainException("Categoria não encontrado");
            }

            if(_repository.NomeExiste(criarDto.Nome, categoriaIdAtual: id))
            {
                throw new DomainException("Categoria ja existente");
            }

            categoriaBamco.Nome = criarDto.Nome;
            _repository.Atualizar(categoriaBamco);
        }

        public void Remover(int id)
        {
            Categoria categoriaBanco = _repository.ObterPorId(id);

            if(categoriaBanco == null)
            {
                throw new DomainException("Categoria não encontrada.");
            }

            _repository.Remover(id);
        }
    }
}
