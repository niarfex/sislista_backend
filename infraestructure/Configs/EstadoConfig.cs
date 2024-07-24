using System;
using System.Collections.Generic;
using System.Text;

using Domain;
using Infra.MarcoLista.Output.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.MarcoLista.Configs
{
    public class EstadoConfig : IEntityTypeConfiguration<EstadoEntity>
    {
        public void Configure(EntityTypeBuilder<EstadoEntity> builder)
        {
            builder.ToTable("TG_ESTADO");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.CodigoEstado).HasColumnType("VARCHAR2");
            builder.Property(c => c.CodigoEstadoPadre).HasColumnType("VARCHAR2");
            builder.Property(c => c.TipoEstado).HasColumnType("VARCHAR2");

        }
    }
}
