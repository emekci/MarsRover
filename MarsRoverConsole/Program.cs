using System;
using MarsRover.Core;
using MarsRover.Core.Extensions;
using MarsRover.Core.Helpers;
using MarsRover.Service;
using MarsRover.Service.Interfaces;

namespace MarsRoverConsole
{
    class Program
    {
        private static IRoverService _roverService;

        static void Main(string[] args)
        {
            _roverService = new RoverService();

            var plateau = GetPlateauInfo();

            Console.WriteLine("Directions Info: \n 0 = North \n 1 = East \n 2 = South \n 3 = West");

            Console.WriteLine("First Rover:");
            var firstRover = CreateRover(plateau);

            Console.WriteLine("Please enter First Rover Orientation");
            var firstRoverOrientations = Console.ReadLine();
            firstRover = _roverService.Movement(plateau, firstRover, firstRoverOrientations);

            Console.WriteLine("Second Rover:");
            var secondRover = CreateRover(plateau);
            
            Console.WriteLine("Please enter Second Rover Orientation");
            var secondRoverOrientations = Console.ReadLine();
            secondRover = _roverService.Movement(plateau, secondRover, secondRoverOrientations);

            RoverPositionHelper.CheckRoversPosition(firstRover, secondRover);

            Console.WriteLine(firstRover.ToRoverPosition());
            Console.WriteLine(secondRover.ToRoverPosition());
        }

        private static Rover CreateRover(Plateau plateau)
        {
            Console.WriteLine("Please enter Rover's X and Y co-ordinates, Direction");
            var firstRoverX = Convert.ToInt32(Console.ReadLine());
            var firstRoverY = Convert.ToInt32(Console.ReadLine());
            var firstRoverDirection = Convert.ToInt32(Console.ReadLine());

            return _roverService.SetRoverPosition(plateau, firstRoverX, firstRoverY, firstRoverDirection);
            ;
        }

        private static Plateau GetPlateauInfo()
        {
            Console.WriteLine("Please enter plateau's X and Y co-ordinates:");
            var xCoordinate = Convert.ToInt32(Console.ReadLine());
            var yCoordinate = Convert.ToInt32(Console.ReadLine());
            var plateau = new Plateau(new Position(xCoordinate, yCoordinate));
            return plateau;
        }
    }
}