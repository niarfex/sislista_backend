using System;
using System.Collections.Generic;
using System.Text;

using Domain;
using Infra.MarcoLista.Output.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.MarcoLista.Configs
{
    public class PerfilConfig : IEntityTypeConfiguration<PerfilEntity>
    {
        public void Configure(EntityTypeBuilder<PerfilEntity> builder)
        {
            builder.ToTable("TC_PERFIL");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Perfil).HasColumnType("VARCHAR2");
        }
    }
}
