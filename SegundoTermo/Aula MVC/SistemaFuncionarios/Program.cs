namespace SistemaFuncionarios;

class Program
{
    static void Main(string[] args)
    {
        List<Funcionario> funcionarios = new List<Funcionario>
        {
            new Gerente("kessia", 5000),
            new Vendedor ("Thiago", 3000)
        };

        foreach(var funcionario in funcionarios)//funcionario passa nos funcionarios um de cada vez e da o ExibirResumo()
        {
            funcionario.ExibirResumo();
        }
    }
}
