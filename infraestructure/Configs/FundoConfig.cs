using System;
using System.Collections.Generic;
using System.Text;

using Domain;
using Infra.MarcoLista.Output.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.MarcoLista.Configs
{
    public class FundoConfig : IEntityTypeConfiguration<FundoEntity>
    {
        public void Configure(EntityTypeBuilder<FundoEntity> builder)
        {
            builder.ToTable("TMD_FUNDO");
            builder.HasKey(c => c.Id);

        }
    }
}
