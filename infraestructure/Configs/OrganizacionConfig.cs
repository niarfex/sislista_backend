using System;
using System.Collections.Generic;
using System.Text;

using Domain;
using Infra.MarcoLista.Output.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.MarcoLista.Configs
{
    public class OrganizacionConfig : IEntityTypeConfiguration<OrganizacionEntity>
    {
        public void Configure(EntityTypeBuilder<OrganizacionEntity> builder)
        {
            builder.ToTable("TG_ORGANIZACION");
            builder.HasKey(c => c.Id);

        }
    }
}
