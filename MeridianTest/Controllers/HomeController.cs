using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MeridianTest.Models;
using MeridianTest.Service;
using System.Text.RegularExpressions;
using MeridianTest.Intefaces;

namespace MeridianTest.Controllers {
	public class HomeController : Controller {
        private readonly IMeridian meridian;

        public HomeController(IMeridian meridian)
        {
            this.meridian = meridian;
        }
		public async Task<IActionResult> Index() {
			ViewBag.meridian = await this.meridian.Get();
			return View();
		}

		public IActionResult About() {
			ViewData["Message"] = "Your application description page.";

			return View();
		}

		public IActionResult Contact() {
			ViewData["Message"] = "Your contact page.";

			return View();
		}

		public IActionResult Privacy() {
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error() {
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
