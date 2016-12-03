using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DomoticaProject
{
    public class RollingShutter : Actuator
    {
        public RollingShutter(int index) : base(index)
        {
        }

        public RollingShutter(int index, string location) : base(index, location)
        {
        }

        public enum States : int
        {
            Close = 0,
            Open = 1,
            Half = 2
        }

        public void ChangeState(States state)
        {
            this.state = (int)state;
        }
    }
}