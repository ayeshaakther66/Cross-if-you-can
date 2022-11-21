using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Custom
{
    public class WelcomeState : GameState //inheriting
    {

        public WelcomeState()
        {

        }
        public override void HandleInput(Window win)
        {
            // We can combine this with the Observer Pattern..
            if (SplashKit.MouseClicked(MouseButton.LeftButton) )
            {
                if (IsAtStart(SplashKit.MousePosition()))
                {
                    manager.SetCurrentState<PlayState>(); // if start button is clicked, game starts and current state is set to play state
                }

                else if (IsAtExit(SplashKit.MousePosition()))
                {
                    SplashKit.CloseWindow("Cross If You Can");
                }
            }
        }

        public override void Update()
        {
        }

        public override void Draw()
        {
            
            // Draw stuff to the screen
            SplashKit.DrawBitmap("road",-10,50);
            SplashKit.DrawBitmap("logo", 200, 160);
            SplashKit.DrawBitmap("start", 400, 300);
            SplashKit.DrawBitmap("exit", 400, 400);
        }

        protected bool IsAtStart(Point2D pt) // checks whether the mouse if over the start button or not
        {
            if (SplashKit.PointInRectangle(pt,10, SplashKit.RectangleFrom(400, 300, 200, 65))){ 

                return true;
            }
            else
            {
                return false;
            }
        }

        protected bool IsAtExit(Point2D pt)
        {
            if (SplashKit.PointInRectangle(pt, 10, SplashKit.RectangleFrom(400, 400, 290, 65)))
            {

                return true;
            }
            else
            {
                return false;
            }
        }




    }
}
