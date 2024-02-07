using ResumeApp.Core.Dtos.EducationDtos;
using ResumeApp.Core.Entities;

namespace ResumeApp.Core.Contracts.Services
{
    public interface IEducationService : IGenericService<Education>
    {
        Task AddEducation(EducationAddDto dto,int resumeId);
        Task<EducationUpdateDto> GetEducationUpdate(int Id);
        Task EducationUpdate(EducationUpdateDto eduDto);
        Task RemoveEducation(int id);


    }
}
