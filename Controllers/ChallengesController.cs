using Microsoft.AspNetCore.Mvc;
using DanielsCodingChallenge.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace DanielsCodingChallenge.Controllers
{

    public class ChallengesController : Controller
    {
        private readonly Context _context;
        public ChallengesController(Context context)
        {
            _context = context;
        }
        //public IActionResult Index()
        //{
            
        //    UserModel user = _context.Users.FirstOrDefault(u => u.Username == HttpContext.Session.GetString("username") && u.Password == HttpContext.Session.GetString("password"));
            
        //    if (user == null) return NotFound("Please log in to participate.");

        //    return View(user);
        //}

        public IActionResult Index(string fragment)
        {

            UserModel user = _context.Users.FirstOrDefault(u => u.Username == HttpContext.Session.GetString("username") && u.Password == HttpContext.Session.GetString("password"));

            if (user == null) return NotFound("Please log in to participate.");

            List<string> challengeTitles = new List<string>();
            challengeTitles.Add("The head hunter");
            challengeTitles.Add("The map");
            challengeTitles.Add("The SJ hack");
            challengeTitles.Add("The train tickets");
            challengeTitles.Add("The flowers");
            challengeTitles.Add("");
            challengeTitles.Add("");
            challengeTitles.Add("");
            challengeTitles.Add("");
            challengeTitles.Add("");

            ViewData["ChallengeTitles"] = challengeTitles;

            ViewData["Message"] = fragment;
            return View(user);
        }

        public IActionResult C1()
        {
            UserModel user = _context.Users.FirstOrDefault(u => u.Username == HttpContext.Session.GetString("username") && u.Password == HttpContext.Session.GetString("password"));

            if (user == null) return NotFound("Please log in to participate.");

            if (user.Score < 0) return NotFound("You haven't unlocked this challenge yet.");

            return View();
        }
        
        [HttpPost]
        public IActionResult C1(int answer)
        {
            if (answer == 72)
            {
                string s;
                UserModel user = _context.Users.FirstOrDefault(u => u.Username == HttpContext.Session.GetString("username") && u.Password == HttpContext.Session.GetString("password"));

                if (user.Score == 0)
                {
                    user.Score++;
                    _context.SaveChanges();
                    s = "Correct answer! New Challenge unlocked!";
                    return RedirectToAction("Index", "Challenges", new { fragment = s });
                      
                }

                s = "Correct answer! But you allready finished this challenge.";
                return RedirectToAction("Index", "Challenges", new { fragment = s });
            }
            else
            {
                return Ok("Wrong answer!");
            }
        }

        public IActionResult C2()
        {
            UserModel user = _context.Users.FirstOrDefault(u => u.Username == HttpContext.Session.GetString("username") && u.Password == HttpContext.Session.GetString("password"));

            if (user == null) return NotFound("Please log in to participate.");

            if (user.Score < 1) return NotFound("You haven't unlocked this challenge yet.");

            return View();
        }

        [HttpPost]
        public IActionResult C2(int answer)
        {
            if (answer == 101)
            {
                string s;
                UserModel user = _context.Users.FirstOrDefault(u => u.Username == HttpContext.Session.GetString("username") && u.Password == HttpContext.Session.GetString("password"));

                if (user.Score == 1)
                {
                    user.Score++;
                    _context.SaveChanges();
                    s = "Correct answer! New Challenge unlocked!";
                    return RedirectToAction("Index", "Challenges", new { fragment = s });

                }

                s = "Correct answer! But you allready finished this challenge.";
                return RedirectToAction("Index", "Challenges", new { fragment = s });
            }
            else
            {
                return Ok("Wrong answer!");
            }
        }

        public IActionResult C3()
        {
            UserModel user = _context.Users.FirstOrDefault(u => u.Username == HttpContext.Session.GetString("username") && u.Password == HttpContext.Session.GetString("password"));

            if (user == null) return NotFound("Please log in to participate.");

            if (user.Score < 2) return NotFound("You haven't unlocked this challenge yet.");

            return View();
        }

        [HttpPost]
        public IActionResult C3(int answer)
        {
            if ((answer == 9344) && (answer == 9352))
            {
                string s;
                UserModel user = _context.Users.FirstOrDefault(u => u.Username == HttpContext.Session.GetString("username") && u.Password == HttpContext.Session.GetString("password"));

                if (user.Score == 2)
                {
                    user.Score++;
                    _context.SaveChanges();
                    s = "Correct answer! New Challenge unlocked!";
                    return RedirectToAction("Index", "Challenges", new { fragment = s });

                }

                s = "Correct answer! But you allready finished this challenge.";
                return RedirectToAction("Index", "Challenges", new { fragment = s });
            }
            else
            {
                return Ok("Wrong answer!");
            }
        }

        public IActionResult C4()
        {
            UserModel user = _context.Users.FirstOrDefault(u => u.Username == HttpContext.Session.GetString("username") && u.Password == HttpContext.Session.GetString("password"));

            if (user == null) return NotFound("Please log in to participate.");

            if (user.Score < 3) return NotFound("You haven't unlocked this challenge yet.");

            return View();
        }

        [HttpPost]
        public IActionResult C4(int answer)
        {
            if (answer == 209)
            {
                string s;
                UserModel user = _context.Users.FirstOrDefault(u => u.Username == HttpContext.Session.GetString("username") && u.Password == HttpContext.Session.GetString("password"));

                if (user.Score == 3)
                {
                    user.Score++;
                    _context.SaveChanges();
                    s = "Correct answer! New Challenge unlocked!";
                    return RedirectToAction("Index", "Challenges", new { fragment = s });

                }

                s = "Correct answer! But you allready finished this challenge.";
                return RedirectToAction("Index", "Challenges", new { fragment = s });
            }
            else
            {
                return Ok("Wrong answer!");
            }
        }

        public IActionResult C5()
        {
            UserModel user = _context.Users.FirstOrDefault(u => u.Username == HttpContext.Session.GetString("username") && u.Password == HttpContext.Session.GetString("password"));

            if (user == null) return NotFound("Please log in to participate.");

            if (user.Score < 4) return NotFound("You haven't unlocked this challenge yet.");

            return View();
        }

        [HttpPost]
        public IActionResult C5(int answer)
        {
            if (answer == 11483)
            {
                string s;
                UserModel user = _context.Users.FirstOrDefault(u => u.Username == HttpContext.Session.GetString("username") && u.Password == HttpContext.Session.GetString("password"));

                if (user.Score == 4)
                {
                    user.Score++;
                    _context.SaveChanges();
                    s = "Correct answer! New Challenge unlocked!";
                    return RedirectToAction("Index", "Challenges", new { fragment = s });

                }

                s = "Correct answer! But you allready finished this challenge.";
                return RedirectToAction("Index", "Challenges", new { fragment = s });
            }
            else
            {
                return Ok("Wrong answer!");
            }
        }
    }
}
