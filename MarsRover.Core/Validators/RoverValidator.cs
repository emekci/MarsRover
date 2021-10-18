using FluentValidation;
using MarsRover.Core.Interfaces;

namespace MarsRover.Core.Validators
{
    public class RoverValidator : AbstractValidator<IRover>
    {
        public RoverValidator()
        {
            RuleFor(rover => rover.Direction).NotNull().IsInEnum().WithMessage(rover =>
                $"{rover.Direction} is wrong direction value. Please check directions info.");

            RuleFor(rover => rover.Position.XCoordinate).GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(rover => rover.Plateau.Position.XCoordinate)
                .WithMessage("Rover must be inside the plateau");

            RuleFor(rover => rover.Position.YCoordinate).GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(rover => rover.Plateau.Position.YCoordinate)
                .WithMessage("Rover must be inside the plateau");
        }
    }
}