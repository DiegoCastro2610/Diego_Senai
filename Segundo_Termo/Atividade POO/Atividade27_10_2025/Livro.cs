using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade27_10_2025
{
    public class Livro
    {
        public string Titulo {get ; set; }

        public string Autor {get ; set; }

        public int AnoPublicacao; /*{get
        {
            return AnoPublicacao;
        } 
         set
         {
            if (value > 0)
            {
                AnoPublicacao = value;
            }

            else
            {
                Console.WriteLine("erro o ano e invalido");
            }
         } }*/

        public double Preco {get ; set; }
        
        public bool EstaDisponivel {get ; set; } = true;

        // construtor
        // e um metodo especial, usando para inicializar o estado do objeto.

        public Livro(String TituloC, string AutorC, int AnoC, double PrecoC)
        {
            Titulo = TituloC;
            Autor = AutorC;
            AnoPublicacao = AnoC;
            Preco = PrecoC;

            EstaDisponivel = true;

            Console.WriteLine($"Novo livro: {TituloC} criado e disponivel.");
        }

        public void ExibirDetalhes()
        {
            Console.WriteLine("*** detalhe do livro ***");
            Console.WriteLine($"Titilo: {Titulo}");
            Console.WriteLine($"Autor: {Autor}");
            Console.WriteLine($"Publicacao: {AnoPublicacao}");
            Console.WriteLine($"preco: {Preco:F2}");

            if(EstaDisponivel)
            {
                Console.WriteLine("Status: Disponivel para emprestimo");
            }
            else
            {
                Console.WriteLine("Status: Emprestado(Indisponivel)");
            }
        }

        public void Emprestar()
        {
            if(EstaDisponivel)
            {
                EstaDisponivel = false;
                Console.WriteLine($"O livro: {Titulo} foi emprestado");
            }
            else
            {
                Console.WriteLine($"O livro: {Titulo} ja esta emprestado");
            }
        }
    }
}