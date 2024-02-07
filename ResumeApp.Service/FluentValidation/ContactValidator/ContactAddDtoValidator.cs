using FluentValidation;
using Microsoft.EntityFrameworkCore.Query.Internal;
using ResumeApp.Core.Dtos.ContactDtos;

namespace ResumeApp.Service.FluentValidation.ContactValidator
{
    public class ContactAddDtoValidator : AbstractValidator<ContactAddDto>
    {
        public ContactAddDtoValidator()
        {
            RuleFor(x => x.Fullname).NotNull().WithMessage("Lütfen Ad Soyad Giriniz.").NotEmpty().WithMessage("Lütfen Ad Soyad Giriniz.");
            RuleFor(x => x.PhoneNumber).NotNull().WithMessage("Lütfen Telefon Numarası Giriniz.").NotEmpty().WithMessage("Lütfen Telefon Numarası Giriniz.");
            RuleFor(x => x.Message).NotNull().WithMessage("Lütfen Mesajınızı Giriniz.").NotEmpty().WithMessage("Lütfen Mesajınızı Giriniz.");
            RuleFor(x => x.Email).NotNull().WithMessage("Lütfen E-Mail Giriniz.").NotEmpty().WithMessage("Lütfen E-Mail Giriniz.").EmailAddress().WithMessage("Lütfen Geçerli Bir Email Adresi Giriniz.");
        }
    }
}
