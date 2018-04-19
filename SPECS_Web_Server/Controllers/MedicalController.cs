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
        public async Task<IActionResult> Post([FromBody]MedicalSensorData body)
        {
            user = _context.Users.Include(ApplicationUser => ApplicationUser.MedicalSensorData)
                .Single(u => u.Email == body.UserEmail);
            if(user != null)
            {
                user.MedicalSensorData.Add(new MedicalSensorData()
                {
                    UserEmail = body.UserEmail,
                    ECG = body.ECG,
                    SpO2 = body.SpO2,
                    Respiration = body.Respiration,
                    Pulse = body.Pulse,
                    BloodPressure = body.BloodPressure,
                    health = body.health

                });
                await _context.SaveChangesAsync();
            }
            //Get User
            //Save MedicalSensorData entry to user
            return Ok();
        }
    }
    
}
