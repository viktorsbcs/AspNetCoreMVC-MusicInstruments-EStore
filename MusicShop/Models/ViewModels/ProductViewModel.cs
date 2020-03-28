using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.Models.ViewModels
{
    public class ProductViewModel
    {
        public IEnumerable<Product> AllProducts { get; set; }
    }
}
