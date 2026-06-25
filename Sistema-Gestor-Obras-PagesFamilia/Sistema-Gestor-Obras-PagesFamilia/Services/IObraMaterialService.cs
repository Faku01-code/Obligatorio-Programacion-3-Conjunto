using Sistema_Gestor_Obras_PagesFamilia.Models;

namespace Sistema_Gestor_Obras_PagesFamilia.Services;

public interface IObraMaterialService
{
    Task<IEnumerable<ObraMaterial>> ObtenerPorObraAsync(int obraId);
    Task<IEnumerable<ObraMaterial>> ObtenerPorMaterialAsync(int materialId);
    Task<ObraMaterial?> ObtenerPorIdAsync(int id);
    Task<(bool Success, string? Error)> CrearAsync(ObraMaterial obraMaterial);
    Task<(bool Success, string? Error)> EliminarAsync(int id);
}
