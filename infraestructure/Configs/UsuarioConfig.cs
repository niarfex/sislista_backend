using System;
using System.Collections.Generic;
using System.Text;

using Domain;
using Infra.MarcoLista.Output.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.MarcoLista.Configs
{
    public class UsuarioConfig : IEntityTypeConfiguration<UsuarioEntity>
    {
        public void Configure(EntityTypeBuilder<UsuarioEntity> builder)
        {
            builder.ToTable("TC_USUARIO");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Clave).HasColumnType("VARCHAR2");
            builder.Property(c => c.refreshToken).HasColumnType("VARCHAR2");
            builder.Property(c => c.Usuario).HasColumnType("VARCHAR2");
            builder.Property(c => c.CodigoUUID).HasColumnType("VARCHAR2");
        }
    }
}
