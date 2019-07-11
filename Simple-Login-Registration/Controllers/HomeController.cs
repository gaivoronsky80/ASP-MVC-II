using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Simple_Login_Registration.Models;

namespace Simple_Login_Registration.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [Route("register")]
        [HttpPost]
        public IActionResult addUser(Register addUser)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("Result");
            }
            else
            {
                return View("Index");
            }
            
        }
        [Route("login")]
        [HttpPost]
        public IActionResult feechUser(Login feechUser)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("Result");
            }
            else
            {
                return View("Index");
            }
            
        }
        [Route("result")]
        [HttpGet]
        public IActionResult Result()
        {
            return View();
        }
    }
}
