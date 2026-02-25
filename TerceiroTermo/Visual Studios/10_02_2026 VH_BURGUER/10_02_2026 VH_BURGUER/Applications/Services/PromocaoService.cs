using _10_02_2026_VH_BURGUER.Applications.Regras;
using _10_02_2026_VH_BURGUER.Domains;
using _10_02_2026_VH_BURGUER.DTOs.PromocaoDto;
using _10_02_2026_VH_BURGUER.Exceptions;
using _10_02_2026_VH_BURGUER.Interfaces;

namespace _10_02_2026_VH_BURGUER.Applications.Services
{
    public class PromocaoService
    {
        private readonly IPromocaoRepository _repository;

        public PromocaoService(IPromocaoRepository repository)
        {
            _repository = repository;
        }

        public List<LerPromocaoDto> Listar()
        {
            List<Promocao> promocaes = _repository.Listar();

            List<LerPromocaoDto> promocaesDto = promocaes.Select(promocao => new LerPromocaoDto { PromocaoID = promocao.PromocaoID, Nome = promocao.Nome, DataExpiracao = promocao.DataExpiracao, StatusPromocao = promocao.StatusPromocao }).ToList();

            return promocaesDto;
        }

        public LerPromocaoDto ObterPorId(int id)
        {
            Promocao promocao = _repository.ObterPorId(id);

            if (promocao == null)
            {
                throw new DomainException("Promocao não encontrada");
            }

            LerPromocaoDto promocaoDto = new LerPromocaoDto
            {
                PromocaoID = promocao.PromocaoID,
                Nome = promocao.Nome,
                DataExpiracao = promocao.DataExpiracao,
                StatusPromocao = promocao.StatusPromocao
            };

            return promocaoDto;
        }

        private static void ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new DomainException("Nome é obrigatorio");
            }
        }

        public void Adicionar(CriarPromocaoDto promocaoDto)
        {
            ValidarDataExpiracaoPromocao.ValidarDataExpiracao(promocaoDto.DataExpiracao);

            if (_repository.NomeExiste(promocaoDto.Nome))
            {
                throw new DomainException("Promocao ja existente"); 
            }

            Promocao promocao = new Promocao
            {
                Nome = promocaoDto.Nome,
                DataExpiracao = promocaoDto.DataExpiracao,
                StatusPromocao = promocaoDto.StatusPromocao
            };

            _repository.Adicionar(promocao);
        }

        public void Atualizar(int id, CriarPromocaoDto promocaoDto)
        {

            ValidarNome(promocaoDto.Nome);
            
            Promocao promocaoBanco = _repository.ObterPorId(id);

            if (promocaoBanco == null)
            {
                throw new DomainException("Promoção não encontrada");    
            }

            if (_repository.NomeExiste(promocaoDto.Nome, promocaIdAtual:id))
            {
                throw new DomainException("Promocao já existente");
            }

            promocaoBanco.Nome = promocaoDto.Nome;
            promocaoBanco.DataExpiracao = promocaoDto.DataExpiracao;
            promocaoBanco.StatusPromocao = promocaoDto.StatusPromocao;

            _repository.Atualizar(promocaoBanco);
        }

        public void Remover(int id)
        {
            Promocao promocaoBanco = _repository.ObterPorId(id);

            if(promocaoBanco == null)
            {
                throw new DomainException("Promoção não encontrada");
            }

            _repository.Remover(id);
        }
    }
}
