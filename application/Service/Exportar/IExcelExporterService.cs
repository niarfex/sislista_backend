using Domain.Model;


namespace Application.Service.Exportar
{
    public interface IExcelExporterService
    {
        Task<byte[]> ExportToExcel<T>(List<T> source);
    }
}
