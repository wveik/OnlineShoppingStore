using Ninject;
using OnlineShoppingStore.Domain.Abstract;
using OnlineShoppingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingStore.WebUI.Controllers {
    public class AdminController : Controller {
        [Inject]
        public IProductRepository _repository { get; set; }

        public ActionResult Index() {
            return View(_repository.Products);
        }
        
        [HttpGet]
        public ActionResult Edit(int productId) {
            Product product = _repository.Products.FirstOrDefault(x => x.ProductId == productId);

            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product _product) {
            if (ModelState.IsValid) {
                _repository.SaveProduct(_product);
                TempData["message"] = string.Format("{0} был сохранен", _product.Name);
                return RedirectToAction("Index");
            }

            return View(_product);
        }

        [HttpGet]
        public ActionResult Create() {
            return View(new Product());
        }

        [HttpPost]
        public ActionResult Create(Product _product) {
            if (ModelState.IsValid) {
                _repository.SaveProduct(_product);
                TempData["message"] = string.Format("{0} был сохранен", _product.Name);
                return RedirectToAction("Index");
            }

            return View(_product);            
        }

        public ActionResult Delete(int productId) {
            Product _product = _repository.DeleteProduct(productId);
            if (_product != null) {
                TempData["message"] = string.Format("{0} был удален продукт", _product.Name);
            }
            return RedirectToAction("Index");
        }
    }
}