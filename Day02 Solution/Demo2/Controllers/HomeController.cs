using Demo2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo2.Controllers
{
    //HomeController is usually the name of the master controller
    public class HomeController : Controller
    {
        //Index Action is usually the name of the master action
        public IActionResult Index()
        {
            //return View("Hamada", new Chair());//Hybrid 4th overload
            //return View("Hamada");//return view with specific name

            //return View(new Chair());//Take model to bind view with model data

            return View();//return view with same name as action
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }
    }
}
