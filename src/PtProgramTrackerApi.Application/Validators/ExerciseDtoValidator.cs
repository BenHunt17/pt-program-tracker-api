using FluentValidation;
using PtProgramTrackerApi.Domain.Dtos;

namespace PtProgramTrackerApi.Application.Validators
{
    public class ExerciseDtoValidator : AbstractValidator<ExerciseDto>
    {
        public ExerciseDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Type).IsInEnum();
        }
    }
}
