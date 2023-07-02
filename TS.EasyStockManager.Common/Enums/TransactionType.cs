using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TS.EasyStockManager.Common.Enums
{
    public enum TransactionType
    {
        [Display(Name = "Alış İşlemi")]
        StockIn = 1,
        [Display(Name = "Hisse İşlemi")]
        StockOut = 2,
        [Display(Name = "Transfer")]
        Transfer = 3
    }
}
