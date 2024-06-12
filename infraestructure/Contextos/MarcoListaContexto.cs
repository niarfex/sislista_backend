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
        public DbSet<NotificacionEntity> Notificacion { get; set; }
        public DbSet<PanelRegistroEntity> PanelRegistro { get; set; }
        public DbSet<PlantillaEntity> Plantilla { get; set; }
        public DbSet<CondicionJuridicaEntity> CondicionJuridica { get; set; }
        public DbSet<CultivoEntity> Cultivo { get; set; }
        public DbSet<EspecieEntity> Especie { get; set; }
        public DbSet<LineaProduccionEntity> LineaProduccion { get; set; }
        public DbSet<TipoExplotacionEntity> TipoExplotacion { get; set; }
        public DbSet<UbigeoEntity> Ubigeo { get; set; }
        public DbSet<MarcoListaEntity> MarcoLista { get; set; }
        public DbSet<OrganizacionEntity> Organizacion { get; set; }
        public DbSet<UsuarioEntity> Usuario { get; set; }
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

            builder.ApplyConfiguration(new UbigeoConfig());
        }
    }
}
