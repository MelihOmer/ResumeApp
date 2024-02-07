using FluentValidation;
using ResumeApp.Core.Dtos.SkillsDtos;

namespace ResumeApp.Service.FluentValidation.SkillValidator
{
    public class SkillCreateDtoValidator : AbstractValidator<SkillCreateDto>
    {
        public SkillCreateDtoValidator()
        {
            RuleFor(s => s.Name).NotNull().WithMessage("Yetenek Alanı Boş Olamaz").NotEmpty().WithMessage("Yetenek Alanı Boş Olamaz");
        }
    }
}
