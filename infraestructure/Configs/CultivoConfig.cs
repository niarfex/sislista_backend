using System;
using System.Collections.Generic;
using System.Text;

using Domain;
using Infra.MarcoLista.Output.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.MarcoLista.Configs
{
    public class CultivoConfig : IEntityTypeConfiguration<CultivoEntity>
    {
        public void Configure(EntityTypeBuilder<CultivoEntity> builder)
        {
            builder.ToTable("TG_CULTIVO");
            builder.HasKey(c => c.Id);

        }
    }
}
