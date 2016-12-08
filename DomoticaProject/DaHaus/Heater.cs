namespace DomoticaProject
{
    public class Heater
    {
        public Heater(int index)
        {
            this.index = index;
        }

        public string Location;
        public float Degree;

        private int index;
        public int Index
        {
            get
            {
                return this.index;
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