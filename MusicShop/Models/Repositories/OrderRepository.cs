using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicShop.Models.Interfaces;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

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

        public IEnumerable<Order> AllOrders { get => _appDbContext.Orders.ToList(); }

        

        public List<Order> GetOrdersByUserId(string userId)
        {
            var orders = _appDbContext.Orders.Where(x => x.UserId == userId ).ToList();

            foreach (var order in orders)
            {
                order.CartItems = GetOrderProductList(order.OrderId);
                order.TotalOrderValue = _cart.GetTotalCartValueById(order.CartId);
            }
            //return _appDbContext.Orders.Where(x => x.UserId == userId).Include(x => x.User).Include(x=>x.CartItems.).ToList();
            return orders;
        }

        public Order GetOrderById(int orderId)
        {
            var order = _appDbContext.Orders.SingleOrDefault(o => o.OrderId == orderId);
            order.CartItems = GetOrderProductList(orderId);

            return order;

        }

        public Order CreateOrder(Order order,  IdentityUser user)
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
                    PhoneNumber = order.PhoneNumber,
                    UserId = user.Id,
                    CartItems = _cart.GetCartItems(),
                    TotalOrderValue = _cart.GetTotalCartValueById(_cart.GetCartId())
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
