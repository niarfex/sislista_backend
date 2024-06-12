using Domain.Model;

namespace Application.Output
{
    public interface IEspeciePort
    {
        Task<List<EspecieModel>> GetAll(ParamBusqueda param);
    }
}
