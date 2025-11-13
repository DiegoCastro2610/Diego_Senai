namespace Atividade_POO;

public class Program
    {
        static void Main(string[] args)
        {
            Pessoa p = new Pessoa
            {
                Nome = "Diego",
                Idade = 17
            };

            Aluno a = new Aluno
            {
                Nome = "Guilherme",
                Idade = 20,
                Curso = "DEV"
            };
            p.Apresentar();
            a.Apresentar();
        }
    }

