using System;
using System.Collections.Generic;
using System.Text;

using Domain;
using Infra.MarcoLista.Output.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.MarcoLista.Configs
{
    public class EntidadConfig : IEntityTypeConfiguration<EntidadEntity>
    {
        public void Configure(EntityTypeBuilder<EntidadEntity> builder)
        {
            builder.ToTable("TG_ENTIDAD");
            builder.HasKey(c => c.Id);

        }
    }
}
