using Sistema_Gestor_Obras_PagesFamilia.Models;
using Sistema_Gestor_Obras_PagesFamilia.ViewModels;

namespace Sistema_Gestor_Obras_PagesFamilia.Services;

public interface ICompraService
{
    Task<Compra?> ObtenerPorIdAsync(int id);
    Task<(bool Success, string? Error)> CrearAsync(CompraFormViewModel vm, int usuarioId);
    Task<(bool Success, string? Error)> EliminarAsync(int id);
}
