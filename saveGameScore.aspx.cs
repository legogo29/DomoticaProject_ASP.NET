using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DomoticaProject
{
    public partial class saveGameScore : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Api.Logger log = new Api.Logger();
            log.log("Visited saveGameScore.aspx");
        }

        CustomMembership.MembershipProvider provider_instance = new CustomMembership.MembershipProvider();

        public static void saveData(int gameId, int score)
        {

            string email = "youri.klaassens@email.com";

            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["database"].ToString();
            OleDbCommand cmd = new OleDbCommand();

            StreamWriter writer = new System.IO.StreamWriter("C:\\Users\\youri\\Desktop\\logfile.txt");
            writer.WriteLine("Method saveData called");
            writer.Close();


            //HttpCookie cookie = Request.Cookies["login_cookie"];
            //if(cookie == null)
            //{
            //    Console.WriteLine("Null cookie");
            //}

            //if(isValidUser(cookie) == true)
            //{
                try
                {
                    cmd.Connection = conn;
                    conn.Open();


                    cmd.CommandText = "INSERT INTO speelt(spel_id, email, score, time_stamp) VALUES(@_spel_id, @_email, @_score, @_time_stamp)";

                    DateTime now = DateTime.Now;
                    String time_now = now.ToString();

                    cmd.Parameters.AddWithValue("@_spel_id", gameId);
                    cmd.Parameters.AddWithValue("@_email", email);
                    cmd.Parameters.AddWithValue("@_score", score);
                    cmd.Parameters.AddWithValue("@time_stamp", 0);


                    int rows_added = cmd.ExecuteNonQuery();
                    
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    conn.Close();

                }
            //}
            
            //end
        }

        public Boolean isValidUser(HttpCookie cookie)
        {

            string email = cookie.Values["email"].ToString();
            string password = cookie.Values["password"].ToString();

            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["database"].ToString();
            OleDbCommand cmd = new OleDbCommand();


            try
            {
                    cmd.Connection = conn;
                    conn.Open();


                    cmd.CommandText = "SELECT email, wachtwoord " +
                                  "FROM account " +
                                  "WHERE email LIKE @_email;";

                    cmd.Parameters.AddWithValue("@_email", email);


                    OleDbDataReader reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {
                        string temp_email = reader[0].ToString();
                        string temp_password = reader[1].ToString();

                        string salt = temp_password.Substring(0, 64);
                        string hash = temp_password.Substring(64, 64);

                        string i_password = provider_instance.Sha256Hex(salt + password);

                        string _password = temp_password.Substring(64);

                        if (i_password == _password)
                        {
                            reader.Close();
                            conn.Close();
                            return true;
                        }
                        else
                        {
                            
                        }
                    }

                    reader.Close();
                
            }
            catch (Exception ex)
            {
            }
            finally
            {
                conn.Close();

            }
            return false;
        }

    }


}