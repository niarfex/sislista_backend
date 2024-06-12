using Application.Input;
using Application.Output;
using Domain.Exceptions;
using Domain.Model;

namespace Application.Service
{
    public class UbigeoService:IUbigeoService
    {
        private readonly IUbigeoPort _ubigeoPort;

        public UbigeoService(IUbigeoPort ubigeoPort)
        {
            _ubigeoPort = ubigeoPort ?? throw new ArgumentNullException(nameof(ubigeoPort));
        }     
        public async Task<List<UbigeoModel>> GetAll(string param)
        {
            var ubigeos = await _ubigeoPort.GetAll(param);
            if (ubigeos == null)
            {
                throw new NotDataFoundException("Número de documento de identidad no encontrado");
                
            }

            return ubigeos;
        }
    }
}
