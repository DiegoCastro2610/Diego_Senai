using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicio_MVC_10_11_25.Models
{
    public class Moto : Veiculo
    {
        public Moto() { }
        
        public Moto(string CModelo, double CAno ) : base(CModelo, CAno)
        {

        }

        public override double CalcularRevisao() => 300;

        public override void ExibirResumo() 
        {
            Console.WriteLine($"Modelo: {Modelo} e o Ano: {Ano} e o Custo é {CalcularRevisao()}");
        }
    }
}