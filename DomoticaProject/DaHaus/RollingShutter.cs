using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DomoticaProject
{
    public class RollingShutter
    {
        public enum States : int
        {
            Open = 0,
            Close = 1,
            Half = 2
        }

        public RollingShutter(int index)
        {
            this.index = index;
        }

        public RollingShutter(int index, string location)
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