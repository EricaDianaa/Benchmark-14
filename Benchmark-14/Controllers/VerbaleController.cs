using Benchmark_14.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Benchmark_14.Controllers
{
    public class VerbaleController : Controller
    {  
        
      public List<SelectListItem> list = new List<SelectListItem>();
        // GET: Verbale
        [HttpGet]
        public ActionResult Create()
        {
            TipoViolazione.ListViolazioni.Clear();
            TipoViolazione.DropdownViolazioni.Clear();
            TipoViolazione.Dropdown();
            ViewBag.drop = TipoViolazione.DropdownViolazioni;
            Anagrafe.ListAnagrafe.Clear();
            Anagrafe.DropdownAnagrafe.Clear();
            Anagrafe.Dropdown();
            ViewBag.drop1 = Anagrafe.DropdownAnagrafe;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Verbale p,string IdAnagrafe,string IdViolazione)
        {

            TipoViolazione.ListViolazioni.Clear();
            TipoViolazione.DropdownViolazioni.Clear();
            TipoViolazione.Dropdown();
            ViewBag.drop = TipoViolazione.DropdownViolazioni;
            Anagrafe.ListAnagrafe.Clear();
            Anagrafe.DropdownAnagrafe.Clear();
            Anagrafe.Dropdown();
            ViewBag.drop1 = Anagrafe.DropdownAnagrafe;
            if (ModelState.IsValid)
            {
                Verbale.Insert(p, ViewBag.messaggio,IdAnagrafe,IdViolazione);
            }

            return RedirectToAction("index", "Home");
        }

      

    }
}