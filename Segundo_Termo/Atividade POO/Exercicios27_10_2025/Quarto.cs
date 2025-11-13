using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicios27_10_2025
{
    public class Quarto
    {
        public uint Numero{get;set;}

        public string Tipo{get;set;} 
        
        public bool Disponivel = true;

        public double PrecoDiaria{get;set;}

        //Construtor

        public Quarto(uint CNumero, string CTipo, double CPrecoDiaria)
        {
            Numero = CNumero;
            Tipo = CTipo;
            PrecoDiaria = CPrecoDiaria;
        }
        //--------------------------------------------------------------------------------------------
        public void ExibirDetalhesQuarto()
        {
            Console.WriteLine($"o numero e {Numero} e o tipo do quarto e {Tipo} e o preso da diaria e {PrecoDiaria} e o carto esta disponivel: {Disponivel} ");
        }

        public void Ocupar()
        {
            if(Disponivel == true)
            {
                Disponivel = false;
            }
            else
            {
                Console.WriteLine("Esse quarto ja esta oculpado");
            }
          
        }
        public void Liberar()
        {
            if(Disponivel == false)
            {
                Disponivel = true;
            }
            else
            {
               Console.WriteLine("Esse quarto ja esta Liberado"); 
            }
            
        }
    }
}