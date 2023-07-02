using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TS.EasyStockManager.Data.Entity;

namespace TS.EasyStockManager.Data.Configurations
{
    internal class TelegramStockConfiguration : IEntityTypeConfiguration<TelegramStock>
    {
        public void Configure(EntityTypeBuilder<TelegramStock> builder)
        {
            builder.HasKey(x => new { x.TelegramId, x.ProductId });
            builder.Property(x => x.Stock).HasColumnType("decimal(18,2)");
            builder.ToTable("StoreStock");
        }
    }
}
