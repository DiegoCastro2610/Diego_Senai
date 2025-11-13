using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicio_MVC_PersonagemJogo.Models
{
    public abstract class Personagem
    {
        public string Nome { get; set; } = string.Empty;

        public uint Nivel { get; set; }

        public Personagem() { }

        public Personagem(string CNome, uint CNivel)
        {
            Nome = CNome;
            Nivel = CNivel;
        }

        public abstract double CalcularPoder();

        public virtual void ExibirStatus()
        {
            Console.WriteLine($"Seu personagem tem nome: {Nome} e nivel: {Nivel}");
        }
    }
}