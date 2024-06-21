using System;
using System.Collections.Generic;
using System.Text;

using Domain;
using Infra.MarcoLista.Output.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.MarcoLista.Configs
{
    public class EtapaConfig : IEntityTypeConfiguration<EtapaEntity>
    {
        public void Configure(EntityTypeBuilder<EtapaEntity> builder)
        {
            builder.ToTable("TG_ETAPA");
            builder.HasKey(c => c.Id);

        }
    }
}
