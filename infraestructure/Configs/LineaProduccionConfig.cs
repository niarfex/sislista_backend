using System;
using System.Collections.Generic;
using System.Text;

using Domain;
using Infra.MarcoLista.Output.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.MarcoLista.Configs
{
    public class LineaProduccionConfig : IEntityTypeConfiguration<LineaProduccionEntity>
    {
        public void Configure(EntityTypeBuilder<LineaProduccionEntity> builder)
        {
            builder.ToTable("TG_LINEA_PRODUCCION");
            builder.HasKey(c => c.Id);

        }
    }
}
