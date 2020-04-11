using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.Models.ViewModels
{
    public class OrderViewModel
    {
        public List<CartItem> CartItems { get; set; } 
        public Order Order { get; set; }

        public List<Order> UserOrderList { get; set; }

    }
}
