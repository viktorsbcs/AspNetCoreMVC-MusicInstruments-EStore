using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicShop.Models;
using MusicShop.Models.Interfaces;
using MusicShop.Models.ViewModels;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicShop.Controllers
{
    public class TestController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly AppDbContext _appDbContext;

        public TestController(IProductRepository productRepository, ICategoryRepository categoryRepository, AppDbContext appDbContext)
        {
            this._productRepository = productRepository;
            this._categoryRepository = categoryRepository;
            this._appDbContext = appDbContext;
        }
        

        public IActionResult Index()
        {


            //foreach (var item in _productRepository.AllProducts)
            //{
            //    item.AmountInStock++;
            //    item.InStock = true;

                
            //}
            //_appDbContext.SaveChanges();
            var testViewModel = new TestViewModel()
            {
                //GetProductById = _productRepository.GetProductById(1), //Must return ProductName = " Gibson Les Paul Deluxe Ebony "
                //GetCategoryById = _categoryRepository.GetCategoryById(1), //Must return CategoryName = "Electric Guitars"
                //IncreaseStock = _productRepository.IncreaseStock(1, 1), 
                
                //DecreaseStock = _productRepository.DecreaseStock(1, 17) //Must return 
            };
            
            return View(testViewModel);
        }


        public IActionResult Admin()
        {
            return View();
        }
    }
}
