using System;
using MarsRover.Common.Enums;
using MarsRover.Core;
using MarsRover.Core.Helpers;
using MarsRover.Core.Interfaces;
using MarsRover.Service;
using MarsRover.Service.Interfaces;
using NUnit.Framework;

namespace MarsRover.Test
{
    public class MarsRoverTests
    {
        private readonly IRoverService _roverService;

        public MarsRoverTests()
        {
            _roverService = new RoverService();
        }
        
        /// <summary>
        /// Test method for rover's movement output
        /// </summary>
        [Test]
        public void RoverMovementOutputTest()
        {
            var plateau = new Plateau(new Position(5, 5));
            Rover rover = new Rover(plateau, new Position(1,2), Direction.North);
            _roverService.Movement(plateau, rover, "LMLMLMLMM");
            
            Assert.IsNotNull(rover);
            Assert.AreEqual(1, rover.Position.XCoordinate);
            Assert.AreEqual(3, rover.Position.YCoordinate);
            Assert.AreEqual(Direction.North, rover.Direction);
        }

        /// <summary>
        /// Test method for where Rovers are in the same position and the same plateau
        /// </summary>
        [Test]
        public void Should_ThrowException_When_RoversInSamePositionAndSamePlateau()
        {
            Rover firstRover = new Rover(new Plateau(new Position(5, 5)), new Position(1, 1), Direction.North);
            Rover secondRover = new Rover(new Plateau(new Position(5, 5)), new Position(1, 1), Direction.East);
            Assert.That(() => RoverPositionHelper.CheckRoversPosition(firstRover, secondRover), Throws.Exception);
        }
    }
}