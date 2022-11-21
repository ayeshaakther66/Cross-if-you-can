using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using SplashKitSDK;

namespace Custom
{
    public class StateManager
    {
        private Dictionary<Type, GameState> _states;
        private GameState currentState; // need this so that state manager can assign/tell the current state to handle input, updates and drawing
        public double Score { get; set; }

        public StateManager()
        {
            _states = new Dictionary<Type, GameState>();

            //// loads up the graphics, to be used in the game states

            SplashKit.LoadBitmap("player", "player.png");
            SplashKit.LoadBitmap("red", "red.png");
            SplashKit.LoadBitmap("white", "white.png");
            SplashKit.LoadBitmap("black", "black.png");
            SplashKit.LoadBitmap("yellow", "yellow.png");
            SplashKit.LoadBitmap("green", "green.png");
            SplashKit.LoadBitmap("exit", "exit.png");
            SplashKit.LoadBitmap("start", "start.png");
            SplashKit.LoadBitmap("road", "road.png");
            SplashKit.LoadBitmap("logo", "logo.png");
            SplashKit.LoadBitmap("won", "won.png");
            SplashKit.LoadBitmap("lost", "lost.png");
            SplashKit.LoadBitmap("return", "return.png");

        }

        public void AddState(GameState state)
        {
            state.manager = this; // here we're telling the state that its part of this class; StateManager
            _states.Add(state.GetType(), state); // to add state to a dictionary , we need to get the type of state as well
        }

        public void AddState<T>() where T : GameState // T inherits from gamestate, so this method will just accept from gamestate ( the types)
                                                      // works well with types as it associates with objects without really knowing the objects
        {
            GameState state = Activator.CreateInstance<T>(); //creates an object with type T; Activator.CreateInstance figures the type out and
                                                             //create the object

            AddState(state); // passing this state to the AddState method
        }

  
        public void SetCurrentState(Type newStateType) // need this so that the state manager knows which state needs to process the program

        {
            if (_states.ContainsKey(newStateType)) // this checks if states dictionary contains this state we want to set to
            {
                GameState newState = _states[newStateType]; // fetching the state from states

                if (currentState != null && currentState != newState) // this is checking whether a current state isnot set to the new state
                    currentState.OnStateExit();

                currentState = newState; // setting the state to the current state
                currentState.OnStateEnter(); //entering the new state, which basically call the reset funtions
            }
        }

        public void SetCurrentState<T>() where T : GameState // same pattern like AddState method
        {
            Type stateType = typeof(T); //fetches the type for u
            SetCurrentState(stateType);
        }

        //state manager is handling the sates, so 
        // here it is forwarding the methods to be handle by the current state
        public void HandleInput(Window win) => currentState.HandleInput(win);
        public void Update() => currentState.Update();
        public void Draw() => currentState.Draw();
    }
}