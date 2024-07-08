using System;
using System.Collections.Generic;
using System.Text;

using Domain;
using Infra.MarcoLista.Output.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.MarcoLista.Configs
{
    public class CampoConfig : IEntityTypeConfiguration<CampoEntity>
    {
        public void Configure(EntityTypeBuilder<CampoEntity> builder)
        {
            builder.ToTable("TMD_CAMPO");
            builder.HasKey(c => c.Id);

        }
    }
}
