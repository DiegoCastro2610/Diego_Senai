namespace Atividade27_10_2025;

class Program
{
    static void Main(string[] args)
    {
        //sem construtor
        /*
        Livro NovoLivro = new Livro();

        Console.WriteLine($"Titulo: {NovoLivro.Titulo}");
        Console.WriteLine($"Ano: {NovoLivro.AnoPublicacao}");
        Console.WriteLine($"Disponivel: {NovoLivro.EstaDisponivel}");

        // colocando valores manualmente
        NovoLivro.Titulo = "O poder da Construtor";
        NovoLivro.Autor = "Parceiro do programa";
        NovoLivro.AnoPublicacao = 2025;
        NovoLivro.Preco = 59.90;
        NovoLivro.EstaDisponivel = true;
        */

        //Com construtor
        Console.WriteLine(">>> Sistema de controle de biblioteca <<<");

        //Criando objeto novo com construtor
        Livro livro1 = new Livro("A arte da guerra", "Sun Tzu", 1950, 45.90);
        Livro livro2 = new Livro("Dom Casmurro", "Machado de Assis", 1899, 30.50);

        // interacao com os livros - Emprestar / Ver detalhes

        Console.WriteLine("Interagindo com o Livro1");
        livro1.ExibirDetalhes();
        livro1.Emprestar();
        livro1.ExibirDetalhes();
        livro1.Emprestar();

        Console.WriteLine("\n Interagindo com o Livro2");
        livro2.ExibirDetalhes();
        livro2.Preco = 32.99;
        Console.WriteLine($"Atualizacao de preco: {livro2.Titulo} ajustado para R$ {livro2.Preco:F2}");
        livro2.ExibirDetalhes();
    }
}
