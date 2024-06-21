using System;
using System.Collections.Generic;
using System.Text;

using Domain;
using Infra.MarcoLista.Output.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.MarcoLista.Configs
{
    public class PerfilMenuConfig : IEntityTypeConfiguration<PerfilMenuEntity>
    {
        public void Configure(EntityTypeBuilder<PerfilMenuEntity> builder)
        {
            builder.ToTable("TC_PERFIL_TG_MENU");
            builder.HasKey(c => c.Id);

        }
    }
}
