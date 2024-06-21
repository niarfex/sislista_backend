using System;
using System.Collections.Generic;
using System.Text;

using Domain;
using Infra.MarcoLista.Output.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.MarcoLista.Configs
{
    public class PerfilPermisoEntidadConfig : IEntityTypeConfiguration<PerfilPermisoEntidadEntity>
    {
        public void Configure(EntityTypeBuilder<PerfilPermisoEntidadEntity> builder)
        {
            builder.ToTable("TC_PERFIL_TC_PERMISO_TG_ENTIDAD");
            builder.HasKey(c => c.Id);

        }
    }
}
