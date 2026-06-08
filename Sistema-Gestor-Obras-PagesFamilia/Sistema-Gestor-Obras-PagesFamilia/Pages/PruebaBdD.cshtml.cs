using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sistema_Gestor_Obras_PagesFamilia.Data;
using Sistema_Gestor_Obras_PagesFamilia.Models;

namespace Sistema_Gestor_Obras_PagesFamilia.Pages.Obras
{
    public class PruebaBdDModel : PageModel
    {
        private readonly PagesFamiliaContext _context;

        public PruebaBdDModel(PagesFamiliaContext context)
        {
            _context = context;
        }

        public IList<Obra> Obras = new List<Obra>();

        [BindProperty]
        public Obra Obra { get; set; } = default!;

        public SelectList Clientes { get; set; } = default!;
        public SelectList Estados { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("Obra.IdClienteNavigation");
            ModelState.Remove("Obra.IdEstadoNavigation");
            ModelState.Remove("Obra.CreadoPorNavigation");

            if (!ModelState.IsValid)
            {
                Obras = await _context
                    .Obras.Include(o => o.IdClienteNavigation)
                    .Include(o => o.IdEstadoNavigation)
                    .ToListAsync();

                return Page();
            }

            _context.Obras.Add(Obra);
            await _context.SaveChangesAsync();

            return RedirectToPage("./PruebaBdD");
        }

        public async Task OnGetAsync()
        {
            await CargarDatosBase();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var obra = await _context.Obras.FindAsync(id);

            if (obra != null)
            {
                _context.Obras.Remove(obra);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./PruebaBdD");
        }

        private async Task CargarDatosBase()
        {
            Obras = await _context
                .Obras.Include(o => o.IdClienteNavigation)
                .Include(o => o.IdEstadoNavigation)
                .ToListAsync();

            Clientes = new SelectList(await _context.Clientes.ToListAsync(), "IdCliente", "Nombre");
            Estados = new SelectList(
                await _context.EstadoObras.ToListAsync(),
                "IdEstado",
                "Nombre"
            );
        }
    }
}
