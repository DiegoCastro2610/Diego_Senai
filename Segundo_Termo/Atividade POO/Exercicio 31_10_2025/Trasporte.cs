using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicio_31_10_2025
{
    public abstract class Trasporte
    {
       public abstract double CalcularTempoViagem(double Distancia);

       public void IniciarViagem()
       {
        Console.WriteLine("Viagem iniciada...");
       }
    }
}