using System;
using System.Collections.Generic;
using System.Text;

using Domain;
using Infra.MarcoLista.Output.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.MarcoLista.Configs
{
    public class ArchivoConfig : IEntityTypeConfiguration<ArchivoEntity>
    {
        public void Configure(EntityTypeBuilder<ArchivoEntity> builder)
        {
            builder.ToTable("TMD_ARCHIVO");
            builder.HasKey(c => c.Id);

        }
    }
}
