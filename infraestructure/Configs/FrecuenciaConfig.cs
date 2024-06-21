using System;
using System.Collections.Generic;
using System.Text;

using Domain;
using Infra.MarcoLista.Output.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.MarcoLista.Configs
{
    public class FrecuenciaConfig : IEntityTypeConfiguration<FrecuenciaEntity>
    {
        public void Configure(EntityTypeBuilder<FrecuenciaEntity> builder)
        {
            builder.ToTable("TG_FRECUENCIA");
            builder.HasKey(c => c.Id);

        }
    }
}
