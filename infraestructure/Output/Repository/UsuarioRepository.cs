using AutoMapper;
using Dapper;
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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IConfiguration _configuracion;
        private readonly IMapper _mapper;
        public UsuarioRepository(IConfiguration configuracion, IMapper mapper)
        {
            _configuracion = configuracion;
            _mapper = mapper;
        }
        public async Task<ProductorAgrarioEntity> getListUsuarios(string filtro)
        {
            string strCon = _configuracion.GetSection("DatabaseSettings")["ConnectionString1"];



            using (var con = new OracleConnection(strCon))
            {
                try
                {
                    // Se abre la conexión
                    con.Open();

                    using (var com = new OracleCommand())
                    {
                        // Al comando se le asigna la conexión
                        com.Connection = con;

                        // Se le indica el tipo de comando y el nombre
                        com.CommandType = CommandType.StoredProcedure;
                        com.CommandText = "NombrePaquete.NombreProcedimientoAlmacenado";
                        com.BindByName = true;

                        // Se añaden los parámetros de entrada
                        OracleParameter param1 = com.Parameters.Add(new OracleParameter("PARAM1", OracleDbType.Decimal, ParameterDirection.Input));
                        param1.Value = filtro != null ? (object)Convert.ToString(filtro) : DBNull.Value;
                       

                        // Se ejecuta el procedimiento y se comprueba la salida
                        var registrosAfectados = com.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR : " + ex.Message);
                }
                finally
                {
                    // Nos aseguramos de cerrar la conexión en caso de error
                    con.Close();
                }
            }





        }
    }
}
