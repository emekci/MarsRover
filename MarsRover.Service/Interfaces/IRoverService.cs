using MarsRover.Core;

namespace MarsRover.Service.Interfaces
{
    public interface IRoverService
    {
        Rover SetRoverPosition(Plateau plateau, int xCoordinate, int yCoordinate, int direction);
        Rover Movement(Plateau plateau, Rover rover, string orientations);
    }
}