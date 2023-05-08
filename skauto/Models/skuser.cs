using MySql.Data.MySqlClient;
using System.ComponentModel.DataAnnotations;

namespace skauto.Models { 
    public class skuser
    {
        private static string conStr = "server=46.246.45.183;user=ErikSa;port=3306;database=ErikSa_DB;password=BPUNFTAZ";
        public int Id { get; set; }

        public string namn { get; set; }
        [Required(ErrorMessage = "Ange valid mailadress")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail har felaktigt format")]
        [Display(Name = "Din mailadress")]
        public string mailadress { get; set; }


        [Required(ErrorMessage = "Ange lösenord")]
        [Display(Name = "Ditt lösenord")]
        public string password { get; set; }


        public string roll { get; set; }

        public static skuser GetEmployeeByMail(string mail)
        {


            MySqlConnection conn = new MySqlConnection(conStr);
            MySqlCommand MyCom = new MySqlCommand("Select * from skuser where mailadress = @ID", conn);
            MyCom.Parameters.AddWithValue("@ID", mail);
            conn.Open();

            MySqlDataReader reader = MyCom.ExecuteReader();

            skuser singleEmp = new skuser();
            if (reader.Read())
            {
                singleEmp.Id = reader.GetInt32("id");
                singleEmp.namn = reader.GetString("namn");
                singleEmp.mailadress = reader.GetString("mailadress");
                singleEmp.roll = reader.GetString("roll");
                singleEmp.password = reader.GetString("password"); 

            }

            MyCom.Dispose();
            conn.Close();

            return singleEmp;
        }

        internal static string GetUser(string mailadress)
        {
            throw new NotImplementedException();
        }

        internal static bool registerNyUser(string mailadress, string password, string namn)
        {
            MySqlConnection conn = new MySqlConnection(conStr);
            MySqlCommand MyCom = new MySqlCommand("INSERT INTO skuser ( mailadress, password, namn)" +
                                          "VALUES ('@MAIL', '@PASS', '@NAMN');", conn);
            MyCom.Parameters.AddWithValue("@MAIL", mailadress);
            MyCom.Parameters.AddWithValue("@PASS", password);
            MyCom.Parameters.AddWithValue("@NAMN", namn);
            conn.Open();
            MyCom.ExecuteNonQuery();


            return true; 
        }
    }
}