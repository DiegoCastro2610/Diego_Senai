using _10_02_2026_VH_BURGUER.Exceptions;

namespace _10_02_2026_VH_BURGUER.Applications.Regras
{
    public class ValidarDataExpiracaoPromocao
    {
        public static void ValidarDataExpiracao(DateTime dataExpiracao)
        {
            if(dataExpiracao <= DateTime.Now)
            {
                throw new DomainException("Data de expiracao deve ser futura");
            }
        }
    }
}
