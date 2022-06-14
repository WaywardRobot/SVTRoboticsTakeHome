using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SVTRoboticsTakeHome
{
    public class Load
    {
      public int loadId { get; set; }

      public int x {get; set;}

      public int y {get; set;}

      public Robot findClosestRobot(Robot[] robots) {
        Robot closestRobot = null;
        Double closestDistance = 0;
        bool multipleRobotsNear = false;
        Robot nearRobot = null;

        foreach (var robot in robots)
        {
          double robotDistance = robot.distanceToGoal(this.x, this.y);
          //Debug.WriteLine("Checking Robot " + robot.robotId.ToString() + " at distance " + robotDistance.ToString());

          //Check if this is the closest robot
          if (closestRobot == null || robotDistance < closestDistance) {
            closestRobot = robot;
            closestDistance = robotDistance;
          }
          //If the robot is nearby, then see if it has the best battery left
          if (robotDistance <= 10) {
            //Debug.WriteLine("Robot " + robot.robotId.ToString() + " is nearby and at " + robot.batteryLevel.ToString() + " battery.");
            if (nearRobot == null) {
              nearRobot = robot;
            } else {
              multipleRobotsNear = true;
              //Note: If there is a tie in the most battery life, then returning the first one found.
              if (robot.batteryLevel > nearRobot.batteryLevel) {
                nearRobot = robot;
              }
            }
          }

        }

        //If there is more than one robot nearby, return the one with the most battery left.
        if (multipleRobotsNear) {
          return nearRobot;
        } else {
          return closestRobot;
        }
      }
    }
}