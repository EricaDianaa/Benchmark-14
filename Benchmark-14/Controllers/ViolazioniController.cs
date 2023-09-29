using Benchmark_14.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Benchmark_14.Controllers
{
    public class ViolazioniController : Controller
    {

        // GET: Violazioni
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(TipoViolazione p)
        {

            if (ModelState.IsValid)
            {
                TipoViolazione.Insert(p, ViewBag.messaggio);
            }


            return View();
        }
        public ActionResult SelectViolazioni()
        {

            TipoViolazione.ListViolazioni.Clear();
            TipoViolazione.Select();
            return PartialView(TipoViolazione.ListViolazioni);
        }

   
        //    public List<SelectListItem> DropdownViolazioni
        //    {
        //    get
        //    {
        //        List<TipoViolazione> tipoViolazione = new List<TipoViolazione>();
        //        tipoViolazione = TipoViolazione.Selected();
        //        List<TipoViolazione> selectList = new List<TipoViolazione>();
        //        foreach (TipoViolazione item in tipoViolazione)
        //        {
        //            SelectListItem l = new SelectListItem { Text = item.Descrizione, Value = item.IdViolazione.ToString() };
        //            selectList.Add(l);
        //        }
        //        return selectList;
        //    }
        //}
    }

}