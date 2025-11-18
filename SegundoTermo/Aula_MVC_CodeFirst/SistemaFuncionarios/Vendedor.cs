using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaFuncionarios
{
    public class Vendedor : Funcionario
    {
        public Vendedor(string CNome, double CSalarioBase) : base (CNome, CSalarioBase)
        {}

        public override double CalcularSalario()
        {
            return SalarioBase * 1.5; //50% de bonus
        }
    }
}