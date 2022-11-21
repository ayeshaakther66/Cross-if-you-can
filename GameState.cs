using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;
namespace Custom
{
    public abstract class GameState //base class
    {
        public StateManager manager; // this allows all the states to know that it part of a manager,
                                     //so a state can change the current state without having to know about that particular object

        public virtual void OnStateEnter() { } // doing it virtual since only one state needs to reset
        public virtual void OnStateExit() { }

        public abstract void HandleInput(Window win);
        public abstract void Update();
        public abstract void Draw();

        
        
    }
}