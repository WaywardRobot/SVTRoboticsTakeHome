using System;

namespace SVTRoboticsTakeHome
{
    public class Robot
    {
        public int robotId { get; set; }

        public int x {get; set;}

        public int y {get; set;}

        public int batteryLevel { get; set; }

        public double distanceToGoal (int goalX, int goalY) 
        {
          //Formula: Sqrt((x2 - x1)^2 + (y2 - y1)^2)
          return Math.Sqrt(Math.Pow(goalX - this.x, 2) + Math.Pow(goalY - this.y, 2));
        }


    }
}