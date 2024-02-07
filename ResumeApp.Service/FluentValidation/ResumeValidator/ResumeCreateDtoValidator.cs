using FluentValidation;
using ResumeApp.Core.Dtos;

namespace ResumeApp.Service.FluentValidation.ResumeValidator
{
    public class ResumeCreateDtoValidator : AbstractValidator<ResumeCreateDto>
    {
        public ResumeCreateDtoValidator()
        {
            RuleFor(r => r.FirstName).NotEmpty().NotNull();
            RuleFor(r => r.LastName).NotEmpty().NotNull();
            RuleFor(r => r.Address).NotEmpty().NotNull();
            RuleFor(r => r.PhoneNumber).NotEmpty().NotNull();
            RuleFor(r => r.DateOfBirth).NotEmpty().NotNull();
            RuleFor(r => r.Email).NotEmpty().NotNull();
        }
    }
}
