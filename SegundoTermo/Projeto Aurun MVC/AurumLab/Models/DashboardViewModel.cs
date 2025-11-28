using AurumLab.Models;
using System;
using System.Collections.Generic;

namespace AurumLab.Models
{
    public class DashboardViewModel 
    {
        public int TotalDispositivos {get; set;}
        public int TotalAtivos {get; set;}
        public int TotalEmManutencao {get; set;}
        public int TotalInoperantes {get; set;}

        public string NomeUsuario {get; set;}
        public string FotoUsuario {get; set;}

        public List<ItemAgrupado> DispositivosPorTipo {get; set;}
        public List<LocalDispositivo> Locais {get; set;}
    }
}