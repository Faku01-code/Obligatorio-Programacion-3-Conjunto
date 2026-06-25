using Sistema_Gestor_Obras_PagesFamilia.Models;
using Sistema_Gestor_Obras_PagesFamilia.Repositories;

namespace Sistema_Gestor_Obras_PagesFamilia.Services;

public class ObraMaterialService : IObraMaterialService
{
    private readonly IObraMaterialRepository _obraMaterialRepository;

    public ObraMaterialService(IObraMaterialRepository obraMaterialRepository)
    {
        _obraMaterialRepository = obraMaterialRepository;
    }

    public Task<IEnumerable<ObraMaterial>> ObtenerPorObraAsync(int obraId) =>
        _obraMaterialRepository.GetByObraIdAsync(obraId);

    public Task<IEnumerable<ObraMaterial>> ObtenerPorMaterialAsync(int materialId) =>
        _obraMaterialRepository.GetByMaterialIdAsync(materialId);

    public Task<ObraMaterial?> ObtenerPorIdAsync(int id) =>
        _obraMaterialRepository.GetByIdWithDetailsAsync(id);

    public async Task<(bool Success, string? Error)> CrearAsync(ObraMaterial obraMaterial)
    {
        if (obraMaterial.CantRequerida < 0)
            return (false, "La cantidad requerida no puede ser negativa.");

        var existe = await _obraMaterialRepository.ExisteAsync(obraMaterial.IdObra, obraMaterial.IdMaterial);
        if (existe)
            return (false, "Este material ya está registrado para la obra seleccionada.");

        await _obraMaterialRepository.AddAsync(obraMaterial);
        return (true, null);
    }

    public async Task<(bool Success, string? Error)> EliminarAsync(int id)
    {
        var om = await _obraMaterialRepository.GetByIdAsync(id);
        if (om == null) return (false, "El registro no existe.");

        if (await _obraMaterialRepository.TieneComprasAsync(id))
            return (false, "No se puede quitar el material porque tiene compras registradas.");

        _obraMaterialRepository.Remove(om);
        return (true, null);
    }
}
