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

        [Required(ErrorMessage = "Введите свои данные")]
        public string FIO { get; set; }

        [Required(ErrorMessage = "Введите номер телефона")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Введите email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Вы ввели некорректный email")]
        public string Email { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }

    }
}