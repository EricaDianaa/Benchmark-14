using Benchmark_14.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Benchmark_14.Controllers
{
    public class TrasgressioniController : Controller
    {
        // GET: Trasgressioni
        public ActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Anagrafe p)
        {
            if (ModelState.IsValid)
            {
                Anagrafe.Insert(p, ViewBag.messaggio);
            }

            return RedirectToAction("index","Home");
        }
    }
}