using Newtonsoft.Json.Linq;
using SPECS_Web_Server.Data;
using SPECS_Web_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace SPECS_Web_Server.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class MedicalController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        
        public MedicalController(ApplicationDbContext context, UserManager<ApplicationUser> userManager){
            _context = context;
            _userManager = userManager;
        }

        //POST api/alexarequest
        [HttpPost]
        public IActionResult Post([FromBody]MedicalSensorData body)
        {
            //Get User
            //Save MedicalSensorData entry to user
            return Ok();

        }
    }
    
}
