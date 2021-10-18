using System;
using MarsRover.Common;
using MarsRover.Core.Interfaces;

namespace MarsRover.Core.Helpers
{
    public static class RoverPositionHelper
    {
        public static void CheckRoversPosition(IRover firstRover, IRover secondRover)
        {
            if (firstRover.Position == secondRover.Position)
            {
                throw new ArgumentException(ErrorMessages.BothRoversAreSamePosition);
            }
        }

        public static void IsRoverInPlateau(IPlateau plateau, IRover rover)
        {
            if (rover.Position.XCoordinate > plateau.Position.XCoordinate || rover.Position.YCoordinate > plateau.Position.YCoordinate)
            {
                throw new ArgumentException(ErrorMessages.RoverNotInPlateau);
            }
        }
    }
}