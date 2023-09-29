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
            
            return PartialView(Dipartimento.ListTotVerbali);

        }

        public ActionResult SelectDecurtamentoPunti()
        {
            Dipartimento.ListTotDecurtamentoPunti.Clear();
            Dipartimento.SelectDecurtamentoPunti();

            return PartialView(Dipartimento.ListTotDecurtamentoPunti);

        }

        public ActionResult SelectWhereDecurtamentoPunti()
        {
            Dipartimento.ListWhereDecurtamentoPunti.Clear();
            Dipartimento.SelectWhereDecurtamentoPunti();

            return PartialView(Dipartimento.ListWhereDecurtamentoPunti);

        }

        public ActionResult SelectImporto()
        {
            Dipartimento.ListImporto.Clear();
            Dipartimento.SelectImporto();

            return PartialView(Dipartimento.ListImporto);

        }

        public ActionResult AnagrafeSelect()
        {
            Anagrafe.ListAnagrafe.Clear();
            Anagrafe.Select();

            return View(Anagrafe.ListAnagrafe);

        }
        public ActionResult VerbaleSelect()
        {
            Verbale.ListVerbale.Clear();
            Verbale.Select();

            return View(Verbale.ListVerbale);

        }
        public ActionResult ViolazioneSelect()
        {
            TipoViolazione.ListViolazioni.Clear();
            TipoViolazione.Select();

            return View(TipoViolazione.ListViolazioni);

        }

        public ActionResult ReturnPartial()
        {
            return PartialView("SelectVerbaliPerson");

        }
    }

}