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

        public string Location;
        public States State;

        private int index;
        public int Index
        {
            get
            {
                return this.index;
            }
        }
    }
}