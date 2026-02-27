using _10_02_2026_VH_BURGUER.Exceptions;

namespace _10_02_2026_VH_BURGUER.Applications.Regras
{
    public class HorarioAlteracaoProduto
    {
        public static void ValidarHorario()
        {
            var agora = DateTime.Now.TimeOfDay;
            var abertura = new TimeSpan(16, 0, 0);
            var fechamento = new TimeSpan(23, 0, 0);

            var estaAberto = agora >= abertura && agora <= fechamento;

            if (estaAberto)
            {
                throw new DomainException("Produto so pode ser alterado fora do horario de funcionamento");
            }
        }
    }
}
