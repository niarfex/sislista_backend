using System;
using System.Collections.Generic;
using System.Text;

using Domain;
using Infra.MarcoLista.Output.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.MarcoLista.Configs
{
    public class PlantillaConfig : IEntityTypeConfiguration<PlantillaEntity>
    {
        public void Configure(EntityTypeBuilder<PlantillaEntity> builder)
        {
            builder.ToTable("TMM_PLANTILLA");
            builder.HasKey(c => c.Id);

        }
    }
}
