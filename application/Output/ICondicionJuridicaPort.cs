using Domain.Model;

namespace Application.Output
{
    public interface ICondicionJuridicaPort
    {
        Task<List<CondicionJuridicaModel>> GetAll(ParamBusqueda param);
    }
}
