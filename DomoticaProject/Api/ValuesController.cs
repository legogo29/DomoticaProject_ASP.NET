using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;

namespace DomoticaProject.Api
{
    public class ValuesController : ApiController
    {
        public static int[] valuestate = { 0, 0, 0 };
        public static float temprature = 0;
        public static float humidity = 0;
        // GET api/<controller>
        public IEnumerable<int> Get()
        {
            return valuestate;
        }

        public IEnumerable<int> Get(string temp, string humi)
        {
            temprature = float.Parse(temp);
            humidity = float.Parse(humi);

            return valuestate;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            if (id == 1)
            {
                return temprature.ToString() + "+" + humidity.ToString() + "+" + valuestate[0].ToString() + "+" + valuestate[1].ToString() + "+" + valuestate[2].ToString() + "+";
            }
            return "value" + id.ToString();
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}