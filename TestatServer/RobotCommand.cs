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
    }

    public class TrackTurnCommand : RobotCommand
    {
        public float Angle { get; set; }

        public TrackTurnCommand(float angle)
        {
            Angle = angle;
        }

        public override void Execute(Robot robot)
        {
            robot.Drive.RunTurn(Angle, Speed, Acceleration);
        }
    }

    public class TrackArcRightCommand : RobotCommand
    {
        public float Radius { get; set; }
        public float Angle { get; set; }

        public TrackArcRightCommand(float radius, float angle)
        {
            Radius = radius;
            Angle = angle;
        }

        public override void Execute(Robot robot)
        {
            robot.Drive.RunArcRight(Radius, Angle, Speed, Acceleration);
        }
    }

    public class TrackArcLeftCommand : RobotCommand
    {
        public float Radius { get; set; }
        public float Angle { get; set; }

        public TrackArcLeftCommand(float radius, float angle)
        {
            Radius = radius;
            Angle = angle;
        }

        public override void Execute(Robot robot)
        {
            robot.Drive.RunArcLeft(Radius, Angle, Speed, Acceleration);
        }
    }
}
