using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingStore.Domain.Entities {
    public class ShippingDetails {
        [Required(ErrorMessage = "Пожалуйста введите имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите сюда первый адрес")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        [Required(ErrorMessage="Введите сюда название города")]
        public string City { get; set; }
        [Required(ErrorMessage = "Введите сюда название State")]
        public string State { get; set; }
        public string Zip { get; set; }
        [Required(ErrorMessage = "Введите пожалуйста название страны")]
        public string Country { get; set; }
        public bool GiftWrap { get; set; }
    }
}
