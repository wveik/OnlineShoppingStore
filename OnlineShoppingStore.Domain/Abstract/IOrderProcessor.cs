using OnlineShoppingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingStore.Domain.Abstract {
    public interface IOrderProcessor {
        void ProcessorOrder(Cart cart, ShippingDetails shippingDetails);
    }
}
