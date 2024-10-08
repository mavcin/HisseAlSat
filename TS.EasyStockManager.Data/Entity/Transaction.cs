﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TS.EasyStockManager.Data.Entity
{
    public class Transaction : BaseEntity
    {
        public string TransactionCode { get; set; }
        public int StoreId { get; set; }  // hisse id
        public int? ToStoreId { get; set; }
        public int TransactionTypeId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public virtual TransactionType TransactionType { get; set; }
        public virtual Telegram ToStore { get; set; }
        public virtual Telegram Store { get; set; }
        public virtual ICollection<TransactionDetail> TransactionDetail { get; set; }
    }
}
