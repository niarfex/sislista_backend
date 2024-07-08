using System;
using System.Collections.Generic;
using System.Text;

using Domain;
using Infra.MarcoLista.Output.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.MarcoLista.Configs
{
    public class InformanteConfig : IEntityTypeConfiguration<InformanteEntity>
    {
        public void Configure(EntityTypeBuilder<InformanteEntity> builder)
        {
            builder.ToTable("TMD_INFORMANTE");
            builder.HasKey(c => c.Id);

        }
    }
}
