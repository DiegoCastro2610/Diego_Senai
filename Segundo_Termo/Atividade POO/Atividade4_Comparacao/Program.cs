namespace Atividade4_Comparacao;

class Program
{
    static void Main(string[] args)
    {
       Programador dev = new Programador {Nome = "Lucas" };
       dev.Trabalhar();
       dev.ExecultarTarefa();
       
       Pessoa p = new Pessoa { Nome = "Pedro"};
       p.Falar();
    }
}
