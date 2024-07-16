using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Domain;
using Infra.MarcoLista.Output.Entity;
using Infra.MarcoLista.Configs;
using AutoMapper;

namespace Infra.MarcoLista.Contextos
{
    public class MarcoListaContexto : DbContext
    {
        private string _cadConex = "";
        public MarcoListaContexto(string cadConex)
        {
            _cadConex=cadConex;
        }     
        public DbSet<AnioEntity> Anio { get; set; }
        public DbSet<ArchivoEntity> Archivo { get; set; }
        public DbSet<AuditoriaEntity> Auditoria { get; set; }
        public DbSet<CampoEntity> Campo { get; set; }
        public DbSet<CondicionJuridicaEntity> CondicionJuridica { get; set; }
        public DbSet<EntidadEntity> Entidad { get; set; }
        public DbSet<EspecieEntity> Especie{ get; set; }
        public DbSet<EstadoEntity> Estado { get; set; }
        public DbSet<EtapaEntity> Etapa { get; set; }
        public DbSet<FrecuenciaEntity> Frecuencia { get; set; }
        public DbSet<FundoEntity> Fundo { get; set; }
        public DbSet<GestionRegistroEntity> GestionRegistro { get; set; }
        public DbSet<InformanteEntity> Informante { get; set; }
        public DbSet<LineaProduccionEntity> LineaProduccion { get; set; }
        public DbSet<MarcoListaEntity> MarcoLista { get; set; }
        public DbSet<MenuEntity> Menu { get; set; }
        public DbSet<NotificacionEntity> Notificacion { get; set; }
        public DbSet<OrganizacionEntity> Organizacion { get; set; }
        public DbSet<PanelRegistroEntity> PanelRegistro { get; set; }
        public DbSet<PecuarioEntity> Pecuario { get; set; }
        public DbSet<PerfilEntity> Perfil { get; set; }
        public DbSet<PerfilMenuEntity> PerfilMenu { get; set; }
        public DbSet<PerfilPermisoEntidadEntity> PerfilPermisoEntidad { get; set; }
        public DbSet<PersonaEntity> Permiso { get; set; }
        public DbSet<PersonaEntity> Persona { get; set; }
        public DbSet<PlantillaEntity> Plantilla { get; set; }
        public DbSet<SesionEntity> Sesion { get; set; }
        public DbSet<SistemaPecuarioEntity> SistemaPecuario { get; set; }
        public DbSet<TenenciaEntity> Tenencia { get; set; }
        public DbSet<TipoDocumentoEntity> TipoDocumento { get; set; }
        public DbSet<TipoExplotacionEntity> TipoExplotacion { get; set; }
        public DbSet<TipoInformacionEntity> TipoInformacion { get; set; }
        public DbSet<TipoOrganizacionEntity> TipoOrganizacion { get; set; }
        public DbSet<UsoNoAgricolaEntity> UsoNoAgricola { get; set; }
        public DbSet<UsoTierraEntity> UsoTierra { get; set; }
        public DbSet<UsuarioEntity> Usuario { get; set; }
        public DbSet<UsuarioMarcoListaEntity> UsuarioMarcoLista { get; set; }
        public DbSet<UsuarioPerfilEntity> UsuarioPerfil { get; set; }

        

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseOracle(_cadConex);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new AnioConfig());
            builder.ApplyConfiguration(new ArchivoConfig());
            builder.ApplyConfiguration(new AuditoriaConfig());
            builder.ApplyConfiguration(new CampoConfig());
            builder.ApplyConfiguration(new CondicionJuridicaConfig());
            builder.ApplyConfiguration(new EntidadConfig());
            builder.ApplyConfiguration(new EspecieConfig());
            builder.ApplyConfiguration(new EstadoConfig());
            builder.ApplyConfiguration(new EtapaConfig());
            builder.ApplyConfiguration(new FrecuenciaConfig());
            builder.ApplyConfiguration(new FundoConfig());
            builder.ApplyConfiguration(new GestionRegistroConfig());
            builder.ApplyConfiguration(new InformanteConfig());
            builder.ApplyConfiguration(new LineaProduccionConfig());
            builder.ApplyConfiguration(new MarcoListaConfig());
            builder.ApplyConfiguration(new MenuConfig());
            builder.ApplyConfiguration(new NotificacionConfig());
            builder.ApplyConfiguration(new OrganizacionConfig());
            builder.ApplyConfiguration(new PanelRegistroConfig());
            builder.ApplyConfiguration(new PecuarioConfig());
            builder.ApplyConfiguration(new PerfilConfig());
            builder.ApplyConfiguration(new PerfilMenuConfig());
            builder.ApplyConfiguration(new PerfilPermisoEntidadConfig());
            builder.ApplyConfiguration(new PermisoConfig());
            builder.ApplyConfiguration(new PersonaConfig());  
            builder.ApplyConfiguration(new PlantillaConfig());
            builder.ApplyConfiguration(new SesionConfig());
            builder.ApplyConfiguration(new SistemaPecuarioConfig());
            builder.ApplyConfiguration(new TenenciaConfig());
            builder.ApplyConfiguration(new TipoDocumentoConfig());
            builder.ApplyConfiguration(new TipoExplotacionConfig());
            builder.ApplyConfiguration(new TipoInformacionConfig());
            builder.ApplyConfiguration(new TipoOrganizacionConfig());
            builder.ApplyConfiguration(new UsoNoAgricolaConfig());
            builder.ApplyConfiguration(new UsoTierraConfig());
            builder.ApplyConfiguration(new UsuarioConfig());
            builder.ApplyConfiguration(new UsuarioMarcoListaConfig());
            builder.ApplyConfiguration(new UsuarioPerfilConfig());
        }
    }
}
