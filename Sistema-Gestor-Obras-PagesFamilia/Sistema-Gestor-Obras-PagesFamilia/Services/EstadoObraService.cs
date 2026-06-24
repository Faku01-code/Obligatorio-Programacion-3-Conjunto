using Sistema_Gestor_Obras_PagesFamilia.Repositories;

namespace Sistema_Gestor_Obras_PagesFamilia.Services;

public class EstadoObraService : IEstadoObraService
{
    private readonly IEstadoObraRepository _estadoObraRepository;

    public EstadoObraService(IEstadoObraRepository estadoObraRepository)
    {
        _estadoObraRepository = estadoObraRepository;
    }

    public Task<IEnumerable<Models.EstadoObra>> ObtenerTodosAsync() =>
        _estadoObraRepository.GetAllOrderedAsync();
}
