using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DomoticaProject
{
    public class Actuator
    {
        public Actuator(int index)
        {
            this.index = index;
        }

        public Actuator(int index, string location)
        {
            this.index = index;
            this.location = location;
        }

        protected int index;
        public int Index
        {
            get
            {
                return this.index;
            }
        }

        protected int state;
        public int State
        {
            get
            {
                return this.state;
            }
        }

        protected string location;
        public string Location
        {
            get
            {
                return this.location;
            }
        }

        public void ChangeLocation(string location)
        {
            this.location = location;
        }
    }
}