using System;
using SplashKitSDK;

namespace Custom
{
    public class Boost : Point
    {
        private Point2D _position;
        private Bitmap _bitmap = new Bitmap("boost", "boost.png");

        public Boost(double y) : base(y)
        {
            _position.X = X;     // gets the x coordinate from the parent class(point)
            _position.Y = y;
        }

        public override void Draw() //draws boost
        {
            SplashKit.DrawBitmap(_bitmap, _position.X, _position.Y);

        }
    }
}
