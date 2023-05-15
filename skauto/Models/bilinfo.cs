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
            MySqlCommand MyCom = new MySqlCommand("Insert INTO bilinfo (Märke, Årsmodell, Växellåda, Hästkrafter, Mil, Plats, Pris ) " +
                                                "Values( @MÄRKE, @ÅRSMODELL, @Växellåda, @Hästkrafter, @Mil, @Plats, @Pris  ); ", conn); 
            MyCom.Parameters.AddWithValue("@MÄRKE", bi.Märke);
            MyCom.Parameters.AddWithValue("@ÅRSMODELL", bi.Årsmodell);
            MyCom.Parameters.AddWithValue("@Växellåda", bi.Växellåda);
            MyCom.Parameters.AddWithValue("@Hästkrafter", bi.Hästkrafter);
            MyCom.Parameters.AddWithValue("@Mil", bi.Mil);
            MyCom.Parameters.AddWithValue("@Plats", bi.Plats);
            MyCom.Parameters.AddWithValue("@Pris", bi.Pris);



            conn.Open();
            MyCom.ExecuteNonQuery();

            conn.Close();
            ;
        }

        internal static List<bilinfo> GetallCars()
        {
            List<bilinfo> biList = new List<bilinfo>(); 
            MySqlConnection conn = new MySqlConnection(conStr);
            MySqlCommand MyCom = new MySqlCommand("Select * from bilinfo", conn);

            conn.Open();

            MySqlDataReader reader = MyCom.ExecuteReader();

            while (reader.Read())
            {
                bilinfo bi = new bilinfo();
                bi.id = reader.GetInt32("Id"); 
                bi.Märke = reader.GetString("Märke");
                bi.Årsmodell = reader.GetInt32("Årsmodell");
                bi.Växellåda = reader.GetString("Växellåda");
                bi.Hästkrafter = reader.GetInt32("Hästkrafter");
                bi.Mil = reader.GetInt32("Mil");
                bi.Plats = reader.GetString("Plats");
                bi.Pris = reader.GetInt32("Pris");

                biList.Add(bi); 
            }
            conn.Close(); 

            return biList; 
        }

        internal static bilinfo GetCarsByID(int id)
        {
           
            MySqlConnection conn = new MySqlConnection(conStr);
            MySqlCommand MyCom = new MySqlCommand("Select * from bilinfo WHERE Id = @ID", conn);
            MyCom.Parameters.AddWithValue("@ID", id); 

            conn.Open();

            MySqlDataReader reader = MyCom.ExecuteReader();
            bilinfo bi = new bilinfo(); 
            if (reader.Read())
            {
                bi.id = reader.GetInt32("Id");
                bi.Märke = reader.GetString("Märke");
                bi.Årsmodell = reader.GetInt32("Årsmodell");
                bi.Växellåda = reader.GetString("Växellåda");
                bi.Hästkrafter = reader.GetInt32("Hästkrafter");
                bi.Mil = reader.GetInt32("Mil");
                bi.Plats = reader.GetString("Plats");
                bi.Pris = reader.GetInt32("Pris");
            }
            conn.Close(); 
            return bi; 
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
