using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using SplashKitSDK;
using System.IO;

namespace Custom
{
    public class PlayState : GameState //inheriting
    {
        // creating player, landmanager, stopwatch(to show the time)
        public  Stopwatch _stopwatch = new Stopwatch();
        private Player _player;
        private LaneManager _laneManager;

        //variables to store coin number, life, time(in seconds)
        private int _ncoin;
        private int _nlife;
        private double _time;


        // to get the type(find alt if u have time)
        private Coin coin = new Coin(-20);
        private Gem gem = new Gem(-20);
        private Boost boost = new Boost(-20);


        public override void OnStateEnter()
        {
            ResetSettings(); //after entering this state, resets everthing
            
        }


        public void ResetSettings()
        {
            _stopwatch.Reset();// resets the stopwatch

            _stopwatch.Start(); // starts the stopwatch

            _player = new Player(); //creates a new player on every restart
            _laneManager = new LaneManager(); //creates a new lane manager on every restart
            _ncoin = 0;
            _nlife = 5;

    }

        public override void HandleInput(Window win) // this method will just take inputs
        {
        
            _player.HandlePlayer(win); // handles the inputs for player's movements
            _player.StayOnWindow(); // keeps the player on screen
        }

        public override void Update()
        {
            
            // checks for collisions and does the appropriate actions
            CheckCar();
            CheckPoint();

            // updates the positions of each element on the lane ie cars
            _laneManager.Update();

            //Checks whether the player won or not
            CheckWin();
            

        }

        public void CheckWin()
        {

            if (_player.Y <= 124 && _ncoin >= 5) // checks whether the player crossed the road with required coins 
            {
                manager.Score = _time;//stores the time that was taken to finish this game
                _stopwatch.Stop();
                manager.SetCurrentState<WonState>(); //if yes, changes state to won state
            }
            else if (_nlife <= 0) // checks whether player is dead or not
            {

                manager.SetCurrentState<LostState>(); // if yes, changes state to lost state
            }
        }
   
        public override void Draw()
        {
            

            SplashKit.DrawBitmap("road", -10, 80); // draws the background
            
            _laneManager.Draw(); // draws the cars, coins, gems
            _player.DrawPlayer(); //drawing player

            SplashKit.DrawText(">>>> Coins Required: 5", Color.Black, "Tahoma", 400, 50, 25); //draws the Required coins to win
            SplashKit.DrawText(">>>> Coins " + _ncoin, Color.Black, "Tahoma", 400, 240, 25); // draws the number of coins the player has taken
            SplashKit.DrawText(">>>>> Number of Lives: " + _nlife, Color.Black, "Tahoma", 400, 430, 25); // draws the number of lives the player has
            SplashKit.DrawText(">>>>> Timer: " + _time, Color.Black, "Tahoma", 400, 650, 25); // draws the timer(stop watch)
        }

        protected void CheckCar()
        {
            var _carproximity = _laneManager.Cars_Proximity; // this returns a list of cars(rectangles) which are drawn on the present game 
            foreach (Rectangle cp in _carproximity)
            {

                if (SplashKit.BitmapRectangleCollision(_player._bitmap, _player.Position, cp)) // checks whether the player collided with any car or not
                {
                    // if yes, resets the player's position to the start point and deducts a life 
                    _player.X = 364;
                    _player.Y = 630;
                    _nlife -= 1;
                }
            }
        }

        protected void CheckPoint()
        {
            var _pointProximity = _laneManager.Points_Proximity; // this returns a dictionary (key, value) where key is the position and value is the type of
                                                                 // instance point is which is drawn on the present game

            _time = _stopwatch.Elapsed.TotalSeconds;

            foreach (var position in _pointProximity)
            {
                if (SplashKit.BitmapCircleCollision(_player._bitmap, _player.Position, position.Key))// checks whether the player collided with any point or not
                {
                    _laneManager.RemovePoints(position.Key); // passes the point's circle to remove it from the current on going game

                    if (position.Value == coin.GetType()) // keys the value of each position( thats basically a type) 
                    {
                        ++_ncoin; //if yes, game adds a point 
                    }
                    if (position.Value == gem.GetType())
                    {
                        ++_nlife;// if yes, game adds life

                    }
                    if (position.Value == boost.GetType())
                    {
                        _player.Y = 130; //gets the player to the end

                    }

                }

            }
        }


    }
}