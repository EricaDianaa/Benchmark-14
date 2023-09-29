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
    public class Anagrafe
    {
        //ANAGRAFE
        public int IdPersona { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Indirizzo { get; set; }
        public string Città { get; set; }
        public int CAP { get; set; }
        [Display(Name = "Codice fiscale")]
        public string CodiceFiscale { get; set; }
        public static List<Anagrafe>ListAnagrafe=new List<Anagrafe>();

        public static void Insert(Anagrafe p, string messaggio)
        {
            string connection = ConfigurationManager.ConnectionStrings["ConnectionDB"]
               .ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connection);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO ANAGRAFICA VALUES(@Cognome,@Nome,@Indirizzo,@Citta,@CAP,@CodiceFiscale)";
                cmd.Parameters.AddWithValue("Nome", p.Nome);
                cmd.Parameters.AddWithValue("Cognome", p.Cognome);
                cmd.Parameters.AddWithValue("Indirizzo", p.Indirizzo);
                cmd.Parameters.AddWithValue("Citta", p.Città);
                cmd.Parameters.AddWithValue("CAP", p.CAP);
                cmd.Parameters.AddWithValue("CodiceFiscale", p.CodiceFiscale);

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
            SqlCommand cmd = new SqlCommand("select * from ANAGRAFICA ", conn);

            SqlDataReader sqlreader;
            conn.Open();

            sqlreader = cmd.ExecuteReader();


            while (sqlreader.Read())
            {
                Anagrafe anagrafe = new Anagrafe();
                anagrafe.Nome = sqlreader["Nome"].ToString();
                anagrafe.Cognome = sqlreader["Cognome"].ToString();
                anagrafe.Indirizzo = sqlreader["Indirizzo"].ToString();
                anagrafe.Città = sqlreader["Citta"].ToString();
                anagrafe.CAP = Convert.ToInt32(sqlreader["CAP"]);
                anagrafe.IdPersona = Convert.ToInt32(sqlreader["IdAnagrafica"]);
                anagrafe.CodiceFiscale = sqlreader["CodiceFiscale"].ToString();
                ListAnagrafe.Add(anagrafe);
            }
        }

        public static void SelectNome()
        {
            string connection = ConfigurationManager.ConnectionStrings["ConnectionDB"]
             .ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("select Nome from ANAGRAFICA ", conn);

            SqlDataReader sqlreader;
            conn.Open();

            sqlreader = cmd.ExecuteReader();


            while (sqlreader.Read())
            {
                Anagrafe anagrafe = new Anagrafe();
                anagrafe.Nome = sqlreader["Nome"].ToString();
            }
        }


    }
}
