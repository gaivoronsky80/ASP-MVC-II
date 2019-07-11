using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViewModel_Fun.Models;

namespace ViewModel_Fun.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            string message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
            return View("Index", message);
        }

        [Route("numbers")]
        [HttpGet]
        public IActionResult Numbers()
        {
            int[] num = {0,1,2,3,4,5,6,7};
            return View("Numbers", num);
        }

        [Route("users")]
        [HttpGet]
        public IActionResult Users()
        {
            User [] users = {
                new User("Sally", "Moose"),
                new User("Billy", "Joey"),
                new User("Joey", "Billy"),
                new User("Moose", "Sally")
            };
            return View("Users", users);
        }

        [Route("user")]
        [HttpGet]
        public IActionResult User()
        {
            User user = new User("Mosse", "Sally");
            return View("User", user);
        }

    }
}
