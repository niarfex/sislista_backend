﻿using Application.Output;
using AutoMapper;
using Domain.Model;
using Infra.MarcoLista.Output.Repository;

namespace Infra.MarcoLista.Output.Adapter
{
    public class OrganizacionAdapter:IOrganizacionPort
    {
        private readonly IOrganizacionRepository _organizacionRepository;
        private readonly IMapper _mapper;
        public OrganizacionAdapter(IOrganizacionRepository organizacionRepository, IMapper mapper)
        {
            _organizacionRepository = organizacionRepository;
            _mapper = mapper;
        }

        public async Task<List<OrganizacionModel>> GetAll(string param)
        {
            var organizacionEntity = await _organizacionRepository.GetAll(param);

            if (organizacionEntity != null)
            {
                return _mapper.Map<List<OrganizacionModel>>(organizacionEntity);
            }
            else
            {
                return null;
            }
        }
        public async Task<OrganizacionModel> GetOrganizacionxId(long id)
        {
            var organizacionEntity = await _organizacionRepository.GetOrganizacionxId(id);

            if (organizacionEntity != null)
            {
                return _mapper.Map<OrganizacionModel>(organizacionEntity);
            }
            else
            {
                return null;
            }
        }
        public async Task<long> CreateOrganizacion(OrganizacionModel model)
        {
            var organizacionEntity = await _organizacionRepository.CreateOrganizacion(model);

            if (organizacionEntity != null)
            {
                return organizacionEntity;
            }
            else
            {
                return 0;
            }
        }
        public async Task<long> DeleteOrganizacionxId(long id)
        {
            var organizacionEntity = await _organizacionRepository.DeleteOrganizacionxId(id);

            if (organizacionEntity != null)
            {
                return organizacionEntity;
            }
            else
            {
                return 0;
            }
        }
        public async Task<long> ActivarOrganizacionxId(long id)
        {
            var organizacionEntity = await _organizacionRepository.ActivarOrganizacionxId(id);

            if (organizacionEntity != null)
            {
                return organizacionEntity;
            }
            else
            {
                return 0;
            }
        }
        public async Task<long> DesactivarOrganizacionxId(long id)
        {
            var organizacionEntity = await _organizacionRepository.DesactivarOrganizacionxId(id);

            if (organizacionEntity != null)
            {
                return organizacionEntity;
            }
            else
            {
                return 0;
            }
        }
    }
}
