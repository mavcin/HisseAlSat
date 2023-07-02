using System;
using System.Collections.Generic;
using System.Text;

namespace TS.EasyStockManager.Data.Entity
{
    public class TelegramStock
    {
        public int TelegramId { get; set; }
        public int ProductId { get; set; }
        public decimal Stock { get; set; }
        public virtual Product Product { get; set; }
        public virtual Telegram Telegram { get; set; }
    }
}
