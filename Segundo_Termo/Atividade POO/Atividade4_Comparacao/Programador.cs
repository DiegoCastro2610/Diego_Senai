using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade4_Comparacao
{
    public class Programador : Funcionario, ITrabalhador
    {
        public override void Trabalhar() => Console.WriteLine($"{Nome} esta programando.");

    public void ExecultarTarefa()=> Console.WriteLine($"{Nome} concluiu uma tarefa");
    }
}