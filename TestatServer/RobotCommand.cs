using RobotCtrl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestatServer
{
    public abstract class RobotCommand
    {
        protected float Speed = 0.5f;
        protected float Acceleration = 0.3f;

        public abstract void Execute(Robot robot);        
    }

    public class TrackLineRunCommand : RobotCommand
    {
        public float Length { get; set; }

        public TrackLineRunCommand(float length)
        {
            Length = length;
        }

        public override void Execute(Robot robot)
        {
            robot.Drive.RunLine(Length, Speed, Acceleration);
        }

        public override string ToString()
        {
            return "TrackLine " + Length;
        }
    }

    public class TrackTurnLeftCommand : RobotCommand
    {
        public int Angle { get; set; }

        public TrackTurnLeftCommand(int angle)
        {
            Angle = angle;
        }

        public override void Execute(Robot robot)
        {
            robot.Drive.RunTurn(Angle, Speed, Acceleration);
        }

        public override string ToString()
        {
            return "TrackTurnLeft " + Angle;
        }
    }

    public class TrackTurnRightCommand : RobotCommand
    {
        public int Angle { get; set; }

        public TrackTurnRightCommand(int angle)
        {
            Angle = angle;
        }

        public override void Execute(Robot robot)
        {
            robot.Drive.RunTurn(-Angle, Speed, Acceleration);
        }

        public override string ToString()
        {
            return "TrackTurnRight " + Angle;
        }
    }

    public class TrackArcRightCommand : RobotCommand
    {
        public int Angle { get; set; }
        public float Radius { get; set; }

        public TrackArcRightCommand(int angle, float radius)
        {
            Angle = angle;
            Radius = radius;
        }

        public override void Execute(Robot robot)
        {
            robot.Drive.RunArcRight(Radius, Angle, Speed, Acceleration);
        }

        public override string ToString()
        {
            return "TrackArcRight " + Angle + " " + Radius;
        }
    }

    public class TrackArcLeftCommand : RobotCommand
    {
        public int Angle { get; set; }
        public float Radius { get; set; }

        public TrackArcLeftCommand(int angle, float radius)
        {
            Angle = angle;
            Radius = radius;
        }

        public override void Execute(Robot robot)
        {
            robot.Drive.RunArcLeft(Radius, Angle, Speed, Acceleration);
        }

        public override string ToString()
        {
            return "TrackArcLeft " + Angle + " " + Radius;
        }
    }
}
