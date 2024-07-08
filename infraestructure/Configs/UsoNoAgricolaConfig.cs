using System;
using System.Collections.Generic;
using System.Text;

using Domain;
using Infra.MarcoLista.Output.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.MarcoLista.Configs
{
    public class UsoNoAgricolaConfig : IEntityTypeConfiguration<UsoNoAgricolaEntity>
    {
        public void Configure(EntityTypeBuilder<UsoNoAgricolaEntity> builder)
        {
            builder.ToTable("TG_USO_NO_AGRICOLA");
            builder.HasKey(c => c.Id);

        }
    }
}
