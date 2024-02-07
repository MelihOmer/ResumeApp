using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ResumeApp.Core.Contracts;
using ResumeApp.Core.Contracts.Services;
using ResumeApp.Core.Dtos;
using ResumeApp.Core.Dtos.ExperienceDtos;
using ResumeApp.Repository;
using ResumeApp.Repository.Repository;
using ResumeApp.Service.AutoMapper;
using ResumeApp.Service.FluentValidation;
using ResumeApp.Service.FluentValidation.ResumeValidator;
using ResumeApp.Service.Services;
using System.Reflection;

namespace ResumeApp.Service.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddServicesAndRepositoryLoad(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IResumeService, ResumeService>();
            services.AddScoped<IExperienceService , ExperienceService>();
            services.AddScoped<IEducationService, EducationService>();
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<ISkillService,SkillService>();
            services.AddScoped<IProjectService,ProjectService>();
            services.AddScoped<IContactService, ContactService>();
        }

        public static void AddDbContext(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("SqlServer"));
            });
        }
        public static void AddCustomAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetAssembly(typeof(MapProfile)));
        }
        public static void AddCustomFluentValidation(this IServiceCollection services)
        {
            services.AddScoped<IValidator<ResumeUpdateDto>, ResumeUpdateDtoValidator>();
            services.AddScoped<IValidator<ExperienceAddDto>, ExperienceValidator>();

            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(Assembly.GetAssembly(typeof(ResumeUpdateDtoValidator)),ServiceLifetime.Transient);
        }
    }
}
