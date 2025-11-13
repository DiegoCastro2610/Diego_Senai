using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicios27_10_2025
{
    public class ReservaVip : Reserva
    {
        public uint Desconto { get; set; }


        //Construtor

        public ReservaVip(Hospede CHospede, Quarto CQuarto, uint CDias, uint CDesconto) : base(CHospede, CQuarto, CDias)
        {
            Desconto = CDesconto;
        }
//----------------------------------------------------------------------------------------------------------------

        public override double CalcularTotal()
        {
            Total = (RQuarto.PrecoDiaria * Dias) - (Desconto / 100) * (RQuarto.PrecoDiaria * Dias);
            return Total;
        }
        
    }
}
