using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TweetBL;

namespace TweetApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Login()
        {
            AuthenticationBL authenticationBL = new AuthenticationBL();
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.PersonModel person)
        {
            AuthenticationBL authenticationBL = new AuthenticationBL();
            if (authenticationBL.CheckPersonDetails(person.UserId, person.Password))
            {
                Session["UserId"] = person.UserId;
                return RedirectToAction("UserHomePage");
            }
            else
            {
                person.ErrorMsg = "Login Failed";
                return View(person);
            }
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(Models.PersonModel person)
        {
            AuthenticationBL authenticationBL = new AuthenticationBL();
            if (authenticationBL.PostPersonalDetails(new TweetBL.Models.PersonModel() { UserId = person.UserId, Password = person.Password, FullName = person.FullName, Email = person.Email }))
                return RedirectToAction("Login");
            else
                return View();
        }

        public ActionResult UserHomePage()
        {
            ViewBag.TweetInfo = GetTweetDetails();
            return View();
        }

        [HttpPost]
        public ActionResult SaveTweet(string userId, string msg)
        {
            AuthenticationBL authenticationBL = new AuthenticationBL();
            bool Result = true;
            Result = authenticationBL.SaveTweet(userId, msg);
            return Json(new { Result });
        }

        public List<Models.TweetModel> GetTweetDetails()
        {
            AuthenticationBL authenticationBL = new AuthenticationBL();
            var tweetInfo = authenticationBL.GetTweet(Convert.ToString(Session["UserId"]));
            if (tweetInfo != null)
                return tweetInfo.Select(s => new Models.TweetModel() { UserId = s.UserId, Message = s.Message, Created = s.Created }).ToList();
            else
                return null;
        }
    }
}