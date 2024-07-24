using System;
using System.Collections.Generic;
using System.Text;

using Domain;
using Infra.MarcoLista.Output.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.MarcoLista.Configs
{
    public class SeccionConfig : IEntityTypeConfiguration<SeccionEntity>
    {
        public void Configure(EntityTypeBuilder<SeccionEntity> builder)
        {
            builder.ToTable("TG_SECCION");
            builder.HasKey(c => c.Id);

        }
    }
}
