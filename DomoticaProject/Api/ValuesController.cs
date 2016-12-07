using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DomoticaProject.Api
{
    public class ValuesController : ApiController
    {
        public static int[] valuestate = { 0, 0, 0 };
        // GET api/<controller>
        public IEnumerable<int> Get()
        {
            return valuestate;
        }
        // GET api/<controller>/5
        public string Get(int id)
        {
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