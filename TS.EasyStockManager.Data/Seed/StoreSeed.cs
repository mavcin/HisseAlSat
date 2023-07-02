using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TS.EasyStockManager.Data.Entity;

namespace TS.EasyStockManager.Data.Seed
{
    internal class StoreSeed : IEntityTypeConfiguration<Telegram>
    {
        public void Configure(EntityTypeBuilder<Telegram> builder)
        {
            builder.HasData(new Telegram { Id = 1, TelegramName = "EX01", TelegramComment = "Example Store", CreateDate = DateTime.Now });
        }
    }
}
