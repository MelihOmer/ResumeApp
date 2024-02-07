using FluentValidation;
using ResumeApp.Core.Dtos.ProgrammingLanguageDtos;

namespace ResumeApp.Service.FluentValidation.ProgrammingLanguageValidator
{
    public class LanguageCreateDtoValidator : AbstractValidator<LanguageCreateDto>
    {
        public LanguageCreateDtoValidator()
        {
            RuleFor(l => l.Name).NotNull().WithMessage("Dil Alanı Boş Olamaz.").NotEmpty().WithMessage("Dil Alanı Boş Olamaz.");
        }
    }
}
