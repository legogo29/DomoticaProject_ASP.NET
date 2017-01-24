using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace DomoticaProject.Api
{
    public class Logger
    {
        public void log(string message)
        {

            StreamWriter writer = new System.IO.StreamWriter("C://users//youri//Desktop//logfile.txt", true);
            writer.WriteLine("[" + GetIPAddress()  + "    " + getDate() + "     " + getEmail() + "]" + "    " + message + "\n");
            writer.Close();
        }

        protected string GetIPAddress()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            return context.Request.ServerVariables["REMOTE_ADDR"];
        }

        protected string getDate()
        {
            return DateTime.Now.ToString();
        }

        protected string getEmail()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            HttpCookie cookie = context.Request.Cookies["login_cookie"];
            string email;

            if(cookie == null)
            {
                return "(no email)";
            } else
            {
                email = cookie.Values["email"].ToString();
            }

            return email;
        }
    }
}