using FluentValidation;
using PtProgramTrackerApi.Domain.Dtos;

namespace PtProgramTrackerApi.Application.Validators
{
    public class ClientInputValidator : AbstractValidator<ClientDto>
    {
        public ClientInputValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.DateOfBirth).NotEmpty();
            RuleFor(x => x.Height).GreaterThan(0).PrecisionScale(5, 2, false);
            RuleFor(x => x.Weight).GreaterThan(0).PrecisionScale(5, 2, false);
            RuleFor(x => x.PhoneNumber).MaximumLength(50);
        }
    }
}
