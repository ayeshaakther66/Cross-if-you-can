using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Custom
{
    public class Lane
    {

        
        // elements in one lane, so created a list to store cars and points(gems, coins etc)
        private List<Car> _cars;
        private Car _car;
        private List<Point> _points;
        private Point _point;

        private double n = (new Random().NextDouble()); //random decimal number genertor for different speeds

        public Lane(double y, double x)
        {
            //initializing the lists
            _cars = new List<Car>(); 
            _points = new List<Point>();

            for (int i = 0; i < SplashKit.Rnd(1, 5); i++) //getting a random number of car to instantiate
            {
                _car = new Car(y, x);
                _cars.Add(_car);
                x -= SplashKit.Rnd(200, 400); // a random distance between the cars 
            }

            for (int i = 0; i < SplashKit.Rnd(2,8); i++) // getting a random number for the number of elements in each lane
            {

                if ((PointType)SplashKit.Rnd(3) == PointType.Gem) //to jsut minimise this objects occurence
                {
                    _point = new Gem(y);
                }
                else if ((PointType)SplashKit.Rnd(3) == PointType.Time)

                {
                    _point = new Boost(y);  
                }
                else
                {
                    _point = new Coin(y);
                }

                _points.Add(_point);


            }

        }
        public void Update() //updating car positions
        {
            foreach (Car c in _cars)
            {
                c.Update(n); //passing in the randomly generated decimal number(0.1-0.9)

            }
        }

        public void Draw() // drawing lane
        {
            foreach (Point point in _points)
            {
                point.Draw(); //draws all the point objects

            }
            foreach (Car c in _cars)
            {
                c.Draw(); //draws cars
            }
        }
        public List<Rectangle> Car_Proximity // returns a list of cars (position) created in each lane
        {
            get
            {
                var pcar = new List<Rectangle>(); // creating a new list
                foreach (Car c in _cars) 
                {
                    var p = c.Proximity; //gets the position(rectangle) of car
                    pcar.Add(p);
                }
                return pcar; // returns this to the lane manager
            }
        }

        public Dictionary<Circle, Type> Point_Proximity  // returns a dictionary which contains position of each point objects as key
                                                       // and its type (eg- gem, coin) as type created in each lane
        {
            get
            {
                var point_dic = new Dictionary<Circle, Type>();// creating a new dictionary 
                foreach (var p in _points)
                {
                    var point = p.Proximity; //gets the position of each points 
                    point_dic.Add(point, p.GetType()); //GetType is getting the type of instance it is , so for coin instance , the type is Coin
                }
                return point_dic; // returns this to the lane manager
            }
        }



        public void RemovePoint(Circle c) // removes the collided point from the lane 
        {
            var toRemove = new List<Point>();
            foreach (Point point in _points)
            {
                if (c.Equals(point.Proximity)) // checks if thats the point or not
                {
                    toRemove.Add(point); // adds it to the remove list
                }
            }
            foreach (Point p in toRemove)
            {
                _points.Remove(p); // removes it from the original list of points created
            }
        }
    }
}

