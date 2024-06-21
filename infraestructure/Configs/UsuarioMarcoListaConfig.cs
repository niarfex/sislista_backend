using System;
using System.Collections.Generic;
using System.Text;

using Domain;
using Infra.MarcoLista.Output.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.MarcoLista.Configs
{
    public class UsuarioMarcoListaConfig : IEntityTypeConfiguration<UsuarioMarcoListaEntity>
    {
        public void Configure(EntityTypeBuilder<UsuarioMarcoListaEntity> builder)
        {
            builder.ToTable("TC_USUARIO_TMC_MARCO_LISTA");
            builder.HasKey(c => c.Id);

        }
    }
}
