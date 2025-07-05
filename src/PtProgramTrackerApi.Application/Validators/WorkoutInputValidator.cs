using FluentValidation;
using PtProgramTrackerApi.Domain.Inputs.ProgramInput;

namespace PtProgramTrackerApi.Application.Validators
{
    public class WorkoutInputValidator : AbstractValidator<WorkoutInput>
    {
        public WorkoutInputValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
