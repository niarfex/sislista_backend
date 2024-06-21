using System;
using System.Collections.Generic;
using System.Text;

using Domain;
using Infra.MarcoLista.Output.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.MarcoLista.Configs
{
    public class SesionConfig : IEntityTypeConfiguration<SesionEntity>
    {
        public void Configure(EntityTypeBuilder<SesionEntity> builder)
        {
            builder.ToTable("TC_SESION");
            builder.HasKey(c => c.Id);

        }
    }
}
