using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using SplashKitSDK;
namespace Custom
{
    public class LaneManager
    {
        private List<Lane> _lanes; // a list for the manager to control
        private Lane _lane;
        private readonly int random = SplashKit.Rnd(-200, -10); // for generating a random start position on x axis for the cars in each lane


        public LaneManager()
        {
            _lanes = new List<Lane>();
            double y = 180;
            for (int i = 0; i < 4; i++) //creates 4 lanes 
            {
                _lane = new Lane(y, random);
                _lanes.Add(_lane); //adding them to the list _lanes
                y += 110;
            }

        }
        public void Update() //updating car positions in each lane
        {
            foreach (Lane l in _lanes)
            { 
                l.Update(); // updates each lane's cars accordingly
            }
        }

        public void Draw() // drawing lanes
        {
            foreach (Lane l in _lanes)
            {
                l.Draw(); // draws each lane's cars accordingly
            }
        }

        public List<Rectangle> Cars_Proximity // returns a list of car's positions(rectangle)
        {
            get
            {
                List<Rectangle> list = new List<Rectangle>(); // creating a new list to return this to the play state
                foreach (Lane l in _lanes)
                {
                    var p = l.Car_Proximity; // gets the property for car proximity(rectangle)
                    foreach (Rectangle rectangle in p)
                    {
                        list.Add(rectangle); // adds it the new list 
                    }

                }
                return list; // this contains all the car's postions(rectangles) of all the lanes
            }
        }
        public Dictionary<Circle, Type> Points_Proximity // returns a dictionary of point's positions(circle)
        {
            get
            {
                var dictionary = new Dictionary<Circle, Type>(); // creating a new dictionary to return this to the play state
                foreach (Lane l in _lanes)
                {
                    var p = l.Point_Proximity; // gets the property for point proximity(circle)
                    foreach (var c in p)
                    {
                        dictionary.Add(c.Key,c.Value);// adds it the new dictionary 
                    }

                }
                return dictionary; // this contains all the point's postions(circles) of all the lanes
            }
        }

        public void RemovePoints(Circle c) // removes points from the current game as the player has collided with it
        {
            
            foreach (Lane l in _lanes)
            {
                l.RemovePoint(c); // removes point in the lane the player collided into
            }

        }
    }
}