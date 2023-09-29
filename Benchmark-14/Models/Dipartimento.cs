using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Benchmark_14.Models
{
    public class Dipartimento
    {
        //ANAGRAFE
        public int IdPersona { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Indirizzo { get; set; }
        public string Città { get; set; }
        public int CAP { get; set; }
        public string CodiceFiscale { get; set; }

        //TIPOVIOLAZIONE
        public int IdViolazione { get; set; }
        public string Descrizione { get; set; }

        //VERBALE
        public int IdVerbale { get; set; }
        [DisplayFormat(DataFormatString ="{0:d}",ApplyFormatInEditMode =true)]
        public DateTime DataViolazione { get; set; }
        public DateTime DataTransazioneVerbale { get; set; }
        public string IndirizzoViolazione { get; set; }
        public string NominativoAgente { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal Importo { get; set; }
        public int DecurtamentoPunti { get; set; }
        public int IdAnagrafe { get; set; }
        public int IdViolazioni { get; set; }

        public int TotVerbali { get; set; }
        public static List<Dipartimento> ListTotVerbali=new List<Dipartimento>();

        public int TotDecurtamentoPunti { get; set; }
        public static List<Dipartimento> ListTotDecurtamentoPunti = new List<Dipartimento>();

        public static List<Dipartimento> ListWhereDecurtamentoPunti = new List<Dipartimento>();


        public static List<Dipartimento> ListImporto = new List<Dipartimento>();


        public static void SelectVerbaliPerson()
        {
            string connection = ConfigurationManager.ConnectionStrings["ConnectionDB"]
             .ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS NumeroVerbali,Nome FROM VERBALE  INNER JOIN ANAGRAFICA ON VERBALE.IdAnagrafica=ANAGRAFICA.IdAnagrafica GROUP BY ANAGRAFICA.Nome", conn);

            SqlDataReader sqlreader;
            conn.Open();

            sqlreader = cmd.ExecuteReader();


            while (sqlreader.Read())
            {
                   Dipartimento dipartimento = new Dipartimento();
                   dipartimento.Nome   = sqlreader["Nome"].ToString();
                   dipartimento.TotVerbali   = Convert.ToInt16(sqlreader["NumeroVerbali"]);
                  ListTotVerbali.Add(dipartimento);
            }
        }

        public static void SelectDecurtamentoPunti()
        {
            string connection = ConfigurationManager.ConnectionStrings["ConnectionDB"]
             .ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("select SUM(DecurtamentoPunti)as TotDecurtamentoPunti,Nome FROM VERBALE INNER JOIN ANAGRAFICA ON VERBALE.IdAnagrafica=ANAGRAFICA.IdAnagrafica GROUP BY ANAGRAFICA.Nome", conn);

            SqlDataReader sqlreader;
            conn.Open();

            sqlreader = cmd.ExecuteReader();


            while (sqlreader.Read())
            {
                Dipartimento dipartimento = new Dipartimento();
                dipartimento.Nome = sqlreader["Nome"].ToString();
                dipartimento.TotDecurtamentoPunti = Convert.ToInt16(sqlreader["TotDecurtamentoPunti"]);
                ListTotDecurtamentoPunti.Add(dipartimento);
            }
        }

        public static void SelectWhereDecurtamentoPunti()
        {
            string connection = ConfigurationManager.ConnectionStrings["ConnectionDB"]
             .ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("SELECT Cognome,Nome,DataViolazione,Importo,DecurtamentoPunti FROM VERBALE INNER JOIN ANAGRAFICA ON VERBALE.IdAnagrafica=ANAGRAFICA.IdAnagrafica WHERE VERBALE.DecurtamentoPunti>10", conn);

            SqlDataReader sqlreader;
            conn.Open();

            sqlreader = cmd.ExecuteReader();


            while (sqlreader.Read())
            {
                Dipartimento dipartimento = new Dipartimento();
                dipartimento.Nome = sqlreader["Nome"].ToString();
                dipartimento.Cognome = sqlreader["Cognome"].ToString();
                dipartimento.DataViolazione = Convert.ToDateTime(sqlreader["DataViolazione"]);
                dipartimento.Importo = Convert.ToDecimal(sqlreader["Importo"].ToString());
                dipartimento.DecurtamentoPunti =Convert.ToInt32( sqlreader["DecurtamentoPunti"]);
                ListWhereDecurtamentoPunti.Add(dipartimento);
            }
        }

        public static void SelectImporto()
        {
            string connection = ConfigurationManager.ConnectionStrings["ConnectionDB"]
             .ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("SELECT Cognome,Nome,Indirizzo,DataViolazione,Importo,DecurtamentoPunti FROM VERBALE INNER JOIN ANAGRAFICA ON VERBALE.IdAnagrafica=ANAGRAFICA.IdAnagrafica WHERE VERBALE.Importo>400", conn);

            SqlDataReader sqlreader;
            conn.Open();

            sqlreader = cmd.ExecuteReader();


            while (sqlreader.Read())
            {
                Dipartimento dipartimento = new Dipartimento();
                dipartimento.Nome = sqlreader["Nome"].ToString();
                dipartimento.Cognome = sqlreader["Cognome"].ToString();
                dipartimento.Indirizzo = sqlreader["Indirizzo"].ToString();
                dipartimento.DataViolazione = Convert.ToDateTime(sqlreader["DataViolazione"]);
                dipartimento.Importo = Convert.ToDecimal(sqlreader["Importo"].ToString());
                dipartimento.DecurtamentoPunti = Convert.ToInt32(sqlreader["DecurtamentoPunti"]);
                ListImporto.Add(dipartimento);

            }
        }
    }
}