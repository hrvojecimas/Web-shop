using Projekt.autentifikacija;
using Projekt.Entities;
using Projekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Web.Mvc;

namespace Projekt.Controllers
{
    public class CartController : Controller
    {
        private SkladisteProizvoda repository;

        public CartController(SkladisteProizvoda repo)
        {
            repository = repo;
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel { Cart = cart, ReturnUrl = returnUrl });
        }

   

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        public ViewResult Checkout()
        {
            ViewBag.Message = "Your order has been sent successfully"; 
             return View(new ShippingDetails());
         

        }

   
        public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductId == productId);
        
        if(product != null)
        {
            cart.AddItem(product, 1);
        }
        return RedirectToAction("Index", new { returnUrl});
        }
       
        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductId == productId);

            if(product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new {returnUrl});
        }


       
	}
}