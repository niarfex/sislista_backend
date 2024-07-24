﻿using Domain.Model;

namespace Application.Output
{
    public interface IGestionRegistroPort
    {
        Task<List<GestionRegistroModel>> GetAll(string param, string uuid);
        Task<GestionRegistroModel> GetGestionRegistroxUUID(string uuid);
        Task<GestionRegistroModel> GetUUIDCuestionario(string numDoc, long idPeriodo);
        Task<List<ArchivoModel>> GetArchivosCuestionario(string uuid);
        Task<string> CreateCuestionario(GestionRegistroModel model);
    }
}
