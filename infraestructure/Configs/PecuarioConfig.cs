using System;
using System.Collections.Generic;
using System.Text;

using Domain;
using Infra.MarcoLista.Output.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.MarcoLista.Configs
{
    public class PecuarioConfig : IEntityTypeConfiguration<PecuarioEntity>
    {
        public void Configure(EntityTypeBuilder<PecuarioEntity> builder)
        {
            builder.ToTable("TMD_PECUARIO");
            builder.HasKey(c => c.Id);

        }
    }
}
