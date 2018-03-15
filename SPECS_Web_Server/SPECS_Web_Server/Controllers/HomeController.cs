﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SPECS_Web_Server.Models;

namespace SPECS_Web_Server.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
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

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Login()
        {
            ViewData["Message"] = "Login Page";

            return View();
        }

        public IActionResult Create_Account()
        {
            ViewData["Message"] = "Create Your Account";

            return View();
        }

        public IActionResult OAuth()
        {
            ViewData["Message"] = "oAuth Page";

            return View();
        }
    }
}
