using FluentValidation;
using PtProgramTrackerApi.Domain.Dtos.Program;

namespace PtProgramTrackerApi.Application.Validators
{
    public class WorkoutDtoValidator : AbstractValidator<WorkoutDto>
    {
        public WorkoutDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
