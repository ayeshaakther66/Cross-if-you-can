using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using SplashKitSDK;

namespace Custom
{
    public class Player
    {
        private Window _window;
        public Bitmap _bitmap = new Bitmap("player", "player.png");
        private Point2D _position;
        private Vector2D _velocity;



        public Player()
        {
            
            _position.X = 364;
            _position.Y = 630;
            _velocity.X = 0.2;
            _velocity.Y = 0;
        }

        public void HandlePlayer(Window win)
        {
            _window = win;
            double speed = _velocity.X; // Set 0.5 to speed

            //DrawPlayer();
            if (SplashKit.KeyDown(KeyCode.LeftKey)) // If hold Left or Right, the X location will minus or add 0.5
            {
                _position.X -= speed;
                DrawPlayer();
            }

            if (SplashKit.KeyDown(KeyCode.RightKey))
            {
                _position.X += speed;
                DrawPlayer();
            }

           
            if (SplashKit.KeyDown(KeyCode.UpKey))   // If hold Up or Down, the Y location will minus or add 0,5.
            {
                _position.Y -= speed;
                DrawPlayer();
            }

            if (SplashKit.KeyDown(KeyCode.DownKey))
            {
                _position.Y += speed;
                DrawPlayer();
            }
        }
        public void DrawPlayer()
        {
            SplashKit.DrawBitmap(_bitmap, _position.X, _position.Y); //draw player; create player
        }

        public void StayOnWindow()  // TO make sure the Player on the screen.
        {
            
            if (_position.X < 0) //if the player's x coordinate is less than 0 , changing it backing 0 
            {
                _position.X = 0;
            }
            
            if (_position.Y < 80)  //if the player's x coordinate is less than 80, i.e the limit of road image , changing it backing 80
            {
                _position.Y = 80;
            }

            if (_position.X > (_window.Width - _bitmap.Width)) //checks whether the player's x coordinate is more than window's width
            {
                _position.X = _window.Width - _bitmap.Width;
            }

            if (_position.Y > (_window.Height - _bitmap.Height))//checks whether the player's y coordinate is more than window's height
            {
                _position.Y = _window.Height - _bitmap.Height;
            }
        }

        public Point2D Position //return the players position
        {
            get { return _position; }
            set { _position = value; }
        }


        public double X //return the player's position's X coordinate 
        {
            get { return _position.X; }
            set { _position.X = value; }
        }

        public double Y //return the player's position's Y coordinate 
        {
            get { return _position.Y; }
            set { _position.Y = value; }
        }

        public double Velx //return the player's position's Y coordinate 
        {
            get { return _velocity.X; }
            set { _velocity.X = value; }
        }

    }
}
