
namespace Atividade_POO;

public class Pessoa
    {
        public string Nome;

        public int Idade;

        public virtual void Apresentar()
        {
            Console.WriteLine($"Ola, meu nome e {Nome} e tenho {Idade} anos");
        }
    }
