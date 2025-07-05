using FluentValidation;
using PtProgramTrackerApi.Domain.Inputs.ProgramInput;

namespace PtProgramTrackerApi.Application.Validators
{
    public class ProgramInputValidator : AbstractValidator<ProgramInput>
    {
        public ProgramInputValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
