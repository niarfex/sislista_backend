using System;
using System.Collections.Generic;
using System.Text;

using Domain;
using Infra.MarcoLista.Output.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.MarcoLista.Configs
{
    public class NotificacionConfig : IEntityTypeConfiguration<NotificacionEntity>
    {
        public void Configure(EntityTypeBuilder<NotificacionEntity> builder)
        {
            builder.ToTable("TMM_NOTIFICACION");
            builder.HasKey(c => c.Id);

        }
    }
}
