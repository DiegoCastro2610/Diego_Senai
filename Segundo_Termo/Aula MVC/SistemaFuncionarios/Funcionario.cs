using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaFuncionarios
{
    public abstract class Funcionario
    {
        public string Nome {get;set;} = string.Empty;

        public double SalarioBase{get;set;}

        public Funcionario(string CNome, double CSalarioBase)
        {
            Nome = CNome;
            SalarioBase = CSalarioBase;
        }

        public virtual void ExibirResumo()
        {
            Console.WriteLine($"Funcionario: {Nome}");
            Console.WriteLine($"Salario Base: RS{SalarioBase:F2}");
            Console.WriteLine($"Salario Final: RS{CalcularSalario():F2}");
        }

        public abstract double CalcularSalario();
    }
}