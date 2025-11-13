using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbertoFechado_O
{
    public abstract class Desconto
    {
        public abstract double Calcular(double valor);
    }
}