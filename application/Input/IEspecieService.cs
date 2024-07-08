using Domain.Model;

namespace Application.Input
{
    public interface IEspecieService
    {
        Task<List<EspecieModel>> GetAll(string param);
        Task<EspecieModel> GetEspeciexId(long id);
        Task<long> CreateEspecie(EspecieModel model);
        Task<long> DeleteEspeciexId(long id);
        Task<long> ActivarEspeciexId(long id);
        Task<long> DesactivarEspeciexId(long id);
    }
}
