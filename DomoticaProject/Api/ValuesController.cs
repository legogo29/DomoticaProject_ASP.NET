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
        public static bool[] valuestate = { false, false, false };
        public static float temprature = 0;
        public static float humidity = 0;
        // GET api/<controller>
        public IEnumerable<bool> Get()
        {
            return valuestate;
        }

        public IEnumerable<bool> Get(string temp, string humi)
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
                //compress the states to one byte
                //byte lampNr = (byte)(valuestate[0] << 2) + valuestate[1] << 1 + valuestate[2]); 
                byte lampByte = 0;
                if (valuestate[0]) lampByte |= 1 << 2;
                if (valuestate[1]) lampByte |= 1 << 1;
                if (valuestate[2]) lampByte |= 1 << 0;
                return temprature.ToString() + "+" + humidity.ToString() + "+" + lampByte.ToString();
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