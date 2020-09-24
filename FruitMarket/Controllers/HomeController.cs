using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FruitMarket.Models;
using Dal;
using Dal.Models;
using System.Linq.Expressions;

namespace FruitMarket.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Repository<CartItem> _cartRepository;
        private readonly Repository<ICalculator<Cart>> _promoRepository;

        public HomeController(ILogger<HomeController> logger, Repository<CartItem> cartRepository, Repository<ICalculator<Cart>> promoRepository)
        {
            _logger = logger;
            _cartRepository = cartRepository;
            _promoRepository = promoRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //Expression<Func<KeyValuePair<CartItem, bool>, bool>> predicate = kvp => kvp.Value;

            Cart cart = new Cart();
            cart.Items  = _cartRepository.Find(kvp => kvp.Value).Result.ToList();
            return View(cart);
        }

        [HttpPost]
        public IActionResult Index(Cart cart)
        {
            var currentPromos = _promoRepository.Find(kvp => kvp.Value == cart.IncludePromotions).Result;

            CartCalculator calculator = new CartCalculator(currentPromos);
            calculator.Calculate(cart);
            return View(cart);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
