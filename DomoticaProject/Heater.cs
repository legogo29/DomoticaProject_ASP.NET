using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DomoticaProject
{
    public class Heater : Actuator
    {
        public Heater(int index) : base(index)
        {
        }

        public Heater(int index, string location) : base(index, location)
        {
        }

        private float heat;
        public float Heat
        {
            get
            {
                return this.heat;
            }
            set
            {
                this.heat = value;
            }
        }

        private float minimum;
        public float Minimum
        {
            get
            {
                return this.minimum;
            }
            set
            {
                this.minimum = value;
            }
        }

        private float maximum;
        public float Maximum
        {
            get
            {
                return this.maximum;
            }
            set
            {
                this.maximum = value;
            }
        }
    }
}