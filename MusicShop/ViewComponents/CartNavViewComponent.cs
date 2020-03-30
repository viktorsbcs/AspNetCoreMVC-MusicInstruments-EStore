using Microsoft.AspNetCore.Mvc;
using MusicShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.ViewComponents
{
    public class CartNavViewComponent : ViewComponent
    {
        private readonly AppDbContext _appDbContext;
        private readonly Cart _cart;

        public CartNavViewComponent(AppDbContext appDbContext, Cart cart)
        {
            this._appDbContext = appDbContext;
            this._cart = cart;
        }


        public IViewComponentResult Invoke()
        {
            _cart.CartItems = _cart.GetCartItems();
            return View(_cart);

        }

    }
}
