using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TS.EasyStockManager.Data.Entity;

namespace TS.EasyStockManager.Data.Configurations
{
    internal class TelegramConfiguration : IEntityTypeConfiguration<Telegram>
    {
        public void Configure(EntityTypeBuilder<Telegram> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.TelegramName).IsRequired().HasMaxLength(30);
            builder.Property(x => x.TelegramComment).IsRequired().HasMaxLength(100);    
            builder.ToTable("Telegram");
        }
    }
}
