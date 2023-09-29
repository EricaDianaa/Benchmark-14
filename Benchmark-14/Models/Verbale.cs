using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Benchmark_14.Models
{
    public class Verbale
    {
        //VERBALE
        public int IdVerbale { get; set; }
       // [Display(Name = "Data violazione")]
       public DateTime DataViolazione { get; set; }
      //  [Display(Name = "Data Transazione del verbale")]
       public DateTime DataTransazioneVerbale { get; set; }
       // [Display(Name = "Indirizzo violazione")]
        public string IndirizzoViolazione { get; set; }
       // [Display(Name = "Nominativo agente")]
        public string NominativoAgente { get; set; }
        public decimal Importo { get; set; }
      //  [Display(Name = "Decurtamento punti")]
        public int DecurtamentoPunti { get; set; }
       // [Display(Name = "Numero identificativo trasgressore")]
        public int IdAnagrafe { get; set; }
       // [Display(Name = "Numero identificativo Violazione")]
        public int IdViolazioni { get; set; }

        public   int  TotVerbali { get; set; }
        public  string Nome { get; set; }

        public static List<Verbale> ListVerbale=new List<Verbale>();

        public static void Insert(Verbale p, string messaggio)
        {

            
            string connection = ConfigurationManager.ConnectionStrings["ConnectionDB"]
               .ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connection);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO VERBALE VALUES(@DataViolazione,@IndirizzoViolazione,@NominativoAgente,@DataTransizioneVerbale,@Importo,@DecurtamentoPunti,@IdAnagrafica,@IdViolazione)";
                cmd.Parameters.AddWithValue("DataViolazione", p.DataViolazione);
                cmd.Parameters.AddWithValue("IndirizzoViolazione", p.IndirizzoViolazione);
                cmd.Parameters.AddWithValue("NominativoAgente", p.NominativoAgente);
                cmd.Parameters.AddWithValue("DataTransizioneVerbale", p.DataTransazioneVerbale);
                cmd.Parameters.AddWithValue("Importo", p.Importo);
                cmd.Parameters.AddWithValue("DecurtamentoPunti", p.DecurtamentoPunti);
                cmd.Parameters.AddWithValue("IdAnagrafica", p.IdAnagrafe);
                cmd.Parameters.AddWithValue("IdViolazione", p.IdViolazioni);

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
            SqlCommand cmd = new SqlCommand("select * from VERBALE ", conn);

            SqlDataReader sqlreader;
            conn.Open();

            sqlreader = cmd.ExecuteReader();


            while (sqlreader.Read())
            {
                Verbale prod = new  Verbale();
                prod.IdVerbale = Convert.ToInt16(sqlreader["IdVerbale"]);
                prod.DataTransazioneVerbale = Convert.ToDateTime(sqlreader["DataTransizioneVerbale"]);
                prod.NominativoAgente = sqlreader["NominativoAgente"].ToString();
                prod.IndirizzoViolazione = sqlreader["IndirizzoViolazione"].ToString();
                prod.DataViolazione = Convert.ToDateTime(sqlreader["DataViolazione"]);
                prod.Importo = Convert.ToDecimal(sqlreader["Importo"].ToString());
                prod.IdViolazioni = Convert.ToInt32(sqlreader["IdViolazione"]);
                prod.IdAnagrafe = Convert.ToInt16(sqlreader["IdAnagrafica"]);
                prod.DecurtamentoPunti = Convert.ToInt16(sqlreader["DecurtamentoPunti"]);
                ListVerbale.Add(prod);
            }
        }


    }
}