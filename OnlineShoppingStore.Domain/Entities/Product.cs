using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OnlineShoppingStore.Domain.Entities {
    public class Product {
        [HiddenInput(DisplayValue = false)]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Введите название продукта")]
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Введите описание")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Введите цену на товар")]
        [Range(0.01, double.MaxValue, ErrorMessage="Введите положительные значения")]
        public decimal Price { get; set; }
        [Required(ErrorMessage="Введите название категории")]
        public string Category { get; set; }
    }
}
