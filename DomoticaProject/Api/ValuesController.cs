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
        public static byte lampByte = 0; // last 3 bits are the states of the 3 lamps
        public static float temprature = 0;
        public static float humidity = 0;
        // GET api/<controller>
        public IEnumerable<byte> Get()
        {
            yield return lampByte;
        }

        public IEnumerable<byte> Get(string temp, string humi)
        {
            temprature = float.Parse(temp);
            humidity = float.Parse(humi);

            yield return lampByte;
        }
        // GET api/<controller>/5
        public string Get(int id)
        {
            if (id == 1)
            {
                return temprature.ToString() + "+" + humidity.ToString() + "+" + lampByte.ToString();
            }
            return "value" + id.ToString();
        }

        public string Get(int id, byte lamp)
        {
            lampByte = lamp;

            if (id == 1)
            {
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