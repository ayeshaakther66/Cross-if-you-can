using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Custom
{
    public class Car
    {
        private Point2D _position;
        private CarColor _carColor;


        private Rectangle _rectangle; // for checking collision(helpful)

        public Car(double y,double x)
        {
            _rectangle = new Rectangle();
            _position.X = x;
            _position.Y = y;
           

            _carColor = (CarColor)SplashKit.Rnd(6); // randomly get a car colour and thus a random car bitmap
        }

        private Bitmap CarBitmap() // returns with the bitmap of the car
        {
            switch (_carColor)
            {
                case CarColor.Red:
                    return SplashKit.BitmapNamed("red");
                case CarColor.Black:
                    return SplashKit.BitmapNamed("black");
                case CarColor.Yellow:
                    return SplashKit.BitmapNamed("yellow");
                case CarColor.White:
                    return SplashKit.BitmapNamed("white");
                case CarColor.Green:
                    return SplashKit.BitmapNamed("green");
                default:
                    return SplashKit.BitmapNamed("white");
            }
        }

        public void Update(double x) // accepting a random decimal number (0.1-0.9) to update cars position with a random velocity
        {
            // updating car position

            if (x > 0.6) //to make sure the speed isnt too much (lets say its tolerable)
            {
                _position.X += x - 0.45;
            }
            else
            {
                _position.X += x;
            }

            if (_position.X > 1100)// sets the car again to the initial position if it leaves the frame
            {
                _position.X = -50;
            }

        }
        public void Draw() //draws car
        {
            SplashKit.DrawBitmap(CarBitmap(), _position.X, _position.Y);

        }

        public Rectangle Proximity // helpful for checking the collision
        {
            get {
                _rectangle.X = _position.X;
                _rectangle.Y = _position.Y;
                _rectangle.Width = 150;
                _rectangle.Height = 75;

                return _rectangle; }
        }

    }
}
