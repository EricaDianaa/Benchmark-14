using Benchmark_14.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Benchmark_14.Controllers
{
    public class VerbaleController : Controller
    {  
        
      public List<SelectListItem> list = new List<SelectListItem>();
        // GET: Verbale
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Verbale p)
        {
            if (ModelState.IsValid)
            {
                Verbale.Insert(p, ViewBag.messaggio);
            }

            return RedirectToAction("index", "Home");
        }
    }
}