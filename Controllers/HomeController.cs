using DanielsCodingChallenge.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Providers.Entities;

namespace DanielsCodingChallenge.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Context _context;
        //public HomeController(Context context)
        //{
        //    _context = context;
        //}

        public HomeController(ILogger<HomeController> logger, Context context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            string username;

            if (HttpContext.Session.GetString("username") != null)
            {
                username = HttpContext.Session.GetString("username");
            }
            else
            {
                username = "none";    
            }

            ViewData["username"] = username;

            return View();
        }

        public IActionResult Login()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username == null)
            {
                return Ok("You need to provide a username.");
                        }

            if (password == null)
            {
                return Ok("You need to provide a password.");
            }

            UserModel uName = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (uName != null)
            {
                HttpContext.Session.SetString("username", uName.Username);
                HttpContext.Session.SetString("password", uName.Password);
            }
            else
            {
                return Ok("Wrong username or password!");
            }
           
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Register(string username, string password)
        {
            if (username == null)
            {
                return Ok("You need to provide a username.");
            }

            if (password == null)
            {
                return Ok("You need to provide a password.");
            }

            if (_context.Users.Any(u => u.Username == username))
            {
                return Ok("Username allready in use!");
            }

            UserModel user = new UserModel();
            user.Username = username;
            user.Password = password;
            user.Score = 0;

            _context.Users.Add(user);
            _context.SaveChanges();
                
            HttpContext.Session.SetString("username", username);
            HttpContext.Session.SetString("password", password);
            
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Leaderboard()
        {

            var userList = _context.Users.ToList();
            
            List<LeaderboardViewModel> leaderList = new List<LeaderboardViewModel>();
            
            foreach (var user in userList)
            {
                leaderList.Add(new LeaderboardViewModel() { UserName = user.Username, Score = user.Score}); 
            }

            foreach (var l in leaderList)
            {
                l.Percent = Convert.ToInt32(100.00 * (l.Score / 5.00));
            }

            

            return View(leaderList.OrderByDescending(x => x.Score));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
