using FluentValidation;
using ResumeApp.Core.Dtos.SkillsDtos;

namespace ResumeApp.Service.FluentValidation.SkillValidator
{
    public class SkillUpdateDtoValidator : AbstractValidator<SkillUpdateDto>
    {
        public SkillUpdateDtoValidator()
        {
            RuleFor(s => s.Name).NotNull().WithMessage("Yetenek Alanı Boş Olamaz").NotEmpty().WithMessage("Yetenek Alanı Boş Olamaz");
        }
    }
}
