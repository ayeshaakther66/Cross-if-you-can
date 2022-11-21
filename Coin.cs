using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;
namespace Custom
{
    public class Coin : Point
    {
        protected Point2D _position;
        protected Bitmap bitmap = new Bitmap("coin", "coin.png");

        public Coin(double y) :base(y)
        {
            //random positions for the coin
            _position.X = X;  // getting the x coordinate from base(randomly generated)
            _position.Y = y ;
    }

        public override void Draw() //draws coin
        {
            SplashKit.DrawBitmap(bitmap, _position.X, _position.Y);

        }

    }
}