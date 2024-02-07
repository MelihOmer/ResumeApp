using ResumeApp.Core.Dtos.ExperienceDtos;
using ResumeApp.Core.Entities;

namespace ResumeApp.Core.Contracts.Services
{
    public interface IExperienceService : IGenericService<Experience>
    {
        Task AddExperience(ExperienceAddDto dto,int Id);
        Task<ExperienceUpdateDto> GetExperienceUpdate(int Id);
        Task UpdateExperience(ExperienceUpdateDto updateDto);
        Task RemoveExperience(int id);
    }
}
