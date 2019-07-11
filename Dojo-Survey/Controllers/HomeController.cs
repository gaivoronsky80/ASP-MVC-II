using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dojo_Survey.Models;

namespace Dojo_Survey.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        [HttpGet]
        public ViewResult Index()
        {
            return View("Index");
        }

        [Route("result")]
        [HttpPost]
        public IActionResult Result(DojoForm result)
        {
            return View("Result", result);
        }

    }
}
