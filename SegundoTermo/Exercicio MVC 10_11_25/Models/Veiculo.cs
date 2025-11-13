using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Exercicio_MVC_10_11_25.Models
{
    public abstract class Veiculo
    {
        [Key]
        public int Id {get;set;}

        [Required] // vai obrigar a colocar algo

        public string Modelo {get;set;} = string.Empty;
        public double Ano {get;set;}

        public Veiculo() {}

        public Veiculo(string CModelo, double CAno)
        {
            Modelo = CModelo;
            Ano = CAno;
        }

        public abstract double CalcularRevisao();

        public virtual void ExibirResumo()
        {
            Console.WriteLine($"Modelo: {Modelo} e o Ano: {Ano}");
        }
    }
}