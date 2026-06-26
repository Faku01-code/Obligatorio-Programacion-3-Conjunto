using Sistema_Gestor_Obras_PagesFamilia.Models;
using Sistema_Gestor_Obras_PagesFamilia.Repositories;
using Sistema_Gestor_Obras_PagesFamilia.ViewModels;

namespace Sistema_Gestor_Obras_PagesFamilia.Services;

public class MovimientoFinService : IMovimientoFinService
{
    private readonly IMovimientoFinRepository _movimientoFinRepository;
    private readonly IRepository<CategoriaMov> _categoriaRepository;

    public MovimientoFinService(
        IMovimientoFinRepository movimientoFinRepository,
        IRepository<CategoriaMov> categoriaRepository)
    {
        _movimientoFinRepository = movimientoFinRepository;
        _categoriaRepository = categoriaRepository;
    }

    public Task<IEnumerable<MovimientoFin>> ObtenerTodosAsync() =>
        _movimientoFinRepository.GetAllWithDetailsAsync();

    public Task<IEnumerable<MovimientoFin>> ObtenerPorObraAsync(int obraId) =>
        _movimientoFinRepository.GetByObraIdAsync(obraId);

    public Task<MovimientoFin?> ObtenerPorIdAsync(int id) =>
        _movimientoFinRepository.GetByIdWithDetailsAsync(id);

    public async Task<(bool Success, string? Error)> CrearAsync(MovimientoFinFormViewModel vm, int usuarioId)
    {
        var categoria = await _categoriaRepository.GetByIdAsync(vm.IdCategoria);
        if (categoria == null)
            return (false, "Categoría no encontrada.");

        var movimiento = new MovimientoFin
        {
            IdObra = vm.IdObra,
            IdCategoria = vm.IdCategoria,
            Monto = vm.Monto,
            Fecha = vm.Fecha,
            Descripcion = vm.Descripcion,
            CreadoPor = usuarioId,
            FechaCreacion = DateTime.Now
        };

        await _movimientoFinRepository.AddAsync(movimiento);
        return (true, null);
    }

    public async Task<(bool Success, string? Error)> EliminarAsync(int id)
    {
        var movimiento = await _movimientoFinRepository.GetByIdWithDetailsAsync(id);
        if (movimiento == null)
            return (false, "Movimiento no encontrado.");

        if (movimiento.Compra != null)
            return (false, "Este movimiento fue generado automáticamente por una compra. Eliminá la compra para borrarlo.");

        _movimientoFinRepository.Remove(movimiento);
        return (true, null);
    }

    public async Task<(decimal TotalIngresos, decimal TotalEgresos)> ObtenerResumenGlobalAsync()
    {
        var todos = await _movimientoFinRepository.GetAllWithDetailsAsync();
        return Calcular(todos);
    }

    public async Task<(decimal TotalIngresos, decimal TotalEgresos)> ObtenerResumenPorObraAsync(int obraId)
    {
        var movimientos = await _movimientoFinRepository.GetByObraIdAsync(obraId);
        return Calcular(movimientos);
    }

    private static (decimal, decimal) Calcular(IEnumerable<MovimientoFin> movimientos)
    {
        var ingresos = movimientos
            .Where(m => m.IdCategoriaNavigation?.Tipo == "INGRESO")
            .Sum(m => m.Monto);
        var egresos = movimientos
            .Where(m => m.IdCategoriaNavigation?.Tipo == "EGRESO")
            .Sum(m => m.Monto);
        return (ingresos, egresos);
    }
}
