using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaFuncionariosMVC.Models
{
    public abstract class Funcionario
    {
        [Key]
        public int Id {get;set;}

        [Required] // vai obrigar a colocar algo

        public string Nome {get;set;} = string.Empty;

        [Range(0,10000)]// fala que o valor atribuido a SalarioBase tem que ser entre 0 a 10000
        
        public double SalarioBase{get;set;}

        public Funcionario() {}

        public Funcionario(string CNome, double CSalarioBase)
        {
            Nome = CNome;
            SalarioBase = CSalarioBase;
        }

        public abstract double CalcularSalario();

    }
}