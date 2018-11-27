using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestatServer
{
    public interface RobotCommand
    {
        void Execute();
        
    }

    public class TrackLineRunCommand : RobotCommand
    {
        public double Length { get; set; }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }

    public class TrackTurnCommand : RobotCommand
    {
        public double Radius { get; set; }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }

    public class TrackArcRightCommand : RobotCommand
    {
        public double Radius { get; set; }
        public double Angle { get; set; }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }

    public class TrackArcLeftCommand : RobotCommand
    {
        public double Radius { get; set; }
        public double Angle { get; set; }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
