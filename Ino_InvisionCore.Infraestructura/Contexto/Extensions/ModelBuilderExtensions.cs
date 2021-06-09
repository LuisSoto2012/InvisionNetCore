using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Infraestructura.Contexto.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder RemovePluralizingTableNameConvention(this ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (entityType.ClrType == null)
                    continue;

                entityType.Relational().TableName = entityType.ClrType.Name;
            }

            return modelBuilder;
        }
    }
}
