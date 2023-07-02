using System;
using System.Collections.Generic;
using System.Text;

namespace TS.EasyStockManager.Data.Entity
{
    public class Telegram : BaseEntity
    {
        public string TelegramName { get; set; }
        public string TelegramComment { get; set; }
        public virtual ICollection<TelegramStock> StoreStock { get; set; }
    }
}
