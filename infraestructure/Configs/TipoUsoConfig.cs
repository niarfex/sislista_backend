using System;
using System.Collections.Generic;
using System.Text;

using Domain;
using Infra.MarcoLista.Output.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.MarcoLista.Configs
{
    public class TipoUsoConfig : IEntityTypeConfiguration<TipoUsoEntity>
    {
        public void Configure(EntityTypeBuilder<TipoUsoEntity> builder)
        {
            builder.ToTable("TMD_TIPO_USO");
            builder.HasKey(c => c.Id);

        }
    }
}
