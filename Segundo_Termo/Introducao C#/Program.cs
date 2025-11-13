namespace Introducao_C_;

class Program
{
    
    static void Main(string[] args)
    {
        /*
         string numero1;
         string numero2;
         int numero1int;
         int numero2int;
         int soma;
         int menos;
         int multiplicacao;
         int divisao;
        //menu
        Console.WriteLine("digite se voce quer 1-Soma, 2-Subtracao, 3-Multipicacao, 4-Divicao");
        string selecao = Console.ReadLine();
        int selecaoint=Convert.ToInt32(selecao);
        switch(selecaoint)
        {
           case 1: Console.WriteLine("digite o primeiro digito");
           numero1 = Console.ReadLine();
           Console.WriteLine("digite o segundo digito");
           numero2 = Console.ReadLine();
           numero1int=Convert.ToInt32(numero1);
           numero2int=Convert.ToInt32(numero2);
           soma = numero1int + numero2int;
           Console.WriteLine(soma);
           break;
           case 2:Console.WriteLine("digite o primeiro digito");
            numero1 = Console.ReadLine();
            Console.WriteLine("digite o segundo digito");
           numero2 = Console.ReadLine();
           numero1int=Convert.ToInt32(numero1);
           numero2int=Convert.ToInt32(numero2);
           menos = numero1int - numero2int;
           Console.WriteLine(menos);
           break;
           case 3:Console.WriteLine("digite o primeiro digito");
           numero1 = Console.ReadLine();
           Console.WriteLine("digite o segundo digito");
           numero2 = Console.ReadLine();
           numero1int=Convert.ToInt32(numero1);
           numero2int=Convert.ToInt32(numero2);
           multiplicacao = numero1int * numero2int;
           Console.WriteLine(multiplicacao);
           break;
           case 4:Console.WriteLine("digite o primeiro digito");
            numero1 = Console.ReadLine();
            Console.WriteLine("digite o segundo digito");
           numero2 = Console.ReadLine();
           numero1int=Convert.ToInt32(numero1);
           numero2int=Convert.ToInt32(numero2);
           divisao = numero1int / numero2int;
           Console.WriteLine(divisao);
           break;
        
        }
        */
        //sequencia de fibonate

        Console.WriteLine("digite ate que numeno vc quer a sequencia de fibonate");
        string sequencia = Console.ReadLine();
        int sequenciaint=Convert.ToInt32(sequencia);
        double resultado;
        double valor1 = 0;
        double valor2 = 1;

        for(int i = 1; i <= sequenciaint; i++){
          resultado = valor1 + valor2;
          Console.WriteLine(resultado);
          valor1 = valor2;
          valor2 = resultado;
        }

    }
}
