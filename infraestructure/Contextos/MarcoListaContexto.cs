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
        public DbSet<AnioEntity> Anio { get; set; }
        public DbSet<AuditoriaEntity> Auditoria { get; set; }
        public DbSet<CondicionJuridicaEntity> CondicionJuridica { get; set; }
        public DbSet<EntidadEntity> Entidad { get; set; }
        public DbSet<EtapaEntity> Etapa { get; set; }
        public DbSet<FrecuenciaEntity> Frecuencia { get; set; }
        public DbSet<GestionRegistroEntity> GestionRegistro { get; set; }
        public DbSet<LineaProduccionEntity> LineaProduccion { get; set; }
        public DbSet<MarcoListaEntity> MarcoLista { get; set; }
        public DbSet<MenuEntity> Menu { get; set; }
        public DbSet<NotificacionEntity> Notificacion { get; set; }
        public DbSet<OrganizacionEntity> Organizacion { get; set; }
        public DbSet<PanelRegistroEntity> PanelRegistro { get; set; }
        public DbSet<PerfilEntity> Perfil { get; set; }
        public DbSet<PerfilMenuEntity> PerfilMenu { get; set; }
        public DbSet<PerfilPermisoEntidadEntity> PerfilPermisoEntidad { get; set; }
        public DbSet<PersonaEntity> Permiso { get; set; }
        public DbSet<PersonaEntity> Persona { get; set; }
        public DbSet<PlantillaEntity> Plantilla { get; set; }
        public DbSet<SesionEntity> Sesion { get; set; }
        public DbSet<TipoDocumentoEntity> TipoDocumento { get; set; }
        public DbSet<TipoExplotacionEntity> TipoExplotacion { get; set; }
        public DbSet<TipoOrganizacionEntity> TipoOrganizacion { get; set; }
        public DbSet<UsuarioEntity> Usuario { get; set; }
        public DbSet<UsuarioMarcoListaEntity> UsuarioMarcoLista { get; set; }
        public DbSet<UsuarioPerfilEntity> UsuarioPerfil { get; set; }

        //private readonly IConfiguration _configuracion;
        //public MarcoListaContexto(IConfiguration configuracion)
        //{
        //    _configuracion = configuracion;
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseOracle("DATA SOURCE=srvdb-oracle-desa.domainminag.gob/DEVELOPER;USER ID=SISLISTA;PASSWORD=D3v3l0p3r$");//_configuracion.GetSection("DatabaseSettings")["ConnectionString1"]);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new AnioConfig());
            builder.ApplyConfiguration(new AuditoriaConfig());
            builder.ApplyConfiguration(new CondicionJuridicaConfig());
            builder.ApplyConfiguration(new EntidadConfig());
            builder.ApplyConfiguration(new EtapaConfig());
            builder.ApplyConfiguration(new FrecuenciaConfig());
            builder.ApplyConfiguration(new GestionRegistroConfig());
            builder.ApplyConfiguration(new LineaProduccionConfig());
            builder.ApplyConfiguration(new MarcoListaConfig());
            builder.ApplyConfiguration(new MenuConfig());
            builder.ApplyConfiguration(new NotificacionConfig());
            builder.ApplyConfiguration(new OrganizacionConfig());
            builder.ApplyConfiguration(new PanelRegistroConfig());
            builder.ApplyConfiguration(new PerfilConfig());
            builder.ApplyConfiguration(new PerfilMenuConfig());
            builder.ApplyConfiguration(new PerfilPermisoEntidadConfig());
            builder.ApplyConfiguration(new PermisoConfig());
            builder.ApplyConfiguration(new PersonaConfig());  
            builder.ApplyConfiguration(new PlantillaConfig());
            builder.ApplyConfiguration(new SesionConfig());
            builder.ApplyConfiguration(new TipoDocumentoConfig());
            builder.ApplyConfiguration(new TipoExplotacionConfig());
            builder.ApplyConfiguration(new TipoOrganizacionConfig());            
            builder.ApplyConfiguration(new UsuarioConfig());
            builder.ApplyConfiguration(new UsuarioMarcoListaConfig());
            builder.ApplyConfiguration(new UsuarioPerfilConfig());
        }
    }
}
