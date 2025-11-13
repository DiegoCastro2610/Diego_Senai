
namespace Sitema_de_Cursos_MVC.Models
{
    public class Superior : Curso
    {
        public Superior() { }

        public Superior(string nomeConstrutor, int horasConstrutor) : base(nomeConstrutor, horasConstrutor) { }

        public override double CalcularPreco()
        {
            return Horas * 40;
        }
    }
}