using System;
using System.Collections.Generic;
using System.Text;

namespace TS.EasyStockManager.Model.Domain
{
    public class TelegramDTO : BaseDTO
    {
        public string TelegramName { get; set; }
        public string TelegramComment { get; set; }
    }
}
