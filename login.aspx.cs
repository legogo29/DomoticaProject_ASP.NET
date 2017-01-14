using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DomoticaProject
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            //HttpCookie CookieCookie = new HttpCookie("userCookie");
            //
            //CookieCookie.Value = UserName.Text;
            //CookieCookie.Expires = DateTime.Now.AddHours(1.0);
            //Response.Cookies.Add(CookieCookie);
            //
            //Response.Redirect("default.aspx");

            string email = UserName.Text;
            string password = Password.Text;

            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["database"].ToString();
            OleDbCommand cmd = new OleDbCommand();

            try
            {
                if(isEmailAvailable(email) == false)
                {

                    cmd.Connection = conn;
                    conn.Open();

                    cmd.CommandText = "SELECT email, wachtwoord " +
                                  "FROM account " +
                                  "WHERE email LIKE @_email AND wachtwoord LIKE @_password;";

                    cmd.Parameters.AddWithValue("@_email", email);
                    cmd.Parameters.AddWithValue("@_wachtwoord", password);


                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string temp_email = reader[0].ToString();
                        string temp_password = reader[1].ToString();

                        if(temp_email == email && temp_password == password)
                        {
                            debug.Text = "[DEBUG] true";
                        } else
                        {
                            debug.Text = "[DEBUG] false";
                        }
                    }

                    reader.Close();
                }
            } catch(Exception ex)
            {
                UserName.Text = ex.Message;
                debug.Text = "[DEBUG] error";
            } finally
            {
                conn.Close();
                
            }
        }

        protected static bool isEmailAvailable(string email)
        {
            OleDbConnection conn = null;
            bool state = true;

            try
            {

                conn = new OleDbConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["database"].ToString();

                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "SELECT email " +
                                  "FROM account ";

                cmd.Connection = conn;
                conn.Open();


                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string temp_email = reader[0].ToString();
                    if (temp_email == email)
                    {
                        state = false;
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

            return state;
        }

        protected static bool isDisplaynameAvailable(string display_name)
        {
            OleDbConnection conn = null;
            bool state = true;

            try
            {

                conn = new OleDbConnection();
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["database"].ToString();

                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "SELECT display_name " +
                                  "FROM account ";

                cmd.Connection = conn;
                conn.Open();


                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string temp_name = reader[0].ToString();
                    if (temp_name == display_name)
                    {
                        state = false;
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

            return state;
        }
    }
}