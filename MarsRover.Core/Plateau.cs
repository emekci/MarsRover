using MarsRover.Core.Interfaces;

namespace MarsRover.Core
{
    public class Plateau : IPlateau
    {
        public Position Position { get; }
        public Plateau(Position position)
        {
            Position = position;
        }
    }
}