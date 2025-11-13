using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade3_Interface
{
    public class Cachorro : IAnimal
    {
        public void EmitirSom() => Console.WriteLine("Au au!");
    }
}