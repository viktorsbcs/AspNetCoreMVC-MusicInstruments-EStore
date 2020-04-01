using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicShop.Models.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace MusicShop.Models.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly Cart _cart;

        public OrderRepository(AppDbContext appDbContext, Cart cart)
        {
            this._appDbContext = appDbContext;
            this._cart = cart;
        }

        public IEnumerable<Order> AllOrders { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Order GetOrderById(int orderId)
        {
            return _appDbContext.Orders.FirstOrDefault(o => o.OrderId == orderId);
        }

        public Order CreateOrder(Order order)
        {
            var orderFound = _appDbContext.Orders.SingleOrDefault(o => o.OrderId == order.OrderId);

            if (orderFound == null)
            {
                var orderNew = new Order()
                {
                    CartId = _cart.GetCartId(),
                    FirstName = order.FirstName,
                    LastName = order.LastName,
                    Country = order.Country,
                    Address = order.Address,
                    Email = order.Email,
                    PhoneNumber = order.PhoneNumber


                };

                _appDbContext.Orders.Add(orderNew);

                _appDbContext.SaveChanges();
                return orderNew;
            }
            return null;

        }

        public List<CartItem> GetOrderProductList(int orderId)
        {
            var orderFound = _appDbContext.Orders.SingleOrDefault(o => o.OrderId == orderId);

            if (orderFound != null)
            {
                var cartItems = _appDbContext.CartItems.Where(i => i.CartId == orderFound.CartId).Include(i=>i.Product).ToList();

                return cartItems;
            }

            return null;

        }
    }
}
