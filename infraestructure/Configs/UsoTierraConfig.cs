using System;
using System.Collections.Generic;
using System.Text;

using Domain;
using Infra.MarcoLista.Output.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.MarcoLista.Configs
{
    public class UsoTierraConfig : IEntityTypeConfiguration<UsoTierraEntity>
    {
        public void Configure(EntityTypeBuilder<UsoTierraEntity> builder)
        {
            builder.ToTable("TG_USO_TIERRA");
            builder.HasKey(c => c.Id);

        }
    }
}
