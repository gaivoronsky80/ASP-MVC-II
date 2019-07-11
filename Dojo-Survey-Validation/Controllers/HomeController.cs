using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dojo_Survey_Validation.Models;

namespace Dojo_Survey_Validation.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        [HttpGet]
        public ViewResult Index()
        {
            return View("Index");
        }

        [Route("validation")]
        [HttpPost]
        public IActionResult Create(Form addUser)
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
        public IActionResult Result(Form result)
        {
            return View("Result", result);
        } 

    }
}
