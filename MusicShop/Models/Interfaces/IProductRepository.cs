using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.Models.Interfaces
{
    public interface IProductRepository
    {

        IEnumerable<Product> AllProducts { get; }

        Product GetProductById(int ProductId);

        int  IncreaseStock(int productId, int amount);
        int  DecreaseStock(int productId, int amount);
    }
}
