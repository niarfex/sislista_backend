using System;
using System.Collections.Generic;
using System.Text;

using Domain;
using Infra.MarcoLista.Output.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.MarcoLista.Configs
{
    public class UbigeoConfig : IEntityTypeConfiguration<UbigeoEntity>
    {
        public void Configure(EntityTypeBuilder<UbigeoEntity> builder)
        {
            builder.ToTable("TG_UBIGEO");
            builder.HasKey(c => c.Id);
      
        }
    }
}
