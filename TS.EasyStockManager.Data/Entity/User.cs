﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TS.EasyStockManager.Data.Entity
{
    public class User : BaseEntity
    { 
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string TwitterAdresse { get; set; }  

        public string TelegramAdresse { get; set; }
        public string TelegramGroup { get; set; }


    }
}
