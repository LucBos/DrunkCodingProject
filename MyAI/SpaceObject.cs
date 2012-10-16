using System.Windows;

namespace MyAI
{
    public class SpaceObject
    {
        public int Speed
        {
            get
            {
                return HorizonalSpeed + VerticalSpeed;
            }
        }

        internal int HorizonalSpeed
        {
            get;
            set;
        }

        internal int VerticalSpeed
        {
            get;
            set;
        }

        public int Mass { get; set; }

        public void ApplyHorizontalForce(int force, int time)
        {
            HorizonalSpeed += CalculateVelosity(force, time);
        }

        private int CalculateVelosity(int force, int time)
        {
            if (force == 0 || time == 0)
                return 0;

            //Vector v1 = new Vector(1, 1);

            // F=ma
            // a=v/t
            return (Mass / force) / time;
        }

        public void ApplyVerticalForce(int force, int time)
        {
            VerticalSpeed += CalculateVelosity(force, time);
        }
    }
}