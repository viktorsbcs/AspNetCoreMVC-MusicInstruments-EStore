using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicShop.Models;
using MusicShop.Models.ViewModels;
using MusicShop.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicShop.Controllers
{
    public class OrderController : Controller

    {
        private readonly Cart _cart;
        private readonly IOrderRepository _orderRepository;

        public OrderController(Cart cart, IOrderRepository orderRepository)
        {
            this._cart = cart;
            this._orderRepository = orderRepository;
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (ModelState.IsValid)
            {
                var orderNew = _orderRepository.CreateOrder(order);
                TempData["orderId"] = orderNew.OrderId;
                

                return RedirectToAction("OrderComplete");
            }
            return View(order);
        }

        [Authorize]
        // GET: /<controller>/
        public IActionResult Checkout()
        {
            return View();
        }

        public IActionResult OrderComplete()
        {
            var orderId = (int) TempData["orderId"];
            return View(new OrderViewModel() { Order = _orderRepository.GetOrderById(orderId), CartItems = _orderRepository.GetOrderProductList(orderId) });
        }
    }
}
