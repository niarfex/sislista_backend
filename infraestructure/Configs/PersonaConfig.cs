using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

using Domain;
using Infra.MarcoLista.Output.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.MarcoLista.Configs
{
    public class PersonaConfig : IEntityTypeConfiguration<PersonaEntity>
    {
        public void Configure(EntityTypeBuilder<PersonaEntity> builder)
        {
            builder.ToTable("TG_PERSONA");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nombre).HasColumnType("VARCHAR2");
            builder.Property(c => c.ApellidoPaterno).HasColumnType("VARCHAR2");
            builder.Property(c => c.ApellidoMaterno).HasColumnType("VARCHAR2");
            builder.Property(c => c.RazonSocial).HasColumnType("VARCHAR2");
            builder.Property(c => c.NombreRepLegal).HasColumnType("VARCHAR2");
        }
    }
}
