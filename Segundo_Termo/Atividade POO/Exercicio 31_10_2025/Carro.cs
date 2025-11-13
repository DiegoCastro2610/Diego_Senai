using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicio_31_10_2025
{
    public class Carro : Veiculo

    {
        public uint QuantidadeDePorta;

        public Carro(string CMarca, string CModelo, uint CAno, uint CQuantidadeDePorta) : base(CMarca, CModelo, CAno)// base leva os valores para os atributos da classe pai
        {
            QuantidadeDePorta = CQuantidadeDePorta;
        }

        public override void Ligar()
        {
            Console.WriteLine($"O carro {Modelo} esta pronto para rodar!");
        }

         public override void ExibirDetalhes()
        {
            Console.WriteLine($"A marca é {Marca} o modelo é {Modelo} e o ano é {Ano} e a quantidae de portas é {QuantidadeDePorta}");
        }
    }
}