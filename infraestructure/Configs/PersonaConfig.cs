using System;
using System.Collections.Generic;
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

        }
    }
}
