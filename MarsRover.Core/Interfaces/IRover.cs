using MarsRover.Common.Enums;

namespace MarsRover.Core.Interfaces
{
    public interface IRover
    {
        public IPlateau Plateau { get; }
        public IPosition Position { get; }
        public Direction Direction { get; set; }
    }
}