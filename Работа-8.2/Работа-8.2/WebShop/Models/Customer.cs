using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebShop.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "Пожалуйста введите своё ФИО")]
        public string FIO { get; set; }

        [Required(ErrorMessage = "Введите свой номер телефона")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Введите свой email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Вы ввели некорректный email")]
        public string Email { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }

    }
}