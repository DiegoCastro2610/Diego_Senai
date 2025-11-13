using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicios27_10_2025
{
    public class Reserva
    {
        public Hospede RHospede;

        public Quarto RQuarto;

        public uint Dias;

        public double Total;

        //Construtor 

        public Reserva(Hospede CHospede, Quarto CQuarto, uint CDias)
        {
            RHospede = CHospede;
            RQuarto = CQuarto;
            Dias = CDias;
        }
        //-----------------------------------------------------------------------------------------------
        public virtual double CalcularTotal()
        {
            Total = RQuarto.PrecoDiaria * Dias;
            return Total;
        }


       public void ResumoReserva ()
       {
        Console.WriteLine($"O hospede e {RHospede.Nome} e o quarto e {RQuarto.Numero} e vai ficar {Dias} e o Valor Total e {Total}");
       }

    }
}