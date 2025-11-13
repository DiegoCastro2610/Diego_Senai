namespace Atividade3_Interface;

class Program
{
    static void Main(string[] args)
    {
        IAnimal c = new Cachorro();
        IAnimal g = new Gato();

        c.EmitirSom();
        g.EmitirSom();
    }
}
