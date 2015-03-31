using OnlineShoppingStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingStore.Domain.Concrete {
    public class FormsAuthenticationProvider : IAuthentication {

        private readonly EFDbContext context = new EFDbContext();

        public bool Authecticate(string username, string password) {
            var result = context
                .Users
                .FirstOrDefault
                    (x => x.UserId == username && x.Password == password);

            return result != null;
        }

        public bool Logout() {
            throw new NotImplementedException();
        }
    }
}
