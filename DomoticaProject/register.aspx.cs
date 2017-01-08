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
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void button_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();

            try
            {
                if (isEmailAvailable(input_email.Text) == true && isDisplaynameAvailable(input_displayname.Text) == true)
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["database"].ToString();

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.CommandText = "INSERT INTO account(email, voornaam, achternaam, wachtwoord, display_name) " +
                                        "VALUES " +
                                        "(" +
                                        "@email, @voornaam, @achternaam, @wachtwoord, @display_name" +
                                        ");";

                    cmd.Connection = conn;
                    conn.Open();

                    cmd.Parameters.AddWithValue("@email", input_email.Text);
                    cmd.Parameters.AddWithValue("@voornaam", input_voornaam.Text);
                    cmd.Parameters.AddWithValue("@achternaam", input_achternaam.Text);
                    cmd.Parameters.AddWithValue("@wachtwoord", input_password.Value);
                    cmd.Parameters.AddWithValue("@display_name", input_displayname.Text);

                    cmd.ExecuteNonQuery();
                }
                else
                {
                    label_email.Text = "Email bestaat al, knul.";
                }


            }
            catch (Exception ex)
            {
                label_voornaam.Text = ex.Message;
                label_achternaam.Text = ex.StackTrace;
            }
            finally
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