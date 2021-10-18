using MarsRover.Common.Enums;
using MarsRover.Core.Interfaces;

namespace MarsRover.Core
{
    public class Rover : IRover
    {
        public Rover(IPlateau plateau, IPosition position, Direction direction)
        {
            Plateau = plateau;
            Position = position;
            Direction = direction;
        }

        public IPlateau Plateau { get; }
        public IPosition Position { get; }
        public Direction Direction { get; set; }
    }
}