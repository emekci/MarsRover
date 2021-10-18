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

            Console.WriteLine("Please enter plateau's X and Y co-ordinates:");
            var xCoordinate = Convert.ToInt32(Console.ReadLine());
            var yCoordinate = Convert.ToInt32(Console.ReadLine());
            var plateau = new Plateau(new Position(xCoordinate, yCoordinate));

            Console.WriteLine("Directions Info: \n 0 = North \n 1 = East \n 2 = South \n 3 = West");
            Console.WriteLine("Please enter first rover's X and Y co-ordinates and Direction:");
            var firstRoverX = Convert.ToInt32(Console.ReadLine());
            var firstRoverY = Convert.ToInt32(Console.ReadLine());
            var firstRoverDirection = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the first rover's orientations");
            var firstRoverOrientations = Console.ReadLine();

            var firstRover = _roverService.SetRoverPosition(plateau, firstRoverX, firstRoverY, firstRoverDirection);
            firstRover = _roverService.Movement(plateau, firstRover, firstRoverOrientations);

            Console.WriteLine("Please enter second rover's X and Y co-ordinates, Direction and Orientations:");
            var secondRoverX = Convert.ToInt32(Console.ReadLine());
            var secondRoverY = Convert.ToInt32(Console.ReadLine());
            var secondRoverDirection = Convert.ToInt32(Console.ReadLine());
            var secondRoverOrientations = Console.ReadLine();

            var secondRover =
                _roverService.SetRoverPosition(plateau, secondRoverX, secondRoverY, secondRoverDirection);
            secondRover = _roverService.Movement(plateau, secondRover, secondRoverOrientations);

            RoverPositionHelper.CheckRoversPosition(firstRover, secondRover);

            Console.WriteLine(firstRover.ToRoverPosition());
            Console.WriteLine(secondRover.ToRoverPosition());
        }
    }
}