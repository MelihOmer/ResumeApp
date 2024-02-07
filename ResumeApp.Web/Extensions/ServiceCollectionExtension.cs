using FluentValidation;
using FluentValidation.AspNetCore;
using ResumeApp.Core.Dtos.ExperienceDtos;
using ResumeApp.Web.Models;
using ResumeApp.Web.VmValidators;
using System.Reflection;

namespace ResumeApp.Web.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void IocLoadWeb(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(Assembly.GetAssembly(typeof(ExperienceAddDto)), ServiceLifetime.Transient);
            //services.AddScoped<IValidator<ExperienceAddModel>, ExperienceAddModelValidator>();
        }
    }
}
