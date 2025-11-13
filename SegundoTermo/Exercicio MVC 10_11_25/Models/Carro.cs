using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicio_MVC_10_11_25.Models
{
    public class Carro : Veiculo
    {
        public Carro() { }
        public Carro(string CModelo, double CAno) : base(CModelo, CAno)
        {

        }

        public override double CalcularRevisao() => 500;

        public override void ExibirResumo() 
        {
            Console.WriteLine($"Modelo: {Modelo} e o Ano: {Ano} e o Custo é {CalcularRevisao()}");
        }
    }
}