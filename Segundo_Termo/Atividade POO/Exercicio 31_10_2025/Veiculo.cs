using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicio_31_10_2025
{
    public class Veiculo
    {
        public string Marca;
        public string Modelo;
        public uint Ano;

        public Veiculo(string CMarca, string CModelo, uint CAno)
        {
            Marca = CMarca;
            Modelo = CModelo;
            Ano = CAno;
        }

        public virtual void Ligar()
        {
            Console.WriteLine($"O veiculo {Modelo} Esta ligada");
        }

        public virtual void ExibirDetalhes()
        {
            Console.WriteLine($"A marca é {Marca} o modelo é {Modelo} e o ano é {Ano}");
        }
    }
}