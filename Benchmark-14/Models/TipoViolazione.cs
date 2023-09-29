using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Benchmark_14.Models
{
    public class TipoViolazione
    {

        //TIPOVIOLAZIONE
        public int IdViolazione { get; set; }
        [Display(Name = "Descrizione Violazione")]
        public string Descrizione { get; set; }
        public static List<TipoViolazione> ListViolazioni = new List<TipoViolazione>();
        public static void Insert(TipoViolazione p, string messaggio)
        {
            string connection = ConfigurationManager.ConnectionStrings["ConnectionDB"]
               .ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connection);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO TIPOVIOLAZIONE VALUES(@Descrizione)";
                cmd.Parameters.AddWithValue("Descrizione", p.Descrizione);


                int inserimentoEffettuato = cmd.ExecuteNonQuery();

                if (inserimentoEffettuato > 0)
                {
                    messaggio = "Inserimento effetuato con successo";
                }

            }
            catch (Exception ex) { messaggio = $"{ex}"; }
            finally { conn.Close(); }
        }
        public static void Select()
        {
            string connection = ConfigurationManager.ConnectionStrings["ConnectionDB"]
             .ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("select * from TIPOVIOLAZIONE ", conn);

            SqlDataReader sqlreader;
            conn.Open();

            sqlreader = cmd.ExecuteReader();


            while (sqlreader.Read())
            {

                TipoViolazione prod = new TipoViolazione();
                prod.IdViolazione = Convert.ToInt16(sqlreader["IdViolazione"]);
                prod.Descrizione = sqlreader["Descrizione"].ToString();
                ListViolazioni.Add(prod);
            }
        }
        public static List<TipoViolazione> Selected()
        {
            string connection = ConfigurationManager.ConnectionStrings["ConnectionDB"]
             .ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("select * from TIPOVIOLAZIONE ", conn);

            SqlDataReader sqlreader;
            conn.Open();

            sqlreader = cmd.ExecuteReader();


            while (sqlreader.Read())
            {

                TipoViolazione prod = new TipoViolazione();
                prod.IdViolazione = Convert.ToInt16(sqlreader["IdViolazione"]);
                prod.Descrizione = sqlreader["Descrizione"].ToString();
                ListViolazioni.Add(prod);
            }
            return ListViolazioni;
        }

        public static List<SelectListItem> DropdownViolazioni = new List<SelectListItem>();

        public  static void Dropdown()
        {
            List<TipoViolazione> tipoViolazione = new List<TipoViolazione>();
              tipoViolazione=  TipoViolazione.Selected();
                foreach (TipoViolazione item in tipoViolazione)
                {
                    SelectListItem l = new SelectListItem { Text = item.Descrizione, Value = item.IdViolazione.ToString() };
                   DropdownViolazioni.Add(l);
                }
              
            
        }

        public static void SelectWhereId()
        {
            string connection = ConfigurationManager.ConnectionStrings["ConnectionDB"]
         .ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd1 = new SqlCommand("select * from TIPOVIOLAZIONE where IdViolazione=@id", conn);
            SqlDataReader sqlreader1;
            conn.Open();

            cmd1.Parameters.AddWithValue("id", HttpContext.Current.Request.QueryString["IdViolazione"]);
            sqlreader1 = cmd1.ExecuteReader();
      TipoViolazione prod = new TipoViolazione();
            while (sqlreader1.Read())
            {
                TipoViolazione.ListViolazioni.Clear();
          
                prod.IdViolazione = Convert.ToInt16(sqlreader1["IdViolazione"]);
                prod.Descrizione = sqlreader1["Descrizione"].ToString();
              

            }
            ListViolazioni.Add(prod);
        }

        public static void Elimina()
        {
            string connection = ConfigurationManager.ConnectionStrings["ConnectionDB"]
            .ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM TIPOVIOLAZIONE where IdViolazione =@id";
            cmd.Parameters.AddWithValue("id", HttpContext.Current.Request.QueryString["IdViolazione"]);

            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();
        }

    }
}