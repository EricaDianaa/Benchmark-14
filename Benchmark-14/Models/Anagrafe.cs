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
      

    }
}
