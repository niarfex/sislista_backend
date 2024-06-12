using Domain.Model;

namespace Application.Input
{
    public interface ICultivoService
    {
        Task<List<CultivoModel>> GetAll(ParamBusqueda param);
    }
}
