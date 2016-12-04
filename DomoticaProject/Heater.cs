using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DomoticaProject
{
    public class Heater
    {

        public Heater(int index)
        {
            this.index = index;
        }

        public Heater(int index, string location)
        {
            this.index = index;
            this.location = location;
        }

        private int index;
        public int Index
        {
            get
            {
                return this.index;
            }
        }

        private string location;
        public string Location
        {
            get
            {
                return this.location;
            }
            set
            {
                this.location = value;
            }
        }


        private float degree;
        public float Degree
        {
            get
            {
                return this.degree;
            }
            set
            {
                this.degree = value;
            }
        }

        private float minimum = 12.0f;
        public float Minimum
        {
            get
            {
                return this.minimum;
            }
        }

        private float maximum = 35.0f;
        public float Maximum
        {
            get
            {
                return this.maximum;
            }
        }
    }
}