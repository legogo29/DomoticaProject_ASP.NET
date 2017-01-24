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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Api.Logger log = new Api.Logger();
            log.log("Visited login.aspx");

            if (Request.Cookies["login_cookie"] != null)
            {
                Response.Redirect("default.aspx");
            }
        }

        CustomMembership.MembershipProvider provider_instance = new CustomMembership.MembershipProvider();

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

                    
                    cmd.CommandText = "SELECT email, display_name, wachtwoord " +
                                  "FROM account " +
                                  "WHERE email LIKE @_email;";

                    cmd.Parameters.AddWithValue("@_email", email);


                    OleDbDataReader reader = cmd.ExecuteReader();

                    
                    while (reader.Read())
                    {
                        string temp_email = reader[0].ToString();
                        string temp_display_name = reader[1].ToString();
                        string temp_password = reader[2].ToString();

                        string salt = temp_password.Substring(0, 64);
                        string hash = temp_password.Substring(64, 64);

                        string i_password = provider_instance.Sha256Hex(salt + password);
                        
                        string _password = temp_password.Substring(64);
                        
                        if(i_password == _password)
                        {
                            DateTime now = DateTime.Now;

                            HttpCookie cookie = new HttpCookie("login_cookie");
                            cookie.Values.Add("email", temp_email);
                            cookie.Values.Add("display_name", temp_display_name);
                            cookie.Values.Add("password", password);
                            cookie.Expires = now.AddYears(1);

                            Response.Cookies.Add(cookie);
                            Response.Redirect("default.aspx");
                        } else
                        {
                            debug.Text = "Password is wrong.";
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