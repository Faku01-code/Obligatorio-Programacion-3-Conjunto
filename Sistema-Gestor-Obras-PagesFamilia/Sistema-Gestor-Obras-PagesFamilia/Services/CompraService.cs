using Sistema_Gestor_Obras_PagesFamilia.Models;
using Sistema_Gestor_Obras_PagesFamilia.Repositories;
using Sistema_Gestor_Obras_PagesFamilia.ViewModels;

namespace Sistema_Gestor_Obras_PagesFamilia.Services;

public class CompraService : ICompraService
{
    private readonly ICompraRepository _compraRepository;
    private readonly IObraMaterialRepository _obraMaterialRepository;
    private readonly IRepository<MovimientoFin> _movimientoRepository;
    private readonly IRepository<CategoriaMov> _categoriaRepository;

    public CompraService(
        ICompraRepository compraRepository,
        IObraMaterialRepository obraMaterialRepository,
        IRepository<MovimientoFin> movimientoRepository,
        IRepository<CategoriaMov> categoriaRepository)
    {
        _compraRepository = compraRepository;
        _obraMaterialRepository = obraMaterialRepository;
        _movimientoRepository = movimientoRepository;
        _categoriaRepository = categoriaRepository;
    }

    public Task<Compra?> ObtenerPorIdAsync(int id) =>
        _compraRepository.GetByIdWithDetailsAsync(id);

    public async Task<(bool Success, string? Error)> CrearAsync(CompraFormViewModel vm, int usuarioId)
    {
        if (vm.Cantidad <= 0)
            return (false, "La cantidad debe ser mayor a cero.");

        if (vm.CostoUnitario < 0)
            return (false, "El costo unitario no puede ser negativo.");

        var obraMaterial = await _obraMaterialRepository.GetByIdWithDetailsAsync(vm.IdObraMaterial);
        if (obraMaterial == null)
            return (false, "El material de obra no existe.");

        var categorias = await _categoriaRepository.GetAllAsync();
        var categoria = categorias.FirstOrDefault(c => c.Nombre == "Compra de material" && c.Tipo == "EGRESO");
        if (categoria == null)
            return (false, "No se encontró la categoría de compra de material en el sistema.");

        var monto = vm.Cantidad * vm.CostoUnitario;
        var descripcionAuto = $"Compra: {obraMaterial.IdMaterialNavigation.Nombre} — {obraMaterial.IdObraNavigation.Nombre}";

        var movimiento = new MovimientoFin
        {
            IdObra = obraMaterial.IdObra,
            IdCategoria = categoria.IdCategoria,
            Monto = monto,
            Fecha = vm.Fecha,
            Descripcion = string.IsNullOrWhiteSpace(vm.Descripcion) ? descripcionAuto : vm.Descripcion.Trim(),
            CreadoPor = usuarioId,
            FechaCreacion = DateTime.Now
        };

        await _movimientoRepository.AddAsync(movimiento);

        var compra = new Compra
        {
            IdObraMaterial = vm.IdObraMaterial,
            IdMovimiento = movimiento.IdMovimiento,
            Cantidad = vm.Cantidad,
            CostoUnitario = vm.CostoUnitario,
            Fecha = vm.Fecha,
            CreadoPor = usuarioId,
            FechaCreacion = DateTime.Now
        };

        await _compraRepository.AddAsync(compra);
        return (true, null);
    }

    public async Task<(bool Success, string? Error)> EliminarAsync(int id)
    {
        var compra = await _compraRepository.GetByIdWithDetailsAsync(id);
        if (compra == null) return (false, "La compra no existe.");

        var movimiento = compra.IdMovimientoNavigation;

        _compraRepository.Remove(compra);

        if (movimiento != null)
            _movimientoRepository.Remove(movimiento);

        return (true, null);
    }
}
