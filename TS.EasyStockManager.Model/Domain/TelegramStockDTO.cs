using System;
using System.Collections.Generic;
using System.Text;

namespace TS.EasyStockManager.Model.Domain
{
    public class TelegramStockDTO : BaseDTO
    {
        public int? TelegramId { get; set; }
        public int? ProductId { get; set; }
        public decimal? Stock { get; set; }
        public string TelegramName { get; set; }
        public string ProductName { get; set; }
        public string Barcode { get; set; }
        public string UnitOfMeasureName { get; set; }
        public string Isocode { get; set; }
        public string TelegramComment { get; set; }
    }
}
