using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.Models.ViewModels
{
    public class TestViewModel
    {
        public Product GetProductById { get; set; }
        public Category GetCategoryById { get; set; }
        public int IncreaseStock { get; set; }
        public int DecreaseStock { get; set; }
    }
}
