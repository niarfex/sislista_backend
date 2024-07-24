using System;
using System.Collections.Generic;
using System.Text;

using Domain;
using Infra.MarcoLista.Output.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.MarcoLista.Configs
{
    public class TrazabilidadConfig : IEntityTypeConfiguration<TrazabilidadEntity>
    {
        public void Configure(EntityTypeBuilder<TrazabilidadEntity> builder)
        {
            builder.ToTable("TMM_TRAZABILIDAD");
            builder.HasKey(c => c.Id);

        }
    }
}
