using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using SplashKitSDK;

namespace Custom
{
    public class LostState :GameState
    {
        public LostState()
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
            // drawing the lost image , indicating the player lost
            SplashKit.DrawBitmap("road", -10, 50);
            SplashKit.DrawBitmap("lost", 300, 250);
            SplashKit.DrawBitmap("return", 300, 350);

        }
    }
}
