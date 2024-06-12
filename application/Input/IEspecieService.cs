using Domain.Model;

namespace Application.Input
{
    public interface IEspecieService
    {
        Task<List<EspecieModel>> GetAll(ParamBusqueda param);
    }
}
