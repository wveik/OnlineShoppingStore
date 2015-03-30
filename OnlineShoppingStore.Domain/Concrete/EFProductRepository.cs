using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShoppingStore.Domain.Abstract;
using OnlineShoppingStore.Domain.Entities;

namespace OnlineShoppingStore.Domain.Concrete {
    public class EFProductRepository : IProductRepository  {
        private readonly EFDbContext context = new EFDbContext();

        public IEnumerable<Product> Products {
            get { return context.Products; }
        }

        public void SaveProduct(Product _product) {
            if (_product.ProductId == 0)
                context.Products.Add(_product);
            else {
                Product dbEntry =
                    context.Products.Find(_product.ProductId);
                if (dbEntry != null) {
                    dbEntry.Name = _product.Name;
                    dbEntry.Description = _product.Description;
                    dbEntry.Price = _product.Price;
                    dbEntry.Category = _product.Category;
                }
            }
            context.SaveChanges();
        }


        public Product DeleteProduct(int productId) {
            Product _product = context.Products.Find(productId);
            if (_product != null) {
                context.Products.Remove(_product);
                context.SaveChanges();
            }
            return _product;
        }
    }
}
