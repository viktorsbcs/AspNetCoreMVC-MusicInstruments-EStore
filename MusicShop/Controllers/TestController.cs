using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicShop.Models.Interfaces;
using MusicShop.Models.ViewModels;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicShop.Controllers
{
    public class TestController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public TestController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            this._productRepository = productRepository;
            this._categoryRepository = categoryRepository;
        }
        

        public IActionResult Index()
        {
            var testViewModel = new TestViewModel()
            {
                GetProductById = _productRepository.GetProductById(1), //Must return ProductName = " Gibson Les Paul Deluxe Ebony "
                GetCategoryById = _categoryRepository.GetCategoryById(1), //Must return CategoryName = "Electric Guitars"
                //IncreaseStock = _productRepository.IncreaseStock(1, 4), 
                //DecreaseStock = _productRepository.DecreaseStock(1, 4) //Must return 
            };
            
            return View(testViewModel);
        }
    }
}
