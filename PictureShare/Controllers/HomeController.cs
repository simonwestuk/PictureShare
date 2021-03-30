﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PictureShare.Data;
using PictureShare.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PictureShare.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<UserModel> _signInManager;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, SignInManager<UserModel> signInManager, ApplicationDbContext context)
        {
            _logger = logger;
            _signInManager = signInManager;
            _context = context;
        }


        [Authorize]
        public async Task<IActionResult> Index(string SearchBy, string SortBy)
        {
            var data = _context.Picture.Where(x => x.Public);

            if (!String.IsNullOrEmpty(SearchBy))
            {
                ViewData["Search"] = SearchBy;
                data = data.Where(x => x.Caption.Contains(SearchBy) || x.UserEmail.Contains(SearchBy));
            }
            
            switch (SortBy)
            {
                case "captionAZ":
                    data = data.OrderBy(x => x.Caption);
                    break;
                case "captionZA":
                    data = data.OrderByDescending(x => x.Caption);
                    break;
                case "userAZ":
                    data = data.OrderBy(x => x.UserEmail);
                    break;
                case "userZA":
                    data = data.OrderByDescending(x => x.UserEmail);
                    break;
            }











            return View(await data.ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //GET Login

        public IActionResult Login()
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            
           return View();
        }

        //POST Login
        [HttpPost, ActionName("Login")]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {


            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, isPersistent: true, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "The credentials you have provided are incorrect.");
                    return View();
                }

            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
