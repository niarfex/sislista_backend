using System;
using System.Collections.Generic;
using System.Text;

using Domain;
using Infra.MarcoLista.Output.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.MarcoLista.Configs
{
    public class EspecieConfig : IEntityTypeConfiguration<EspecieEntity>
    {
        public void Configure(EntityTypeBuilder<EspecieEntity> builder)
        {
            builder.ToTable("TG_ESPECIE");
            builder.HasKey(c => c.Id);

        }
    }
}
