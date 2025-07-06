using FluentValidation;
using PtProgramTrackerApi.Domain.Dtos.Program;

namespace PtProgramTrackerApi.Application.Validators
{
    public class ProgramDtoValidator : AbstractValidator<ProgramDto>
    {
        public ProgramDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
