using Lab1.Extensions;
using Lab1.Models;
using Microsoft.AspNetCore.Mvc;


namespace Lab1.Components
{
    
        public class CartViewComponent : ViewComponent
        {
            private Cart _cart;
            public CartViewComponent(Cart cart)
            {
                _cart = cart;
            }
            public IViewComponentResult Invoke()
            {
            //var cart = HttpContext.Session.Get<Cart>("cart");
            return View(_cart);
        }
        }
    }

