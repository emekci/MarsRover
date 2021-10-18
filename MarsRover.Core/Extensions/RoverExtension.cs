namespace MarsRover.Core.Extensions
{
    public static class RoverExtension
    {
        public static string ToRoverPosition(this Rover rover)
        {
            return $"{rover.Position.XCoordinate} {rover.Position.YCoordinate} {rover.Direction.ToString()[0]}";
        }
    }
}