using System;
using System.Collections.Generic;
using System.Text;

using Domain;
using Infra.MarcoLista.Output.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.MarcoLista.Configs
{
    public class CondicionJuridicaConfig : IEntityTypeConfiguration<CondicionJuridicaEntity>
    {
        public void Configure(EntityTypeBuilder<CondicionJuridicaEntity> builder)
        {
            builder.ToTable("TG_CONDICION_JURIDICA");
            builder.HasKey(c => c.Id);

        }
    }
}
