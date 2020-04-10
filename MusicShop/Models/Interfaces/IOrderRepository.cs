using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.Models.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Order> AllOrders { get; }
        Order GetOrderById(int orderId);

        List<CartItem> GetOrderProductList(int orderId);
        Order CreateOrder(Order order, IdentityUser user);
    }
}
