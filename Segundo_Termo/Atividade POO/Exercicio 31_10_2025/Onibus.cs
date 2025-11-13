using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicio_31_10_2025
{
    public class Onibus : Trasporte
    {
        public const uint Velocidade = 60;

        public double Tempo;

        public override double CalcularTempoViagem(double Distancia)
        {
          Tempo =  Distancia / Velocidade;
          return Tempo;
        }
    }
}