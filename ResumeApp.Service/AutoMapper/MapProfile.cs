using AutoMapper;
using ResumeApp.Core.Dtos;
using ResumeApp.Core.Dtos.ContactDtos;
using ResumeApp.Core.Dtos.EducationDtos;
using ResumeApp.Core.Dtos.ExperienceDtos;
using ResumeApp.Core.Dtos.ProgrammingLanguageDtos;
using ResumeApp.Core.Dtos.ProjectDtos;
using ResumeApp.Core.Dtos.SkillsDtos;
using ResumeApp.Core.Entities;

namespace ResumeApp.Service.AutoMapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<ResumeCreateDto, Resume>();
            CreateMap<Resume,ResumeDto>();
            CreateMap<Resume,ResumeUpdateDto>().ReverseMap();

            CreateMap<Experience, ExperienceAddDto>().ReverseMap();
            CreateMap<ExperienceUpdateDto, Experience>().ReverseMap();

            CreateMap<Education, EducationAddDto>().ReverseMap();
            CreateMap<EducationUpdateDto,Education>().ReverseMap();


            CreateMap<ProgramingLanguage, LanguageCreateDto>().ReverseMap();
            CreateMap<LanguageUpdateDto, ProgramingLanguage>().ReverseMap();

            CreateMap<SkillCreateDto, Skill>();
            CreateMap<SkillUpdateDto, Skill>().ReverseMap();

            CreateMap<ProjectCreateDto,Project>();
            CreateMap<ProjectUpdateDto,Project>().ReverseMap();

            CreateMap<ContactAddDto, Contact>();

            
           
        }
    }
}
