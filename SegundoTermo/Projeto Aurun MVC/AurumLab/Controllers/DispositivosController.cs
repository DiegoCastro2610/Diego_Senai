using AurumLab.Data;
using AurumLab.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace AurumLab.Controllers
{
    public class DispositivosController : Controller
    {
        private readonly AppDbContext _context;

        public DispositivosController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string? busca = null, int? tipoId = null, int? localId = null)
        {
            int? usuarioId = HttpContext.Session.GetInt32("UsuarioId");
            if (usuarioId == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var usuario = _context.Usuarios.FirstOrDefault(u => u.IdUsuario == usuarioId);

            if (usuario.RegraId != 2)
            {
                TempData["Erro"] = "Acesso permitido somente para professores";
                return RedirectToAction("Dashboard", "Dashboard");
            }
            //include funciona que nem o join so que de forma mais simples
            //uso quando quero agrupar items por exemplo
            var selectBusca = _context.Dispositivos.Include(dispositivo => dispositivo.IdTipoDispositivoNavigation).Include(dispositivo => dispositivo.IdLocalNavigation).AsQueryable();

            //filtros
            if (!string.IsNullOrWhiteSpace(busca))
            {
                selectBusca = selectBusca.Where(Dispositivo => Dispositivo.Nome.Contains(busca));

            }

            if (tipoId.HasValue)
            {
                selectBusca = selectBusca.Where(dispositivo => dispositivo.IdTipoDispositivo == tipoId.Value);
            }

            if (localId.HasValue)
            {
                selectBusca = selectBusca.Where(dispositivo => dispositivo.IdLocal == localId.Value);
            }

            DispositivosViewModel viewModel = new DispositivosViewModel
            {
                NomeUsuario = usuario.NomeUsuario ?? "Usuario",
                FotoUsuario = usuario.Foto != null ? $"data:image/*;base64,{Convert.ToBase64String(usuario.Foto)}" : "/assets/img/img-perfil.png",
                Dispositivos = selectBusca.ToList(),
                Tipos = _context.TipoDispositivos.ToList(),
                Locais = _context.LocalDispositivos.ToList(),

                Busca = busca,
                TipoIdSelecionado = tipoId,
                LocalIdSelecionado = localId


            };

            return View(viewModel);
        }

        [HttpGet] //mostra somente a visualizacao do dispositivo pelo id
        public IActionResult Editar(int id)
        {
            int? usuarioId = HttpContext.Session.GetInt32("UsuarioId");

            if (usuarioId == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var dispositivo = _context.Dispositivos.FirstOrDefault(d => d.IdDispositivo == id);

            if (dispositivo == null)
            {
                return NotFound();
            }

            EditarDispositivoViewModel vm = new EditarDispositivoViewModel
            {
                IdDispositivo = dispositivo.IdDispositivo,
                Nome = dispositivo.Nome,
                IdTipoDispositivo = dispositivo.IdTipoDispositivo,
                IdLocal = dispositivo.IdLocal,
                DataUltimaManutencao = dispositivo.DataUltimaManutencao,

                Tipos = _context.TipoDispositivos.ToList(),
                Locais = _context.LocalDispositivos.ToList()
            };
            return View("Editar", vm);

        }

        [HttpPost]

        public IActionResult Editar(EditarDispositivoViewModel vm)
        {
            int? usuarioId = HttpContext.Session.GetInt32("UsuarioId");

            if (usuarioId == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var dispositivo = _context.Dispositivos.FirstOrDefault(d => d.IdDispositivo == vm.IdDispositivo);

            if (dispositivo == null)
            {
                return NotFound();
            }

            dispositivo.Nome = vm.Nome;
            dispositivo.IdTipoDispositivo = vm.IdTipoDispositivo;
            dispositivo.IdLocal = vm.IdLocal;
            dispositivo.DataUltimaManutencao = vm.DataUltimaManutencao;

            _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpPost]

        public IActionResult Excluir(int id)
        {
            var dispositivo = _context.Dispositivos.FirstOrDefault(d => d.IdDispositivo == id);

            if (dispositivo == null)
            {
                return NotFound();
            }

            _context.Dispositivos.Remove(dispositivo);
            _context.SaveChangesAsync();

            TempData["Sucesse"] = "Dispositivo Excluido com sucesso";
            return RedirectToAction("Index");
        }

    }
}