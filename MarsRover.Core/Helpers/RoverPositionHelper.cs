using System;
using MarsRover.Common;
using MarsRover.Core.Interfaces;

namespace MarsRover.Core.Helpers
{
    public static class RoverPositionHelper
    {
        /// <summary>
        /// Throws exception if both rovers are in the same position
        /// </summary>
        /// <param name="firstRover"></param>
        /// <param name="secondRover"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void CheckRoversPosition(IRover firstRover, IRover secondRover)
        {
            if ((firstRover.Position.XCoordinate == secondRover.Position.XCoordinate) && (firstRover.Position.YCoordinate == secondRover.Position.YCoordinate))
            {
                throw new ArgumentException(ErrorMessages.BothRoversAreSamePosition);
            }
        }

        /// <summary>
        /// Throws exception if Rover position not in the plateau position range
        /// </summary>
        /// <param name="plateau"></param>
        /// <param name="rover"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void IsRoverInPlateau(IPlateau plateau, IRover rover)
        {
            if (rover.Position.XCoordinate > plateau.Position.XCoordinate || rover.Position.YCoordinate > plateau.Position.YCoordinate)
            {
                throw new ArgumentException(ErrorMessages.RoverNotInPlateau);
            }
        }
    }
}