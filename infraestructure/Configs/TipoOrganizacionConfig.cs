using System;
using System.Collections.Generic;
using System.Text;

using Domain;
using Infra.MarcoLista.Output.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.MarcoLista.Configs
{
    public class TipoOrganizacionConfig : IEntityTypeConfiguration<TipoOrganizacionEntity>
    {
        public void Configure(EntityTypeBuilder<TipoOrganizacionEntity> builder)
        {
            builder.ToTable("TG_TIPO_ORGANIZACION");
            builder.HasKey(c => c.Id);

        }
    }
}
