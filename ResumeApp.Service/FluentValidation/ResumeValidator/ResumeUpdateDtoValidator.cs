using FluentValidation;
using ResumeApp.Core.Dtos;

namespace ResumeApp.Service.FluentValidation.ResumeValidator
{
    public class ResumeUpdateDtoValidator:AbstractValidator<ResumeUpdateDto>
    {
        public ResumeUpdateDtoValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Ad Alanı Boş Olamaz").NotNull().WithMessage("Ad Alanı Boş Olamaz");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("SoyAd Alanı Boş Olamaz").NotNull().WithMessage("SoyAd Alanı Boş Olamaz");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email Alanı Boş Olamaz").NotNull().WithMessage("Email Alanı Boş Olamaz");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Telefon No Alanı Boş Olamaz").NotNull().WithMessage("Telefon No Alanı Boş Olamaz");
            RuleFor(x => x.Address).NotEmpty().WithMessage("AdresAlanı Boş Olamaz").NotNull().WithMessage("Adres Alanı Boş Olamaz");
            RuleFor(x => x.DateOfBirth).NotEmpty().WithMessage("Doğum Tarihi Alanı Boş Olamaz").NotNull().WithMessage("Doğum Tarihi Alanı Boş Olamaz");
        }
    }
}
