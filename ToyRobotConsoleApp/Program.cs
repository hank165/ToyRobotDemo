using System;
using ToyRobotLibrary;
namespace ToyRobotConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool keepSimulation = true;
            ToyRobot robot = null;
            DisplayUsage();
            while (keepSimulation)
            {
                
                Console.WriteLine("Please enter a command or enter x to end the program.");
                string input = Console.ReadLine().Trim();
                if(input.Equals("x", StringComparison.OrdinalIgnoreCase))
                {
                    keepSimulation = false;
                    break;
                }
                //validate inpuut
                if (!ValidateInput(input))
                {
                    DisplayUsage();
                }
                else
                {
                    string[] inputArgs = input.Split(' ');
                    if (inputArgs[0].Equals(Command.Place.ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        string[] parameters = inputArgs[1].Trim().Split(',');
                        Direction direction;
                        Enum.TryParse(parameters[2], true, out direction);
                        robot = new ToyRobot(Convert.ToInt32(parameters[0]), Convert.ToInt32(parameters[1]), direction);
                    }
                    if (inputArgs[0].Equals(Command.Left.ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        if (robot is not null)
                        {
                            robot.Left();
                        }
                    }

                    if (inputArgs[0].Equals(Command.Right.ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        if (robot is not null)
                        {
                            robot.Right();
                        }
                    }
                    if (inputArgs[0].Equals(Command.Move.ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        if (robot is not null)
                        {
                            robot.Move();
                        }
                    }
                    if (inputArgs[0].Equals(Command.Report.ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        if (robot is not null)
                        {
                           Console.WriteLine(robot.Report());
                            
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Display  usage of the Toy Robot Simulator
        /// </summary>
        static void DisplayUsage()
        {
            string usage = @"
            ******************** Toy Robot Simulator ***********************
            Enter one of  the following command.\n
            1. PLACE  
               PLACE will put the toy robot on the table in position X,Y and facing NORTH, SOUTH, EAST or WEST.
                (0,0) can be considered as the SOUTH WEST corner and (5,5) as the NORTH EAST corner.
               Example: PLACE 0,0,NORTH
            2. MOVE
               MOVE will move the toy robot one unit forward in the direction it is currently facing.
               Example: MOVE
            3. LEFT and RIGHT
               LEFT and RIGHT will rotate the robot 90 degrees in the specified direction without changing the position of the robot.
               Example: LEFT
            4. REPORT 
               REPORT will announce the X,Y and orientation of the robot.
               Example: REPORT
            ";
            Console.Write(usage);
        }

        /// <summary>
        /// Validate input
        /// </summary>
        /// <param name="input">input</param>
        /// <returns>true for validate input false for invalid input</returns>
        static bool ValidateInput(string input)
        {
            bool inputValid = false;
            const int minCoordinate = 0;
            const int maxCoordinate = 5;
            if (input.Length >= 4)
            {
                //check PLACE command
                string[] inputArgs = input.Split(' ');
                if (inputArgs[0].Equals(Command.Place.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    //check second part of input 
                    string parameter = inputArgs[1];
                    if (!string.IsNullOrEmpty(parameter) && parameter.Length >= 8)
                    {
                        string[] positionParamaters = parameter.Split(',');
                        if (positionParamaters.Length == 3)
                        {
                            int xCoordinate, yCoordinate;
                            Direction direction;
                            //check each position parameter
                            if (int.TryParse(positionParamaters[0], out xCoordinate) && int.TryParse(positionParamaters[1], out yCoordinate) &&
                                Enum.TryParse(positionParamaters[2],true,out direction))
                            {
                                if(xCoordinate >= minCoordinate && xCoordinate <= maxCoordinate &&
                                   yCoordinate >= minCoordinate && yCoordinate <= maxCoordinate)
                                inputValid = true;
                            }
                        }
                    }
                }
                //check the other commands
                else if (inputArgs[0].Equals(Command.Move.ToString(), StringComparison.OrdinalIgnoreCase) ||
                        inputArgs[0].Equals(Command.Left.ToString(), StringComparison.OrdinalIgnoreCase) ||
                        inputArgs[0].Equals(Command.Right.ToString(), StringComparison.OrdinalIgnoreCase) ||
                        inputArgs[0].Equals(Command.Report.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return inputValid;
        }
    }
}
