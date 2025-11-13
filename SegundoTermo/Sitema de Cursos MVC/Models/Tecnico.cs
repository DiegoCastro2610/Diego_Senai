
namespace Sitema_de_Cursos_MVC.Models
{
    public class Tecnico : Curso
    {
        // métodos de sobrecarga
        public Tecnico() { }

        public Tecnico(string nomeConstrutor, int horasConstrutor) : base(nomeConstrutor, horasConstrutor) { }

        // método de sobrescrita
        public override double CalcularPreco()
        {
            return Horas * 20;
        }
    }
}