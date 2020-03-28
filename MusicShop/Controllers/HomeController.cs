using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicShop.Models.ViewModels;
using MusicShop.Models.Repositories;
using MusicShop.Models.Interfaces;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;

        public HomeController(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }
        

        public IActionResult Products()
        {
           
            return View(new ProductViewModel() { AllProducts = _productRepository.AllProducts});
        }

       
    }
}
