using System;
using System.Collections.Generic;
using System.Text;

using Domain;
using Infra.MarcoLista.Output.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.MarcoLista.Configs
{
    public class AnioConfig : IEntityTypeConfiguration<AnioEntity>
    {
        public void Configure(EntityTypeBuilder<AnioEntity> builder)
        {
            builder.ToTable("TC_ANIO");
            builder.HasKey(c => c.Id);

        }
    }
}
