using System;
using System.Collections.Generic;
using System.Text;

using Domain;
using Infra.MarcoLista.Output.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.MarcoLista.Configs
{
    public class TipoInformacionConfig : IEntityTypeConfiguration<TipoInformacionEntity>
    {
        public void Configure(EntityTypeBuilder<TipoInformacionEntity> builder)
        {
            builder.ToTable("TG_TIPO_INFORMACION");
            builder.HasKey(c => c.Id);

        }
    }
}