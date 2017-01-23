namespace DomoticaProject
{
    public class Window
    {
        public enum States : int
        {
            Open = 0,
            Closed = 1,
            Half = 2
        }

        public Window(int index)
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