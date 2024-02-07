using FluentValidation;
using ResumeApp.Core.Dtos.ExperienceDtos;

namespace ResumeApp.Service.FluentValidation
{
    public class ExperienceValidator : AbstractValidator<ExperienceAddDto>
    {
        public ExperienceValidator()
        {
            RuleFor(x => x.CompanyName).NotEmpty().WithMessage("Şirket Adı Alanı Boş Olamaz.").NotNull().WithMessage("Şirket Adı Alanı Boş Olamaz.");
            RuleFor(x => x.Skills).NotNull().WithMessage("Yetenekler Alanı Boş Olamaz.").NotEmpty().WithMessage("Yetenekler Alanı Boş Olamaz.");
            RuleFor(x => x.About).NotNull().WithMessage("Yetenekler Alanı Boş Olamaz.").NotEmpty().WithMessage("Yetenekler Alanı Boş Olamaz.");
            RuleFor(x => x.StartDate).NotNull().WithMessage("Başlangıç Tarihi Boş Olamaz.").NotEmpty().WithMessage("Başlangıç Tarihi Boş Olamaz.");
            RuleFor(x => x.StartDate).GreaterThan(DateTime.Parse("01.01.1970")).WithMessage("Başlangıç Tarihi Geçersiz.");
            RuleFor(x => x.StartDate).LessThan(DateTime.Now).WithMessage("Başlangıç Tarihi Mevcut Tarihten İleride Olamaz.");
            RuleFor(x => x.StartDate).LessThan(x => x.EndDate).When(x => !x.Continue).WithMessage("Bitiş Tarihi Başlangıç Tarihinden Küçük Olamaz.");
        }
    }
}
