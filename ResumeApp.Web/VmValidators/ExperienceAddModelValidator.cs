using FluentValidation;
using ResumeApp.Web.Models;

namespace ResumeApp.Web.VmValidators
{
    public class ExperienceAddModelValidator : AbstractValidator<ExperienceAddModel>
    {
        public ExperienceAddModelValidator()
        {
            RuleFor(e => e.ExperienceAddDto.CompanyName).NotEmpty().WithMessage("Şirket Adı Bilgisi Boş Olamaz.").NotNull().WithMessage("Şirket Adı Bilgisi Boş Olamaz.");
            RuleFor(e => e.ExperienceAddDto.About).NotEmpty().WithMessage("Bu Alan Boş Geçilemez.").NotNull().WithMessage("Bu Alan Boş Geçilemez.");
            RuleFor(e => e.ExperienceAddDto.Skills).NotEmpty().WithMessage("Bu Alan Boş Geçilemez.").NotNull().WithMessage("Bu Alan Boş Geçilemez.");
            RuleFor(e => e.ExperienceAddDto.About).MinimumLength(5).WithMessage("En az '5' Karakter Girilmelidir.");
            //RuleFor(e => e.ExperienceAddDto.StartDate).GreaterThan(DateTime.Now).WithMessage("Geçersiz Bir Tarih Girdiniz.");
            ////RuleFor(e => e.ExperienceAddDto.StartDate.Year).LessThan(DateTime.Parse("01.12.1950").Year).WithMessage("Geçersiz Bir Tarih Girdiniz.");
            ////RuleFor(e => e.ExperienceAddDto.EndDate.Year).LessThan(DateTime.Parse("01.12.1950").Year).WithMessage("Geçersiz Bir Tarih Girdiniz.");
            //RuleFor(e => e.ExperienceAddDto.EndDate).GreaterThan(DateTime.Now).WithMessage("Geçersiz Bir Tarih Girdiniz.");
        }
    }
}
