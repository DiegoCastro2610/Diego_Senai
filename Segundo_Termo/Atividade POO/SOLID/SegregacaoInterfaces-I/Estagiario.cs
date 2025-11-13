using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegregacaoInterfaces_I
{
    public class Estagiario : ITrabalhador
    {
        public void Trabalhar() => Console.WriteLine("Estagiario Trabalhando");
    }
}