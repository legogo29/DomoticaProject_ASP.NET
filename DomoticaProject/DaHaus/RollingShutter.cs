namespace DomoticaProject
{
    public class RollingShutter
    {
        public enum States : int
        {
            Open = 0,
            Closed = 1,
            Half = 2
        }

        public RollingShutter(int index)
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