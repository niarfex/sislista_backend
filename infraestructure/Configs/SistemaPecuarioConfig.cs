using System;
using System.Collections.Generic;
using System.Text;

using Domain;
using Infra.MarcoLista.Output.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.MarcoLista.Configs
{
    public class SistemaPecuarioConfig : IEntityTypeConfiguration<SistemaPecuarioEntity>
    {
        public void Configure(EntityTypeBuilder<SistemaPecuarioEntity> builder)
        {
            builder.ToTable("TG_SISTEMA_PECUARIO");
            builder.HasKey(c => c.Id);

        }
    }
}
