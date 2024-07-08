using System;
using System.Collections.Generic;
using System.Text;

using Domain;
using Infra.MarcoLista.Output.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.MarcoLista.Configs
{
    public class MarcoListaConfig : IEntityTypeConfiguration<MarcoListaEntity>
    {
        public void Configure(EntityTypeBuilder<MarcoListaEntity> builder)
        {
            builder.ToTable("TMC_MARCO_LISTA");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.IdAnio).HasColumnType("NUMBER");
        }
    }
}
