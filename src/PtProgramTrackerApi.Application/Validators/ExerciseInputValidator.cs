using FluentValidation;
using PtProgramTrackerApi.Domain.Inputs;

namespace PtProgramTrackerApi.Application.Validators
{
    public class ExerciseInputValidator : AbstractValidator<ExerciseInput>
    {
        public ExerciseInputValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Type).IsInEnum();
        }
    }
}
