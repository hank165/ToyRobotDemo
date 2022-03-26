using System;

namespace ToyRobotLibrary
{
    /// <summary>
    /// ToyRobot
    /// </summary>
    public class ToyRobot
    {
        /// <summary>
        /// minimum coordinate value
        /// </summary>
        private const int minCoordinate = 0;

        /// <summary>
        /// Max coordinate value
        /// </summary>
        private const int maxCoordonate = 5;

        /// <summary>
        /// XCoordinate
        /// </summary>
        public int XCoordinate { get; set; }

        /// <summary>
        /// YCoordinate
        /// </summary>
        public int YCoordinate { get; set; }

        /// <summary>
        /// Direction
        /// </summary>
        public Direction Direction { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ToyRobot"/> class.
        /// </summary>
        /// <param name="xCoordinate"></param>
        /// <param name="yCoordinate"></param>
        /// <param name="direction"></param>
        public ToyRobot(int xCoordinate, int yCoordinate, Direction direction)
        {
            this.XCoordinate = xCoordinate;
            this.YCoordinate = yCoordinate;
            this.Direction = direction;
        }

        /// <summary>
        /// Move the toy robot one unit forward in the direction it is currently facing
        /// </summary>
        public void Move()
        {
            //Check current coordinates to prevent the robot falling off the table.
            if ((this.XCoordinate == minCoordinate && this.Direction == Direction.West)||
                (this.XCoordinate == maxCoordonate && this.Direction == Direction.East) ||
                (this.YCoordinate == minCoordinate && this.Direction == Direction.South) ||
                (this.YCoordinate == maxCoordonate && this.Direction == Direction.North))
            {
                return;
            }
            
            switch (this.Direction)
            {
                case Direction.North:
                    this.YCoordinate++;
                    break;
                case Direction.East:
                    this.XCoordinate++;
                    break;
                case Direction.West:
                    this.XCoordinate--;
                    break;
                case Direction.South:
                    this.YCoordinate--;
                    break;
            }
        }

        /// <summary>
        /// LEFT will  rotate the robot 90 degrees in the specified direction without changing the position of the robot.
        /// </summary>
        public void Left()
        {
            int intDirection = Convert.ToInt32(this.Direction);
            intDirection = intDirection == 1 ? 4 : (intDirection - 1);
            this.Direction = (Direction)intDirection;
        }

        /// <summary>
        /// RIGHT will  rotate the robot 90 degrees in the specified direction without changing the position of the robot.
        /// </summary>
        public void Right()
        {
            int intDirection = Convert.ToInt32(this.Direction);
            intDirection = intDirection == 4 ? 1 : (intDirection + 1);
            this.Direction = (Direction)intDirection;
        }

        /// <summary>
        /// Return report with  X,Y and orientation of the robot.
        /// </summary>
        /// <returns></returns>
        public string Report()
        {
            return string.Format("{0},{1},{2}", XCoordinate, YCoordinate, Direction.ToString().ToUpper());
        }
    }
}
