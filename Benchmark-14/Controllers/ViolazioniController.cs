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

        public ActionResult Delete(int IdViolazione)
        {
            

         TipoViolazione.SelectWhereId();
            foreach (TipoViolazione item in TipoViolazione.ListViolazioni)
            {
                //ELIMINA funziona con qualche bug
                try
            {
                int idProdo = Convert.ToInt32(Request.QueryString["IdViolazione"]);
               
                if (item.IdViolazione == IdViolazione)
                {

                    //  ToReturn = item;
                    TipoViolazione.Elimina();
               return RedirectToAction("index","Home");
                }    }
                catch (Exception ex)
                {
                    Response.Write($"{ex.Message}");
                }
            }
            return RedirectToAction("index", "Home");

        }

        public ActionResult Edit(int IdViolazione)
        {
            TipoViolazione prod = new TipoViolazione();   
            TipoViolazione.SelectWhereId();
            foreach (TipoViolazione item in TipoViolazione.ListViolazioni)
            {

             
                if (item.IdViolazione == IdViolazione)
                {

                    prod = item;
                    break;
                    //  Prodotto.Modifica();

                }

            }
            return View(prod);
        }
        [HttpPost]
        public ActionResult Edit(TipoViolazione p)
        {

            foreach (TipoViolazione item in TipoViolazione.ListViolazioni)
            {
                //   Prodotto.SelectWhereId();
                if (p.IdViolazione == item.IdViolazione)
                {
                    item.IdViolazione = p.IdViolazione;
                    item.Descrizione = p.Descrizione;
                 
                    string connectionString = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString.ToString();
                    SqlConnection conn2 = new SqlConnection(connectionString);
                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.Connection = conn2;
                    cmd2.CommandText = "UPDATE TIPOVIOLAZIONE SET Descrizione=@Descrizione where IdViolazione=@id";        
                    cmd2.Parameters.AddWithValue("Descrizione", p.Descrizione);                  
                    cmd2.Parameters.AddWithValue("id", p.IdViolazione);

                    conn2.Open();

                    cmd2.ExecuteNonQuery();

                    conn2.Close();

                    //  Prodotto.Modifica(p);

                }

            }
            return RedirectToAction("index","Home");
        }
    }

}