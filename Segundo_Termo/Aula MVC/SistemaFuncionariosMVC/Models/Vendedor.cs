using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaFuncionariosMVC.Models
{
    public class Vendedor : Funcionario
    {
        public Vendedor() { }

        public Vendedor(string CNome, double CSalarioBase) : base(CNome, CSalarioBase)
        { }

        public override double CalcularSalario() => SalarioBase * 1.2;


    }
}