using _10_02_2026_VH_BURGUER.Applications.Autentificacao;
using _10_02_2026_VH_BURGUER.Domains;
using _10_02_2026_VH_BURGUER.DTOs.AutenticacaoDto;
using _10_02_2026_VH_BURGUER.Exceptions;
using _10_02_2026_VH_BURGUER.Interfaces;

namespace _10_02_2026_VH_BURGUER.Applications.Services
{
    public class AuteticacaoService
    {
        private readonly IUsuarioRepository _repository;
        private readonly GeradorTokenJwt _tokenJwt;

        public AuteticacaoService(IUsuarioRepository repository, GeradorTokenJwt tokenJwt)
        {
            _repository = repository;
            _tokenJwt = tokenJwt;  
        }

        private static bool VerificarSenha(string senhaDigitada, byte[] senhaHashBanco)
        {
            using var sha = System.Security.Cryptography.SHA256.Create();
            var hashDigitado = sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senhaDigitada));

            return hashDigitado.SequenceEqual(senhaHashBanco);
        }

        public TokenDto Login(LoginDto loginDto)
        {
            Usuario usuario = _repository.ObterPorEmail(loginDto.Email);
           
            if (usuario.StatusUsuario == false)
            {
                throw new DomainException("Esse Usuario foi desativado");
            }

            if (usuario == null)
            {
                throw new DomainException("E-mail ou senha Invalidos");
            }

            if (!VerificarSenha(loginDto.Senha, usuario.Senha))
            {
                throw new DomainException("E-mail ou senha invalidos");
            }

      
            var token = _tokenJwt.GerarToken(usuario);

            TokenDto novoToken = new TokenDto { Token = token};
            return novoToken;
        }
    }
}
