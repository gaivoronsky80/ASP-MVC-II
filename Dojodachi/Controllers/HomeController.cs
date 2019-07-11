using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dojodachi.Models;
using Microsoft.AspNetCore.Http;

namespace Dojodachi.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        [HttpGet]
        public IActionResult Index()
			{
				HttpContext.Session.SetInt32("Happiness", 20);
				HttpContext.Session.SetInt32("Fullness", 20);
				HttpContext.Session.SetInt32("Energy", 50);
				HttpContext.Session.SetInt32("Meals", 3);
				return RedirectToAction("Dojodachi");
			}

            [Route("dojodachi")]
			[HttpGet]
			public IActionResult Dojodachi()
			{
				int? energy = HttpContext.Session.GetInt32("Energy");
				int? fullness = HttpContext.Session.GetInt32("Fullness");
				int? happiness = HttpContext.Session.GetInt32("Happiness");
				int? meals = HttpContext.Session.GetInt32("Meals");
				if (energy <= 0 || happiness <= 0)
				{
					ViewBag.Over = true;
					ViewBag.Win = false;
				}
				if (energy > 100 && happiness > 100 && energy > 100)
				{
					ViewBag.Over = true;
					ViewBag.Win = true;
				}
				ViewBag.Happiness = happiness;
				ViewBag.Fullness = fullness;
				ViewBag.Energy = energy;
				ViewBag.Meals = meals;
				ViewBag.Log = HttpContext.Session.GetString("Log");
				return View("Index");
			}

            [HttpGet("feed")]
			public IActionResult Feed()
			{
				int? fullness = HttpContext.Session.GetInt32("Fullness");
				int? meals = HttpContext.Session.GetInt32("Meals");
				if (meals > 0)
				{
					Random rand = new Random();
					int increase = 0;
					if (rand.Next(0,4) >= 1)
						increase = rand.Next(5,11);
					fullness += increase;
					meals -= 1;
					HttpContext.Session.SetString("Log", $"You fed your Dojodachi. Meals -1, Fullness +{increase}.");
					HttpContext.Session.SetInt32("Fullness", (int)fullness);
					HttpContext.Session.SetInt32("Meals", (int)meals);
				}
				else
				{
					HttpContext.Session.SetString("Log", "You have no more meals remaining. You could not feed your Dojodachi");
				}
				return RedirectToAction("Dojodachi");
			}

            [HttpGet("play")]
			public IActionResult Play()
			{
				int? energy = HttpContext.Session.GetInt32("Energy");
				int? happiness = HttpContext.Session.GetInt32("Happiness");
				energy -= 5;
				Random rand = new Random();
				int increase = 0;
				if (rand.Next(0,4) >= 1)
					increase = rand.Next(5,11);
				happiness += increase;
				HttpContext.Session.SetString("Log", $"You played with your DojoDachi. Happiness +{increase}, Energy -5");
				HttpContext.Session.SetInt32("Energy", (int)energy);
				HttpContext.Session.SetInt32("Happiness", (int)happiness);
				return RedirectToAction("Dojodachi");
			}

            [HttpGet("work")]
			public IActionResult Work()
			{
				int? meals = HttpContext.Session.GetInt32("Meals");
				int? energy = HttpContext.Session.GetInt32("Energy");
				energy -= 5;
				Random rand = new Random();
				int increase = rand.Next(1,4);
				meals += increase;
				HttpContext.Session.SetString("Log", $"Dojodachi worked! Energy -5, Meals +{increase}");
				HttpContext.Session.SetInt32("Meals", (int)meals);
				HttpContext.Session.SetInt32("Energy", (int)energy);
				return RedirectToAction("Dojodachi");
			}

            [HttpGet("sleep")]
			public IActionResult Sleep()
			{
				int? energy = HttpContext.Session.GetInt32("Energy");
				int? fullness = HttpContext.Session.GetInt32("Fullness");
				int? happiness = HttpContext.Session.GetInt32("Happiness");
				energy += 15;
				fullness -= 5;
				happiness -= 5;
				HttpContext.Session.SetString("Log", "Dojodachi slept. Energy +15, Fullness -5, Happiness -5");
				HttpContext.Session.SetInt32("Energy", (int)energy);
				HttpContext.Session.SetInt32("Fullness", (int)fullness);
				HttpContext.Session.SetInt32("Happiness", (int)happiness);
				return RedirectToAction("Dojodachi");
			}

            [HttpGet("restart")]
			public IActionResult Restart()
			{
				HttpContext.Session.Clear();
				return RedirectToAction("Index");
			}
    }
}
