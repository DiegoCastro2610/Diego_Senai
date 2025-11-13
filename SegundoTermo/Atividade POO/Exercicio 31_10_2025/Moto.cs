using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicio_31_10_2025
{
    public class Moto : Veiculo
    {
        public uint Cilindrada;

        public Moto(string CMarca, string CModelo, uint CAno, uint CCilindrada) : base(CMarca, CModelo, CAno)
        {
            Cilindrada = CCilindrada;
        }

        public override void Ligar()
        {
            Console.WriteLine($"A moto {Modelo} de {Cilindrada}cc esta pronta!");
        }

         public override void ExibirDetalhes()
        {
            Console.WriteLine($"A marca é {Marca} o modelo é {Modelo} e o ano é {Ano} e a cilindrada é {Cilindrada}");
        }
    }
}