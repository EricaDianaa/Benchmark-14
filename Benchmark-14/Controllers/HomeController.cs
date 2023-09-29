using Benchmark_14.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Benchmark_14.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

       public ActionResult RegistroVerbali()
        {
            return View();

        }
        public ActionResult SelectVerbaliPerson ()
        {
            Dipartimento.ListTotVerbali.Clear();
            Dipartimento.SelectVerbaliPerson();
            
            return View(Dipartimento.ListTotVerbali);

        }

        public ActionResult SelectDecurtamentoPunti()
        {
            Dipartimento.ListTotDecurtamentoPunti.Clear();
            Dipartimento.SelectDecurtamentoPunti();

            return View(Dipartimento.ListTotDecurtamentoPunti);

        }

        public ActionResult SelectWhereDecurtamentoPunti()
        {
            Dipartimento.ListWhereDecurtamentoPunti.Clear();
            Dipartimento.SelectWhereDecurtamentoPunti();

            return View(Dipartimento.ListWhereDecurtamentoPunti);

        }

        public ActionResult SelectImporto()
        {
            Dipartimento.ListImporto.Clear();
            Dipartimento.SelectImporto();

            return View(Dipartimento.ListImporto);

        }


    }
}