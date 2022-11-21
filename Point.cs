using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;
namespace Custom
{
    public abstract class Point
    {
        private double _y;
        private double _x;

        public Point(double y)
        {
            _y = y;
            _x = SplashKit.Rnd(0, 1000); //random x coordinate for the point objects
        }
        public abstract void Draw();

        public double X
        {
            get { return _x; }
        }

        public Circle Proximity
        {
            get
            {
                return SplashKit.CircleAt(_x + 25, _y + 25, 20);
            }
        }

    }
}
