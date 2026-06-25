using Sistema_Gestor_Obras_PagesFamilia.Models;
using Sistema_Gestor_Obras_PagesFamilia.Repositories;

namespace Sistema_Gestor_Obras_PagesFamilia.Services;

public class MaterialService : IMaterialService
{
    private readonly IMaterialRepository _materialRepository;

    public MaterialService(IMaterialRepository materialRepository)
    {
        _materialRepository = materialRepository;
    }

    public Task<IEnumerable<Material>> ObtenerTodosAsync(bool soloActivos = true) =>
        _materialRepository.GetAllAsync(soloActivos);

    public Task<Material?> ObtenerPorIdAsync(int id) =>
        _materialRepository.GetByIdWithDetailsAsync(id);

    public async Task<(bool Success, string? Error)> CrearAsync(Material material)
    {
        var error = await ValidarAsync(material);
        if (error != null) return (false, error);

        material.Activo = true;
        await _materialRepository.AddAsync(material);
        return (true, null);
    }

    public async Task<(bool Success, string? Error)> ActualizarAsync(Material material)
    {
        var existente = await _materialRepository.GetByIdAsync(material.IdMaterial);
        if (existente == null) return (false, "El material no existe.");

        var error = await ValidarAsync(material, existente.IdMaterial);
        if (error != null) return (false, error);

        existente.Nombre = material.Nombre;
        existente.Unidad = material.Unidad;
        _materialRepository.Update(existente);
        return (true, null);
    }

    public async Task<(bool Success, string? Error)> DarDeBajaAsync(int id)
    {
        var material = await _materialRepository.GetByIdAsync(id);
        if (material == null) return (false, "El material no existe.");
        if (material.Activo == false) return (false, "El material ya está dado de baja.");

        material.Activo = false;
        _materialRepository.Update(material);
        return (true, null);
    }

    private async Task<string?> ValidarAsync(Material material, int idPropio = 0)
    {
        if (string.IsNullOrWhiteSpace(material.Nombre))
            return "El nombre es obligatorio.";

        if (string.IsNullOrWhiteSpace(material.Unidad))
            return "La unidad es obligatoria.";

        var existe = await _materialRepository.AnyAsync(
            m => m.Nombre == material.Nombre && m.IdMaterial != idPropio);
        if (existe)
            return "Ya existe un material con ese nombre.";

        return null;
    }
}
