using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Custom
{
    public class WonState : GameState //inheriting
    {
        public WonState()
        {
            
        }
        public override void HandleInput(Window win) // this will take back to the homepage
        {
            if (SplashKit.KeyTyped(KeyCode.SpaceKey))
            {
                manager.SetCurrentState<WelcomeState>(); // to return back to the welcome page

            }
        }
        public override void Update()
        {
            
        }
        public override void Draw()
        {

            double time = manager.Score; //gets time taken 

            // drawing the lost image , indicating the player won
            SplashKit.DrawBitmap("road", -10, 80);
            SplashKit.DrawBitmap("won", 300, 250);
            SplashKit.DrawBitmap("return", 300, 350);
            SplashKit.DrawText(String.Format("Time Taken: {0}", time), Color.Black, 400, 450);

        }
    }
}
