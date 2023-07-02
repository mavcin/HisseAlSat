using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TS.EasyStockManager.Model.ViewModel.Base;

namespace TS.EasyStockManager.Model.ViewModel.User
{
    public class EditUserViewModel : BaseViewModel
    {
        [Required]
        [MaxLength(100)]
        [Display]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(40)]
        [Display]
        public string Password { get; set; }

        [Required]
        [MaxLength(50)]
        [Display]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        [Display]
        public string Surname { get; set; }

        [Required]
        [MaxLength(50)]
        [Display]
        public string TwitterAdresse { get; set; }


        [Required]
        [MaxLength(50)]
        [Display]
        public string TelegramAdresse { get; set; }

        [Required]
        [MaxLength(50)]
        [Display]
        public string TelegramGroup { get; set; }
    }
}
