using System;
using System.Collections.Generic;
using System.Text;

using Domain;
using Infra.MarcoLista.Output.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.MarcoLista.Configs
{
    public class TenenciaConfig : IEntityTypeConfiguration<TenenciaEntity>
    {
        public void Configure(EntityTypeBuilder<TenenciaEntity> builder)
        {
            builder.ToTable("TG_TENENCIA");
            builder.HasKey(c => c.Id);

        }
    }
}
