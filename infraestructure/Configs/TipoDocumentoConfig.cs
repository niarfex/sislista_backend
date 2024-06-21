using System;
using System.Collections.Generic;
using System.Text;

using Domain;
using Infra.MarcoLista.Output.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.MarcoLista.Configs
{
    public class TipoDocumentoConfig : IEntityTypeConfiguration<TipoDocumentoEntity>
    {
        public void Configure(EntityTypeBuilder<TipoDocumentoEntity> builder)
        {
            builder.ToTable("TG_TIPO_DOCUMENTO");
            builder.HasKey(c => c.Id);

        }
    }
}
