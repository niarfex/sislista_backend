using Domain.Model;

namespace Application.Output
{
    public interface ICultivoPort
    {
        Task<List<CultivoModel>> GetAll(ParamBusqueda param);
    }
}
