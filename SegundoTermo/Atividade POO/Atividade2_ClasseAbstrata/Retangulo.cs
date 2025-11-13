using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade2_ClasseAbstrata
{
    public class Retangulo : Forma
    {
        public double Largura;

        public double Altura;

        public override double CalcularArea() => Largura * Altura;
    }
}