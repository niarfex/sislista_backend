using AutoMapper;
using Dapper;
using Domain.Model;
using Infra.MarcoLista.Contextos;
using Infra.MarcoLista.GeneralSQL;
using Infra.MarcoLista.Input.Dto;
using Infra.MarcoLista.Output.Entity;
using Infra.MarcoLista.Output.Repository;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Reflection.Metadata;
using System.Xml.Linq;
using static Dapper.SqlMapper;

namespace Infra.MarcoLista.Output.Repository
{

    public class UbigeoRepository: IUbigeoRepository
    {
        private MarcoListaContexto _db = new MarcoListaContexto();
        private readonly IConfiguration _configuracion;
        private readonly IMapper _mapper;

        public UbigeoRepository(IConfiguration configuracion, IMapper mapper)
        {
            _configuracion = configuracion;
            _mapper = mapper;
        }
        public async Task<List<UbigeoEntity>> GetAll(string param)
        {
            return _db.Ubigeo.ToList();
        }      
        public async Task<UbigeoEntity> getUbigeo()
        {
            return null;
        }
        public async Task<UbigeoEntity> createUbigeo()
        {
            return null;
        }
        public async Task<UbigeoEntity> updateUbigeo()
        {
            return null;
        }
        public async Task<bool> deleteUbigeo()
        {
            return false;
        }

    }
}
