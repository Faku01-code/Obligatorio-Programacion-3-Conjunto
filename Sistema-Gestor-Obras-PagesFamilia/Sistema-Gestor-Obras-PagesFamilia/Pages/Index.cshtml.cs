using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sistema_Gestor_Obras_PagesFamilia.Data;

namespace Sistema_Gestor_Obras_PagesFamilia.Pages
{
    public class IndexModel : PageModel
    {
        private readonly PagesFamiliaContext _context;

        public string AppNombre { get; private set; } = "Pages & Familia";
        public string AppSubtitulo { get; private set; } = "Sistema de Gestión de Obra";

        public int CantidadClientes { get; set; }

        public IndexModel(PagesFamiliaContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            CantidadClientes = _context.Clientes.Count();
        }
    }
}
