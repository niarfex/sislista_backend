using System;
using System.Collections.Generic;
using System.Text;

using Domain;
using Infra.MarcoLista.Output.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.MarcoLista.Configs
{
    public class TipoExplotacionConfig : IEntityTypeConfiguration<TipoExplotacionEntity>
    {
        public void Configure(EntityTypeBuilder<TipoExplotacionEntity> builder)
        {
            builder.ToTable("TG_TIPO_EXPLOTACION");
            builder.HasKey(c => c.Id);

        }
    }
}
