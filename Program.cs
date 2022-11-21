using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using SplashKitSDK;

namespace Custom
{
    public class Program
    {
        public static void Main()
        {
            Window win = new Window("Cross If You Can", 990, 700);

            var stateManager = new StateManager(); // creating the stateManager to look after the game loop
            stateManager.AddState<WelcomeState>(); // passing the tye. so this avoids the creation of a varible( eg var welcome = new WelcomeState())
            stateManager.AddState<PlayState>();
            stateManager.AddState<WonState>();
            stateManager.AddState<LostState>();


            stateManager.SetCurrentState<WelcomeState>(); // sets the initial state to welcome , which is the initial window

            while (!SplashKit.WindowCloseRequested("Cross If You Can")) // Game Loop ( this is where input handling, updating and
                                                                        // drawing is called and happens inside this loop
            {
                SplashKit.ProcessEvents();

                stateManager.HandleInput(win);//passing information of window
                stateManager.Update();

                SplashKit.ClearScreen();

                stateManager.Draw();

                SplashKit.RefreshScreen();
            }
        }
    }
}
