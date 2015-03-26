using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingStore.Domain.Concrete {
    public class EmailSettings {
        public string MailToAddress = "test@list.ru";
        public string MailFromAddress = "test@list.ru";
        public bool UseSsl  = true;
        public string ServerName = "mail.ru";
        public int ServerPort = 587;
        public string UserName = "test@list.ru";
        public string Password = "test";
    }
}
