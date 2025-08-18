using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;


using AnimeTracker.Models;
using System.Threading.Tasks;
using AnimeTracker.Data;
using Microsoft.EntityFrameworkCore;

namespace AnimeTracker.Controllers
{
    public class AnimeController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        public ActionResult Index()
        {

            var animes = _context.Animes.ToList();
            return View();
        }

        [HttpGet]
        public ActionResult Create() // form for creating anime 
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Anime model) // create controller
        {
            _context.Animes.Add(model);
            _context.SaveChanges();
            ViewBag.Message = "Anime Created Successfully";

            return RedirectToAction("Index") ;
        }


        public async Task<ActionResult> Details(int? id) // read controller
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var anime = _context.Animes.Where(x => x.Id == id).FirstOrDefault();

            return View(anime);
        }

        public ActionResult Update()
        {
            return View();
        }

        public ActionResult Delete(int? id)
        {
            var anime = _context.Animes.Where(x => x.Id == id).FirstOrDefault();
            _context.Animes.Remove(anime);
            _context.SaveChanges();
            
            return RedirectToAction("Index");
        }
    }
}