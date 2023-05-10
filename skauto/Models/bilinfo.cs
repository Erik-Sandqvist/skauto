using MySql.Data.MySqlClient;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace skauto.Models
{
    public class bilinfo
    {
     
        private static string conStr = "server=46.246.45.183;user=ErikSa;port=3306;database=ErikSa_DB;password=BPUNFTAZ";

        public int id { get; set;  }

        public string Märke { get; set; }
       
        public int Årsmodell { get; set; }

        public string Växellåda { get; set; }

        public int Hästkrafter { get; set; }

        public int Mil { get; set; }

        public string Plats { get; set; }

        public int Pris { get; set; }


        public static void Sparabil(bilinfo bi) {

            MySqlConnection conn = new MySqlConnection(conStr);
            MySqlCommand MyCom = new MySqlCommand("Insert INTO bilinfo (Märke, Årsmodell, Växellåda, Hästkragfter, Mil, Plats, Pris ) " +
                                                "Values( @MÄRKE, @ÅRSMODELL, @Årsmodell, @Växellåda, @Hästkragfter, @Mil, @Plats, @Pris  ); "); 
            MyCom.Parameters.AddWithValue("@MÄRKE", bi.Märke);

            conn.Open();
            MyCom.ExecuteNonQuery();

            conn.Close();
            ;
        }
/*
        public static bilinfo GetEmployeeByMail(string mail)
        {



            MySqlDataReader reader = MyCom.ExecuteReader();

            skuser singleEmp = new skuser();
            if (reader.Read())
            {
                singleEmp.Id = reader.GetInt32("id");
                singleEmp.Märke = reader.GetString("Märke");
                singleEmp.Årsmodell = reader.GetString("Årsmodell");
                singleEmp.Växellåda = reader.GetString("Växellåda");
                singleEmp.Hästkrafter = reader.GetString("Hästkrafter");
                singleEmp.Mil = reader.GetString("Mil");
                singleEmp.Plats = reader.GetString("Plats");
                singleEmp.Pris = reader.GetString("Pris");

            }

            MyCom.Dispose();
            conn.Close();

            return singleEmp;
        }*/

       
    }
}
