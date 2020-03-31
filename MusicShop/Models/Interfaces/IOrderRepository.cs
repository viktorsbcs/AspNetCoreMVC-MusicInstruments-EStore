using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.Models.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Order> AllOrders { get; set; }
        Order GetOrderById(int orderId);

        List<CartItem> GetOrderProductList(int orderId);
        Order CreateOrder(Order order);
    }
}
