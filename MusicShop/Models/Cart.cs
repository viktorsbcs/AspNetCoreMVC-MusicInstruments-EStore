using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.Models
{
    public class Cart
    {
        private readonly AppDbContext _appDbContext;

        public string CartId { get; set; }
        public List<CartItem> CartItems { get; set; }

        public Cart(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var dbContext = services.GetService<AppDbContext>();


            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new Cart(dbContext) { CartId = cartId };


        }

        public List<CartItem> GetCartItems()
        {
            return _appDbContext.CartItems.Where(c=>c.CartId == this.CartId).Include(p=>p.Product).ToList();
        }

        public decimal TotalCartValue()
        {
            decimal amount = 0;
            foreach (var item in this.CartItems)
            {
                decimal temp = item.Quantity * item.Product.Price;
                amount += temp;
            }
            return amount;
        }
        public bool IfEnoughProductInStock(Product product, int quantity)
        {
            var productFound = _appDbContext.Products.FirstOrDefault(p => p.ProductId == product.ProductId);

            if (productFound != null && productFound.AmountInStock >= quantity)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void AddToCart(Product product, int quantity)
        {


            var cartItem = _appDbContext.CartItems.SingleOrDefault(i => i.Product.ProductId == product.ProductId && i.CartId == this.CartId);
            var enoughInStockAvailable = IfEnoughProductInStock(product, quantity);

            if (cartItem == null && enoughInStockAvailable == true)
            {
                var newCartItem = new CartItem()
                {
                    CartId = this.CartId,
                    Product = product,
                    ProductId = product.ProductId,
                    Quantity = quantity
                };

                _appDbContext.CartItems.Add(newCartItem);

            }
            else
            {
                if (enoughInStockAvailable) cartItem.Quantity += quantity;

            }


            _appDbContext.SaveChanges();
            this.CartItems = GetCartItems();
        }

    }
}
