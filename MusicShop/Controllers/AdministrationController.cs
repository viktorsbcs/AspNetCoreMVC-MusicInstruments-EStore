using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicShop.Models.Interfaces;
using MusicShop.Models.ViewModels;

namespace MusicShop.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;

        public AdministrationController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {

            this._productRepository = productRepository;
            this._categoryRepository = categoryRepository;
        }

        
        [HttpGet]
        public IActionResult AddProduct()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(AddProductViewModel model)
        {

            return View();
        }

        public IActionResult AdminPanel()
        {
            return View();
        }
    }
}