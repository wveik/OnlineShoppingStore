using OnlineShoppingStore.Domain.Abstract;
using OnlineShoppingStore.Domain.Entities;
using OnlineShoppingStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingStore.WebUI.Controllers {
    public class CartController : Controller {
        private readonly IProductRepository _repository;
        private readonly IOrderProcessor orderProcessor;

        public CartController(IProductRepository _repository, IOrderProcessor proc) {
            this._repository = _repository;
            orderProcessor = proc;
        }

        public ViewResult Index(Cart cart, string returnUrl) {
            return View(new CartIndexViewModel {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public PartialViewResult Summary(Cart cart) {
            return PartialView(cart);
        }

        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails) {
            if (cart.Lines.Count() == 0) {
                ModelState.AddModelError("", "Простите - Ваша корзина пуста!");
            }
            if (ModelState.IsValid) {
                orderProcessor.ProcessorOrder(cart, shippingDetails);
                cart.Clear();
                return View("Заказа совершон");
            }
            return View(shippingDetails);
        }

        public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl) {
            Product product = _repository
                .Products
                .FirstOrDefault(x => x.ProductId == productId);

            if (product != null) {
                cart.AddItem(product, 1);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl) {
            Product product = _repository
                .Products
                .FirstOrDefault(x => x.ProductId == productId);

            if (product != null) {
                cart.RemoveLine(product);
            }

            return RedirectToAction("Index", new { returnUrl });
        }
    }
}