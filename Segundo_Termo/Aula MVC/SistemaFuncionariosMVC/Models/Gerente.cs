using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaFuncionariosMVC.Models
{
    public class Gerente : Funcionario
    {
        public Gerente() { }

        public Gerente(string CNome, double CSalarioBase) : base(CNome, CSalarioBase)
        { }

        public override double CalcularSalario() => SalarioBase *  1.5;

    }
}