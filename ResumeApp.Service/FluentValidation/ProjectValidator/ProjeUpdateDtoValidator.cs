using FluentValidation;
using ResumeApp.Core.Dtos.ProjectDtos;

namespace ResumeApp.Service.FluentValidation.ProjectValidator
{
    public class ProjeUpdateDtoValidator : AbstractValidator<ProjectUpdateDto>
    {
        public ProjeUpdateDtoValidator()
        {
            RuleFor(p => p.ProjectName).NotNull().WithMessage("Proje Adı Boş Olamaz.").NotEmpty().WithMessage("Proje Adı Boş Olamaz.");
            RuleFor(p => p.ProjectDescription).NotNull().WithMessage("Açıklama Boş Olamaz.").NotEmpty().WithMessage("Açıklama Boş Olamaz.");
            RuleFor(p => p.file).NotEmpty().When(x => x.FileUpdate).WithMessage("Proje Dosyası Boş Olamaz.");
           
        }
    }
}
