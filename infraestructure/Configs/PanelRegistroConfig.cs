using System;
using System.Collections.Generic;
using System.Text;

using Domain;
using Infra.MarcoLista.Output.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.MarcoLista.Configs
{
    public class PanelRegistroConfig : IEntityTypeConfiguration<PanelRegistroEntity>
    {
        public void Configure(EntityTypeBuilder<PanelRegistroEntity> builder)
        {
            builder.ToTable("TMM_PROGRAMACION_REGISTRO");
            builder.HasKey(c => c.Id);

        }
    }
}
