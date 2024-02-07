using ResumeApp.Core.Dtos.SkillsDtos;
using ResumeApp.Core.Entities;

namespace ResumeApp.Core.Contracts.Services
{
    public interface ISkillService : IGenericService<Skill>
    {
        Task AddSkill(SkillCreateDto dto, int resumeId);
        Task<SkillUpdateDto> GetSkillUpdate(int Id);
        Task UpdateSkill(SkillUpdateDto dto);
        Task RemoveSkill(int id);
    }
}
