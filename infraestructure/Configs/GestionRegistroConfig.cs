using System;
using System.Collections.Generic;
using System.Text;

using Domain;
using Infra.MarcoLista.Output.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.MarcoLista.Configs
{
    public class GestionRegistroConfig : IEntityTypeConfiguration<GestionRegistroEntity>
    {
        public void Configure(EntityTypeBuilder<GestionRegistroEntity> builder)
        {
            builder.ToTable("TMC_CUESTIONARIO");
            builder.HasKey(c => c.Id);

        }
    }
}
