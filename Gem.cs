using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Custom
{
    public class Gem : Point
    {
        private Point2D _position;
        private Bitmap _bitmap = new Bitmap("gem", "gem.png");

        public Gem(double y) :base( y)
        {
            _position.X = X;     // gets the x coordinate from the parent class(point)
            _position.Y = y;
        }

        public override void Draw() //draws gem
        {
            SplashKit.DrawBitmap(_bitmap, _position.X, _position.Y);

        }

    }
}
