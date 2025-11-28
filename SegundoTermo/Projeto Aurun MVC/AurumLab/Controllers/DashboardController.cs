using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AurumLab.Data;
using AurumLab.Models;
using AurumLab.Models;

namespace AurumLab.Controllers
{
    public class DashboardController : Controller
    {
        public AppDbContext _context;
        public DashboardController (AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetInt32("UsuarioId") == null)
            {
                return RedirectToAction ("Index", "Login");
            }

            var usuarioId = HttpContext.Session.GetInt32("UsuarioId");

            var usuario = _context.Usuarios.FirstOrDefault(usuario => usuario.IdUsuario == usuarioId);

            // Tipo Disqpositivo - JOIN + Agrupamento
            // consutar a tabela dispositivo atraves da ViewModel

            //SELECT * FROM Dispositivos
            var dispositivosPorTipo = _context.Dispositivos.Join(
                _context.TipoDispositivos,
                dispositivo => dispositivo.IdTipoDispositivo,
             tipoDispositivo => tipoDispositivo.IdTipoDispositivo,
              (dispositivo, tipoDispositivo) => new {dispositivo, tipoDispositivo.Nome}
              ).GroupBy(item => item.Nome).Select(grupo => new ItemAgrupado
              {
                Nome = grupo.Key, 
                Quantidade = grupo.Count()
                }).ToList();
            var locais = _context.LocalDispositivos.OrderBy(local => local.Nome).ToList();

            DashboardViewModel viewModel = new DashboardViewModel
            {
                NomeUsuario = usuario?.NomeUsuario ?? "Usuario",
                //FotoUsuario = "/assets/img/img-perfil.png",

                FotoUsuario = usuario?.Foto != null
                                ? $"data:image/*;base64,{Convert.ToBase64String(usuario.Foto)}"
                                : "/assets/img/img-perfil.png",

                TotalDispositivos = _context.Dispositivos.Count(),
                TotalAtivos = _context.Dispositivos.Count(dispositivos => dispositivos.SituacaoOperacional == "Operando"),
                TotalEmManutencao = _context.Dispositivos.Count(dispositivos => dispositivos.SituacaoOperacional == "Em Manutencao"),
                TotalInoperantes = _context.Dispositivos.Count(dispositivos => dispositivos.SituacaoOperacional == "Inoperante"),

                DispositivosPorTipo = dispositivosPorTipo,
                Locais = locais
            };

            return View(viewModel);
        }
        
    }
}