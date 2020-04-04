using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicShop.Models;
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

        
        public IActionResult AdminPanel()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
          
            return View(new AddProductViewModel() {  CategoryList = _categoryRepository.AllCategories});
        }

        [HttpPost]
        public IActionResult AddProduct(AddProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product()
                {

                    ProductName = model.ProductName,
                    CategoryId = model.CategoryId,
                    ShortDescription = model.ShortDescription,
                    LongDescription = model.LongDescription,
                    AmountInStock = model.AmountInStock,
                    ImageThumbnailUrl = model.ImageThumbnailUrl,
                    ImageUrl = model.ImageUrl,
                    InStock = true,
                    Price = (decimal)model.Price
                };

                _productRepository.CreateProduct(product);
                return RedirectToAction("AdminPanel");
            }

            ModelState.AddModelError("", "Information incorrect");
            

            return View(model);
        }


        public IActionResult AddCategory()
        {

            //Category category = new Category()
            //{
            //    CategoryName = "Strings",
            //    CategoryDescription = "Guitar and bass strings"
            //};

            //_categoryRepository.CreateCategory(category);
            return RedirectToAction("AdminPanel");
        }
    }


}