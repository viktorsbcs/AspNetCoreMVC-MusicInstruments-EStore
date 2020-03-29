using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.Models
{
    public class CartItem
    {

        public int CartItemId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string CartId { get; set; }
        public int Quantity { get; set; }
    }
}
