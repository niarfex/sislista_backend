using Domain.Model;

namespace Application.Input
{
    public interface ICondicionJuridicaService
    {
        Task<List<CondicionJuridicaModel>> GetAll(ParamBusqueda param);
    }
}
