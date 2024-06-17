using AutoMapper;
using Dapper;
using Domain.Model;
using Infra.MarcoLista.Contextos;
using Infra.MarcoLista.GeneralSQL;
using Infra.MarcoLista.Output.Entity;
using Infra.MarcoLista.Output.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Xml.Linq;
using static Dapper.SqlMapper;

namespace Infra.MarcoLista.Output.Repository
{
    public class OrganizacionRepository : IOrganizacionRepository
    {
        private MarcoListaContexto _db = new MarcoListaContexto();
        private readonly IConfiguration _configuracion;
        private readonly IMapper _mapper;
        //private DBOracle dBOracle = new DBOracle();
        public OrganizacionRepository(IConfiguration configuracion, IMapper mapper)
        {
            _configuracion = configuracion;
            _mapper = mapper;
        }
        public async Task<List<OrganizacionEntity>> GetAll(string param)
        {
            return _db.Organizacion.ToList();
        }
        public async Task<OrganizacionEntity> GetOrganizacionxId(long id)
        {
            return _db.Organizacion.Where(x => x.Id==id).FirstOrDefault();
        }
        public async Task<long> CreateOrganizacion(OrganizacionModel model)
        {
            if (model.Id > 0)
            {
                var objOrganizacion = _db.Organizacion.Where(x => x.Id == model.Id).FirstOrDefault();
                objOrganizacion.IdTipoOrganizacion = model.IdTipoOrganizacion;
                objOrganizacion.NumeroDocumento = model.NumeroDocumento;
                objOrganizacion.Organizacion = model.Organizacion;
                objOrganizacion.DireccionFiscal = model.DireccionFiscal;
                objOrganizacion.IdDepartamento = model.IdDepartamento;
                objOrganizacion.Telefono = model.Telefono;
                objOrganizacion.PaginaWeb = model.PaginaWeb;
                objOrganizacion.CorreoElectronico = model.CorreoElectronico;
                objOrganizacion.FechaActualizacion = DateTime.Now;
                objOrganizacion.UsuarioActualizacion = "";
                _db.Organizacion.Update(objOrganizacion);
                _db.SaveChanges();
                return objOrganizacion.Id;
            }
            else
            {
                var objOrganizacion = new OrganizacionEntity()
                {
                    IdTipoOrganizacion = model.IdTipoOrganizacion,
                    NumeroDocumento = model.NumeroDocumento,
                    Organizacion = model.Organizacion,
                    DireccionFiscal = model.DireccionFiscal,
                    IdDepartamento = model.IdDepartamento,
                    Telefono = model.Telefono,
                    PaginaWeb = model.PaginaWeb,
                    CorreoElectronico = model.CorreoElectronico,
                    Estado = 1,
                    FechaRegistro = DateTime.Now,
                    UsuarioCreacion = ""
                };
                _db.Organizacion.Add(objOrganizacion);
                _db.SaveChanges();
                return objOrganizacion.Id;
            }
            
            
        }
        public async Task<OrganizacionEntity> updateOrganizacion()
        {
            return null;
        }
        public async Task<bool> deleteOrganizacion()
        {
            return false;
        }
    }
}
