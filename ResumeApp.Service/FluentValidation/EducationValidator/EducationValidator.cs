using FluentValidation;
using ResumeApp.Core.Dtos.EducationDtos;

namespace ResumeApp.Service.FluentValidation.EducationValidator
{
    public class EducationValidator : AbstractValidator<EducationAddDto>
    {
        public EducationValidator()
        {
            RuleFor(e => e.SchoolName).NotEmpty().WithMessage("Okul Adı Boş Olamaz.").NotNull().WithMessage("Okul Adı Boş Olamaz.");
            RuleFor(e => e.Branch).NotEmpty().WithMessage("Branş Boş Olamaz.").NotNull().WithMessage("Branş Boş Olamaz.");
            RuleFor(e => e.About).NotEmpty().WithMessage("Açıklama Boş Olamaz.").NotNull().WithMessage("Açıklama Boş Olamaz.");
            RuleFor(x => x.StartDate).NotNull().WithMessage("Başlangıç Tarihi Boş Olamaz.").NotEmpty().WithMessage("Başlangıç Tarihi Boş Olamaz.");
            RuleFor(x => x.StartDate).GreaterThan(DateTime.Parse("01.01.1970")).WithMessage("Başlangıç Tarihi Geçersiz.");
            RuleFor(x => x.StartDate).LessThan(DateTime.Now).WithMessage("Başlangıç Tarihi Mevcut Tarihten İleride Olamaz.");
            RuleFor(x => x.StartDate).LessThan(x => x.EndDate).When(x => !x.Continue).WithMessage("Bitiş Tarihi Başlangıç Tarihinden Küçük Olamaz.");
        }
    }
}
