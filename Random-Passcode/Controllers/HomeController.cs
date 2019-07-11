using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Random_Passcode.Models;

namespace Random_Passcode.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("Count") == null)
            {
                HttpContext.Session.SetInt32("Count", 1);
            }
            else
            {
                HttpContext.Session.SetInt32("Count", ((int)HttpContext.Session.GetInt32("Count") + 1));
            }
            ViewBag.Count = (int)HttpContext.Session.GetInt32("Count");
            ViewBag.Random = Generate.MakeStr();
            return View();
        }
    public class Generate
    {
        public static Random rnd = new Random();
        public static string MakeStr()
        {
            string Str = "";
            int makeChar;
            while (Str.Length < 14)
            {
                int num = rnd.Next(1, 3);
                if (num == 1)
                {
                    makeChar = rnd.Next(48, 58);
                }
                else 
                {
                    makeChar = rnd.Next(65, 91);
                }
                char letter = (char)makeChar;
                Str += letter.ToString();
            }
            return Str;
        }
    }

    }
}
