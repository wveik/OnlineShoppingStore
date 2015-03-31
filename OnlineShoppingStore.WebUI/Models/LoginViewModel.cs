using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShoppingStore.WebUI.Models {
    public class LoginViewModel {
        [Required(ErrorMessage="Логин обязателен")]
        public string UserName { get; set; }
        [Required(ErrorMessage="Пароль обязателен")]
        [StringLength(50, MinimumLength=6)]
        public string Password { get; set; }
    }
}