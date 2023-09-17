using Category.Domain.Interfaces;
using Category.Domain.Models;
using Category.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;

namespace Category.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Index()
        {
           var res= await _unitOfWork.CategoryRepository.GetAll();
            return View(res);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost("Create")]
        public IActionResult Create(CategoryDomain categoryDomain)
        {
            if (categoryDomain.Name == categoryDomain.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "Display order can not be same as Name");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.CategoryRepository.Insert(categoryDomain);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View();
        }
        [Authorize(Roles = "Admin,User")]
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
