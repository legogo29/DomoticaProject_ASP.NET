using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace DomoticaProject
{
    public class Lamp
    {
        public enum States : int
        {
            Off = 0,
            On = 1
        }

        public Lamp(int index)
        {
            this.index = index;
        }

        public Lamp(int index, string location)
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

        private States state;
        public States State
        {
            get
            {
                return this.state;
            }
            set
            {
                this.state = value;
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
    }
}