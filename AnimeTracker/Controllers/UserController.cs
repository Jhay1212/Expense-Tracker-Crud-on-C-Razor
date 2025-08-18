using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AnimeTracker.Models;


namespace AnimeTracker.Controllers
{
    public class UserController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Signup()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

       
    }
}