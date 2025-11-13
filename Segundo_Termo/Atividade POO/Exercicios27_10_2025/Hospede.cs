using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicios27_10_2025
{
    public class Hospede
    {


        public string Nome { set; get; }
        public string Cpf{get;set;}
        public uint Telefone{get; set;}

        
        // Construtor

        public Hospede(string CCpf, string CNome, uint CTelefone )
        {
            Cpf = CCpf;
            Nome = CNome;
            Telefone = CTelefone; 
        }
        //-------------------------------------------------------------------------------------------------
        public void ExibirDetalhes()
        {
            Console.WriteLine($"Seu Nome e {Nome} seu CPF {Cpf} e telefone e {Telefone} ");
        }


       
    }
}