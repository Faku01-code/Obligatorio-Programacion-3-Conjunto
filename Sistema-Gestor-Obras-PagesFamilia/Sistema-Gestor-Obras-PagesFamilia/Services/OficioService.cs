using Sistema_Gestor_Obras_PagesFamilia.Models;
using Sistema_Gestor_Obras_PagesFamilia.Repositories;

namespace Sistema_Gestor_Obras_PagesFamilia.Services;

public class OficioService : IOficioService
{
    private readonly IOficioRepository _oficioRepository;

    public OficioService(IOficioRepository oficioRepository)
    {
        _oficioRepository = oficioRepository;
    }

    public Task<IEnumerable<Oficio>> ObtenerTodosAsync() =>
        _oficioRepository.GetAllAsync();
}
