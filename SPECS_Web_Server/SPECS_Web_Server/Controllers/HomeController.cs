using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SPECS_Web_Server.Data;
using SPECS_Web_Server.Models;
using SPECS_Web_Server.ViewModels;

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

        [HttpGet]
        public IActionResult Create_Account()
        {
            ViewData["Message"] = "Create Your Account";

            return View();
        }

        [HttpPost]
        public IActionResult Create_Account(CreateUser user, string alexaID){
            User newUser = new User{
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.Phone,
                Username = user.Username
            };

            using (var db = new AppDb())
            {
                db.Connection.OpenAsync();
                var query = new UserQuery(db);
                query.RegisterUserAsync(newUser, user.Password);
            }
            return View("~/Views/Home/Index.cshtml");
        }

        public IActionResult OAuth()
        {
            ViewData["Message"] = "oAuth Page";

            return View();
        }
    }
}
