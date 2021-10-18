using System;
using System.Linq;
using FluentValidation.Results;
using MarsRover.Common.Enums;
using MarsRover.Core;
using MarsRover.Core.Helpers;
using MarsRover.Core.Interfaces;
using MarsRover.Core.Validators;
using MarsRover.Service.Interfaces;

namespace MarsRover.Service
{
    public class RoverService : IRoverService
    {
        public Rover SetRoverPosition(Plateau plateau, int xCoordinate, int yCoordinate, int direction)
        {
            var rover = new Rover(plateau, new Position(xCoordinate, yCoordinate), (Direction) direction);
            
            var validationResult = ValidateRover(rover);
            
            if (!validationResult.IsValid)
            {
                throw new Exception(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
            }

            return rover;
        }

        public Rover Movement(Plateau plateau, Rover rover, string orientations)
        {
            foreach (var orientation in orientations)
            {
                switch (orientation)
                {
                    case (char) Orientation.Left:
                        TurnLeft(rover);
                        break;
                    case (char) Orientation.Right:
                        TurnRight(rover);
                        break;
                    case (char) Orientation.Move:
                        Move(rover);
                        break;
                    default:
                        throw new ArgumentException($"Invalid Orientation Value : {orientation}");
                }
            }

            RoverPositionHelper.IsRoverInPlateau(plateau, rover);

            return rover;
        }

        private static ValidationResult ValidateRover(IRover rover)
        {
            var roverValidator = new RoverValidator();
            return roverValidator.Validate(rover);
        }

        private static void Move(IRover rover)
        {
            switch (rover.Direction)
            {
                case Direction.North:
                    rover.Position.YCoordinate++;
                    break;
                case Direction.South:
                    rover.Position.YCoordinate--;
                    break;
                case Direction.East:
                    rover.Position.XCoordinate++;
                    break;
                case Direction.West:
                    rover.Position.XCoordinate--;
                    break;
            }
        }

        private static void TurnRight(IRover rover)
        {
            rover.Direction = rover.Direction + 1 > Direction.West ? Direction.North : rover.Direction + 1;
        }

        private static void TurnLeft(IRover rover)
        {
            rover.Direction = rover.Direction - 1 < Direction.North ? Direction.West : rover.Direction - 1;
        }
    }
}