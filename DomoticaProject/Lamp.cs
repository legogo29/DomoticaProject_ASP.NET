using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace DomoticaProject
{
    public class Lamp : Actuator
    {
        public Lamp(int index) : base(index)
        {
        }

        public Lamp(int index, string location) : base(index, location)
        {
        }

        public enum States : int
        {
            Off = 0,
            On = 1
        }

        public void ChangeState(States state)
        {
            this.state = (int)state;
        }
    }
}