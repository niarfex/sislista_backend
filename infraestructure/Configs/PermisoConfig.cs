using System;
using System.Collections.Generic;
using System.Text;

using Domain;
using Infra.MarcoLista.Output.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.MarcoLista.Configs
{
    public class PermisoConfig : IEntityTypeConfiguration<PermisoEntity>
    {
        public void Configure(EntityTypeBuilder<PermisoEntity> builder)
        {
            builder.ToTable("TC_PERMISO");
            builder.HasKey(c => c.Id);

        }
    }
}
