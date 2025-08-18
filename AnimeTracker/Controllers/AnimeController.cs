using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;


using AnimeTracker.Models;
using System.Threading.Tasks;
namespace AnimeTracker.Controllers
{
    public class AnimeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create() // create controller
        {
            return View();
        }

        public async Task<ActionResult> Details(int? id) // read controller
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            return View();
        }

        public ActionResult Update()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return View();
        }
    }
}