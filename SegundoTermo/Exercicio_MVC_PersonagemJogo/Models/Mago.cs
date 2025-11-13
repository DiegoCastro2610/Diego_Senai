using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicio_MVC_PersonagemJogo.Models
{
    public class Mago : Personagem
    {
        public double Poder;
        public Mago() {}
        public Mago(string CNome, uint CNivel) : base(CNome, CNivel)
        { }

        public override double CalcularPoder()
        {
            Poder = Nivel * 8 + 20;

            return Poder;
        }
        
         public override void ExibirStatus()
        {
            Console.WriteLine($"Seu personagem tem nome: {Nome} e nivel: {Nivel} e seu poder é {Poder}");
        }
    }
}