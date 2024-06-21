using System;
using System.Collections.Generic;
using System.Text;

using Domain;
using Infra.MarcoLista.Output.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.MarcoLista.Configs
{
    public class UsuarioPerfilConfig : IEntityTypeConfiguration<UsuarioPerfilEntity>
    {
        public void Configure(EntityTypeBuilder<UsuarioPerfilEntity> builder)
        {
            builder.ToTable("TC_USUARIO_TC_PERFIL");
            builder.HasKey(c => c.Id);

        }
    }
}
