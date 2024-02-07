using FluentValidation;
using ResumeApp.Core.Dtos.ProgrammingLanguageDtos;

namespace ResumeApp.Service.FluentValidation.ProgrammingLanguageValidator
{
    public class LanguageUpdateDtoValidator : AbstractValidator<LanguageUpdateDto>
    {
        public LanguageUpdateDtoValidator()
        {
            RuleFor(l => l.Name).NotNull().WithMessage("Dil Alanı Boş Olamaz.").NotEmpty().WithMessage("Dil Alanı Boş Olamaz.");
        }
    }
}
