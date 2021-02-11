using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DT102GMom2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DT102GMom2.Controllers
{
    public class HomeController : Controller
    {
        public void Set(string key, string value, int? expireTime)
        {
            CookieOptions option = new CookieOptions();

            if (expireTime.HasValue)
                option.Expires = DateTime.Now.AddMinutes(expireTime.Value);
            else
                option.Expires = DateTime.Now.AddMilliseconds(10);

            Response.Cookies.Append(key, value, option);
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Vikt()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Vikt(HorseModel model)
        {
            if (ModelState.IsValid)
            {
                model.Weight = (float)((4.3 * model.Lance + 3.0 * model.Height) - 785);
                ViewBag.Check = "true";
                Set("horseWeight", model.Weight.ToString(), 60);
                Set("horseLance", model.Lance.ToString(), 60);
                Set("horseHeight", model.Height.ToString(), 60);
            }
            else
            {
                ViewBag.Check = "false";
            }
            return View(model);
        }

    }
}
