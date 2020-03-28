using Microsoft.EntityFrameworkCore;
using MusicShop.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShop.Models.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }
        public IEnumerable<Product> AllProducts
        {
            get
            {
                return _appDbContext.Products.Include(c => c.Category);
            }
        }


        public Product GetProductById(int productId)
        {
            return _appDbContext.Products.FirstOrDefault(p => p.ProductId == productId);
        }

        public int IncreaseStock(int productId, int amount)
        {
            var product = this.AllProducts.FirstOrDefault(p => p.ProductId == productId);

            if (product != null)
            {
                product.AmountInStock += amount;
                product.InStock = true;

                _appDbContext.SaveChanges();
                return product.AmountInStock;
            }

            return -1;

        }

        public int DecreaseStock(int productId, int amount)
        {
            var product = this.AllProducts.FirstOrDefault(p => p.ProductId == productId);

            if (product != null && product.AmountInStock >= amount)
            {
                product.AmountInStock -= amount;
                if (product.AmountInStock == 0) product.InStock = false;

                _appDbContext.SaveChanges();
                return product.AmountInStock;
            }
            return -1;

        }

    }
}
