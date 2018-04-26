using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SPECS_Web_Server.Data;
using SPECS_Web_Server.Models;
using SPECS_Web_Server.Models.AdminViewModels;
using SPECS_Web_Server.Services;
using OtpNet;

namespace SPECS_Web_Server.Controllers
{
    [Authorize(Roles="Admin")]
    [Route("[controller]/[action]")]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;
        private readonly UrlEncoder _urlEncoder;

        private readonly ApplicationDbContext _context;

        private const string AuthenticatorUriFormat = "otpauth://totp/{0}:{1}?secret={2}&issuer={0}&digits=6";
        private const string RecoveryCodesKey = nameof(RecoveryCodesKey);

        public AdminController(
          UserManager<ApplicationUser> userManager,
          SignInManager<ApplicationUser> signInManager,
          IEmailSender emailSender,
          ILogger<ManageController> logger,
          UrlEncoder urlEncoder,
          ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _logger = logger;
            _urlEncoder = urlEncoder;
            _context = context;
        }

        [TempData]
        public string StatusMessage { get; set; }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var model = new AdminIndexViewModel
            {
                Users = await _userManager.Users.ToListAsync()
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Fulfillments()
        {
            var model = new AdminFulfillmentViewModel
            {
                Fulfillments = await _context.Fulfillments.Include(u => u.ApplicationUser).ToListAsync()
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ChangeFulfillmentNote(int FulfillmentID)
        {
            
            Fulfillment fulfillment = await _context.Fulfillments.Include(u => u.ApplicationUser).SingleAsync(f => f.ID == FulfillmentID);
            if(fulfillment == null)
            {
                 throw new ApplicationException($"AAAAAAAAAAAHHHHHHHHHHHHHH!");
            }

            var model = new AdminChangeFulfillmentNoteViewModel
            {
                FulfillmentID = FulfillmentID,
                CurrentNote = fulfillment.Note
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeFulfillmentNote(AdminChangeFulfillmentNoteViewModel model)
        {
            Fulfillment fulfillment = await _context.Fulfillments.Include(u => u.ApplicationUser).SingleAsync(f => f.ID == model.FulfillmentID);
            if(fulfillment == null)
            {
                 throw new ApplicationException($"AAAAAAAAAAAHHHHHHHHHHHHHH!");
            }

            fulfillment.Note = model.Note;
            _context.SaveChanges();

            return RedirectToAction(nameof(Fulfillments));
        }

        [HttpPost]
        public async Task<IActionResult> AdvanceFulfillment(int FulfillmentID)
        {
            Fulfillment fulfillment = await _context.Fulfillments.Include(u => u.ApplicationUser).SingleAsync(f => f.ID == FulfillmentID);
            if(fulfillment == null)
            {
                 throw new ApplicationException($"AAAAAAAAAAAHHHHHHHHHHHHHH!");
            }
            
            if( fulfillment.Status < FulfillmentStatus.Fulfilled) fulfillment.Status++;
            _context.SaveChanges();

            return RedirectToAction(nameof(Fulfillments));
        }

    }
}