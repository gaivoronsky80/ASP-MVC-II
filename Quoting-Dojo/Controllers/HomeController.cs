using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quoting_Dojo.Models;
using DbConnection;

namespace Quoting_Dojo.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("/quotes")]
        public IActionResult Create(User newUser)
        {
            System.Console.WriteLine(newUser);
            if (ModelState.IsValid)
            {
                string query = $"INSERT INTO users (Name, Quote, created_at, updated_at) VALUES ('{newUser.Name}', '{newUser.Quote}', NOW(), NOW())";
                DbConnector.Execute(query);
                return RedirectToAction("All");
            }
            else
                return View("Index");
        }
        [HttpGet("/quotes")]
        public IActionResult All()
        {
            List<Dictionary<string,object>> AllUsers = DbConnector.Query("SELECT * FROM users");
            System.Console.WriteLine(AllUsers.ToString());
            return View("Quotes", AllUsers);
        }
                public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
